using HttpWebTesting;
using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using Serilog;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GTC.Extensions;
using System.Collections.Generic;

namespace WebTestExecutionEngine
{
    public class RequestExecution
    {
        #region -- Properties -----
        public HttpWebTest httpWebTest { get; set; }

        public WTI_Request request { get; set; }

        public HttpResponseMessage httpResponseMessage { get; set; }

        public string ResponseAsString = string.Empty;

        private TimeSpan _responseTime = TimeSpan.MinValue;
        #endregion

        #region -- Constructors -----
        public RequestExecution(WTI_Request wTI_RequestObject, HttpWebTest webTest)
        {
            httpWebTest = webTest;
            request = wTI_RequestObject;
        }
        #endregion

        public async Task<WebTestResultsItem> ProcessRequest()
        {
            // Make sure we should execute the request. 
            if (request.Enabled == false)
            {
                WTI_SkippedItem skippedItem = new WTI_SkippedItem(
                    request.RequestUri.GetLeftPart(UriPartial.Path)
                    , WebTestItemType.Wti_LoopControl);
                Log.ForContext("SourceContext", "RequestExecution").Debug("Skipping request {objectItemType}", request.RequestUri.GetLeftPart(UriPartial.Path));
                return new WTRI_SkippedItem(skippedItem);
            }

            // Start overall timer
            DateTime dt = DateTime.UtcNow;

            // Apply all context values to request objects
            httpWebTest.ContextProperties.BuildRequestWithContextValues(request);

            // trigger pre-request event to fire any handlers that were added.
            HandlePreRequestEventProcessing();

            // Execute the request
            var response = await ExecuteRequest(request);

            // Handle the various post-request steps
            var results = ExecutePostRequestSteps(response);

            // Add the request's response time to the result.
            results.ResponseTime = _responseTime;

            // Get the processing timer for the request
            results.TotalExecutionTime = DateTime.UtcNow - dt;

            results.ItemExecutionFailed = request.Rules.ContainsFailedRuleResult();

            // return the results object to the test engine
            return results;
        }


        #region -- Private Methods -----
        private async Task<HttpResponseMessage> ExecuteRequest(WTI_Request request)
        {
            var client = new System.Net.Http.HttpClient();
            client.Timeout = new TimeSpan(0, 0, 30);

            DateTime dt = DateTime.UtcNow;
            //var response = await RequestClient.SendAsync(request.requestItem);
            var response = await client.SendAsync(request.requestItem);
            _responseTime = DateTime.UtcNow - dt;
            Log.ForContext("SourceContext", "RequestExecution").Debug("Request execution completed in {_time} seconds for {request}.", _responseTime.TotalSeconds, request.RequestUri.GetLeftPart(UriPartial.Path));
            return response;
        }

        private WTRI_Request ExecutePostRequestSteps(HttpResponseMessage response)
        {
            if (response != null)
            {
                WTRI_Request requestResults = GetResults(response);
                HandleValidationEventProcessing(response);
                HandleExtractionEventProcessing(response);
                HandlePostRequestEventProcessing(response);
                return requestResults;
            }
            else if (httpWebTest.StopOnError == true)
            {
                throw new StopOnErrorException($"The request with Guid {request.guid} returned a null response.");
            }
            else
            {
                return null;
            }
        }

        private WTRI_Request GetResults(HttpResponseMessage response)
        {
            if (request.RecordResults == true)
            {
                WTRI_Request resultsItem = new WTRI_Request(request.guid);
                resultsItem.response = response;
                resultsItem.responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                resultsItem.contextCollection = httpWebTest.ContextProperties;
                Log.ForContext("SourceContext", "RequestExecution").Debug("GetResults(HttpResponseMessage) completed for {objectItemType}.", request.RequestUri.GetLeftPart(UriPartial.Path));
                return resultsItem;
            }
            else
            {
                Log.ForContext("SourceContext", "RequestExecution").Debug("GetResults(HttpResponseMessage) was skipped for {objectItemType}", request.RequestUri.GetLeftPart(UriPartial.Path));
            }
            return null;
        }

        private WTRI_Request GetResults()
        {
            if (request.RecordResults == true)
            {
                WTRI_Request resultsItem = new WTRI_Request(request.guid);
                resultsItem.response = null;
                resultsItem.HttpResponseMessageWasNull = true;
                resultsItem.contextCollection = httpWebTest.ContextProperties;
                Log.ForContext("SourceContext", "RequestExecution").Debug("GetResults() completed for {objectItemType}.", request.RequestUri.GetLeftPart(UriPartial.Path));
                return resultsItem;
            }
            else
            {
                Log.ForContext("SourceContext", "RequestExecution").Debug("GetResults(HttpResponseMessage) was skipped for {objectItemType}", request.RequestUri.GetLeftPart(UriPartial.Path));
            }
            return null;
        }
        #endregion


