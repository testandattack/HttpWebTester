﻿using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebTestExecutionEngine
{
    public class RequestExecution
    {
        public RequestExecution() { }

        public RequestExecution(WTI_Request wTI_RequestObject)
        {
            request = wTI_RequestObject;
        }

        public WTI_Request request { get; set; }

        public void ProcessRequest()
        {
            // Handle PreRequest events
            PreRequestEventArgs args = new PreRequestEventArgs();
            args.requestItem = request;
            PreRequest(this, args);

            // Execute the request
            var response = ExecuteRequest(request).GetAwaiter().GetResult();

            // Handle PostRequest events
            RuleEventArgs ruleArgs = new RuleEventArgs();
            ruleArgs.requestItem = request;
            ruleArgs.response = response;

        }

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
        public void AddPostRequestHandler(HttpResponseMessage response)
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
