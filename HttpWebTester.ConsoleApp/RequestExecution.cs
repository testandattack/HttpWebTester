using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebTestExecutionEngine
{
    public class RequestExecution
    {
        #region -- Properties -----
        public WTI_Request request { get; set; }

        public HttpResponseMessage httpResponseMessage { get; set; }

        public string ResponseAsString = string.Empty;
        #endregion

        #region -- Constructors -----
        public RequestExecution() { }

        public RequestExecution(WTI_Request wTI_RequestObject)
        {
            request = wTI_RequestObject;
        }
        #endregion

        #region Public Methods -----
        public void ProcessRequest()
        {

            // Execute the request
            var response = ExecuteRequest(request).GetAwaiter().GetResult();
            if (response != null)
            {
                httpResponseMessage = response;
                ResponseAsString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                // Handle PostRequest events
                foreach (var rule in request.Rules)
                {
                    if (rule.RuleType == RuleTypes_Enums.RequestRule_Validation)
                    {
                        ValidationRule validationRule = rule as ValidationRule;
                        PostRequest += validationRule.PostRequest;
                        FirePostRequestHandler(response);
                    }
                }
            }
        }
        #endregion

        #region -- PreRequest Event -----
        public void AddPreRequestHandler()
        {
            PreRequestEventArgs args = new PreRequestEventArgs();
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

        #region -- PostRequest Event -----
        public void FirePostRequestHandler(HttpResponseMessage response)
        {
            PostRequestEventArgs args = new PostRequestEventArgs();
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

        #region -- Rule Event -----
        public void AddRuleHandler(HttpResponseMessage response)
        {
            RuleEventArgs args = new RuleEventArgs();
            args.requestItem = request;
            args.response = response;
            OnRule(args);
            request = args.requestItem;
        }
        public event EventHandler<RuleEventArgs> RuleEvent;
        protected virtual void OnRule(RuleEventArgs e)
        {
            EventHandler<RuleEventArgs> handler = RuleEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region -- Request Execution -----
        public static async Task<HttpResponseMessage> ExecuteRequest(WTI_Request request)
        {
            HttpClient client = new HttpClient();
            var httpResponse = client.SendAsync(GetHttpRequestMessage(request));
            return await httpResponse;
        }

        private static HttpRequestMessage GetHttpRequestMessage(WTI_Request request)
        {
            // This is where you apply any necessary changes to the actual request.
            return request.requestItem;
        }
        #endregion
    }


}