        #region -- PreRequest Event -----
        private void HandlePreRequestEventProcessing()
        {
            // Handle RequestRule_PreRequest items
            foreach (var rule in request.Rules.Where(r => r.RuleType == RuleType.RequestRule_PreRequest))
            {
                PreRequestRule preRequestRule = rule as PreRequestRule;
                PreRequest += preRequestRule.PreRequest;
                Log.ForContext("SourceContext", "RequestExecution").Debug("adding RequestRule_PreRequest {rule} for {request}", rule.Name, request.guid);
            }
            FirePreRequestHandler();
        }

        public void FirePreRequestHandler()
        {
            PreRequestEventArgs args = new PreRequestEventArgs();
            args.webTest = httpWebTest;
            args.requestItem = request;
            OnPreRequest(args);
            request = args.requestItem;
        }

        public event EventHandler<PreRequestEventArgs> PreRequest;

        protected virtual void OnPreRequest(PreRequestEventArgs e)
        {
            EventHandler<PreRequestEventArgs> handler = PreRequest;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion


        #region -- Validation Rule Event -----
        private void HandleValidationEventProcessing(HttpResponseMessage response)
        {
            // Handle RequestRule_Validation items
            foreach (var rule in request.Rules.Where(r => r.RuleType == RuleType.RequestRule_Validation))
            {
                ValidationRule validationRule = rule as ValidationRule;
                Validate += validationRule.Validate;
                Log.ForContext("SourceContext", "RequestExecution").Debug("adding RequestRule_Validation {rule} for {request}", rule.Name, request.guid);
            }

            // Handle TestRule_Validation
            foreach (var rule in httpWebTest.Rules.Where(r => r.RuleType == RuleType.TestRule_Validation))
            {
                ValidationRule validationRule = rule as ValidationRule;
                Validate += validationRule.Validate;
                Log.ForContext("SourceContext", "RequestExecution").Debug("adding TestRule_Validation {rule} for {request}", rule.Name, request.guid);
            }
            FireValidationRuleHandler(response);
        }

        public void FireValidationRuleHandler(HttpResponseMessage response)
        {
            RuleEventArgs args = new RuleEventArgs();
            args.webTest = httpWebTest;
            args.requestItem = request;
            args.response = response;
            OnValidationRule(args);
            request = args.requestItem;
        }
        
        public event EventHandler<RuleEventArgs> Validate;
        
        protected virtual void OnValidationRule(RuleEventArgs e)
        {
            EventHandler<RuleEventArgs> handler = Validate;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion


        #region -- Extraction Rule Event -----
        private void HandleExtractionEventProcessing(HttpResponseMessage response)
        {
            // Handle RequestRule_Extraction items
            foreach (var rule in request.Rules.Where(r => r.RuleType == RuleType.RequestRule_Extraction))
            {
                ExtractionRule extractionRule = rule as ExtractionRule;
                Extract += extractionRule.Extract;
                Log.ForContext("SourceContext", "RequestExecution").Debug("adding RequestRule_Extraction {rule} for {request}", rule.Name, request.guid);
            }
            FireExtractionRuleHandler(response);
        }

        public void FireExtractionRuleHandler(HttpResponseMessage response)
        {
            RuleEventArgs args = new RuleEventArgs();
            args.webTest = httpWebTest;
            args.requestItem = request;
            args.response = response;
            OnExtractionRule(args);
            request = args.requestItem;
        }

        public event EventHandler<RuleEventArgs> Extract;

        protected virtual void OnExtractionRule(RuleEventArgs e)
        {
            EventHandler<RuleEventArgs> handler = Extract;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion


        #region -- PostRequest Event -----
        private void HandlePostRequestEventProcessing(HttpResponseMessage response)
        {
            // Handle RequestRule_PostRequest items
            foreach (var rule in request.Rules.Where(r => r.RuleType == RuleType.RequestRule_PostRequest))
            {
                PostRequestRule postRequestRule = rule as PostRequestRule;
                PostRequest += postRequestRule.PostRequest;
                Log.ForContext("SourceContext", "RequestExecution").Debug("adding RequestRule_PostRequest {rule} for {request}", rule.Name, request.guid);
            }

            //// Handle TestRule_PostRequest
            //foreach (var rule in httpWebTest.Rules.Where(r => r.RuleType == RuleTypes_Enums.TestRule_PostRequest))
            //{
            //    PostRequestRule postRequestRule = rule as PostRequestRule;
            //    PostRequest += postRequestRule.PostRequest;
            //    Log.ForContext("SourceContext", "RequestExecution").Debug("adding TestRule_PostRequest {rule} for {request}", rule.Name, request.guid);
            //}
            FirePostRequestHandler(response);
        }

        public void FirePostRequestHandler(HttpResponseMessage response)
        {
            PostRequestEventArgs args = new PostRequestEventArgs();
            args.webTest = httpWebTest;
            args.requestItem = request;
            args.response = response;
            OnPostRequest(args);
            request = args.requestItem;
        }

        public event EventHandler<PostRequestEventArgs> PostRequest;

        protected virtual void OnPostRequest(PostRequestEventArgs e)
        {
            EventHandler<PostRequestEventArgs> handler = PostRequest;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
    }
}
