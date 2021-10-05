using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using HttpWebTesting.Collections;

namespace HttpWebTestingResults
{
    public class WTRI_Request : WebTestResultsItem
    {
        public string responseBody { get; set; }

        public HttpResponseMessage response { get; set; }

        public HttpRequestMessage RequestAsSent { get; set; }

        public ContextCollection contextCollection { get; set; }
        
        public bool HttpResponseMessageWasNull { get; set; }

        public TimeSpan ResponseTime { get; set; }

        public TimeSpan TotalExecutionTime { get; set; }

        public WTRI_Request(Guid itemGuid)
        {
            objectItemType = WebTestResultItemType.Wtri_RequestObject;
            webTestItemId = itemGuid;
            HttpResponseMessageWasNull = false;
            RequestAsSent = new HttpRequestMessage();
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    var request = webTestItemId as WTI_Request;
        //    // Format       XXXXXXXXXXXXXXXX
        //    sb.AppendLine($"Request         | {request.RequestUri}");
        //    sb.AppendLine($"        Method  | {request.Method}");
        //    sb.AppendLine($"    StatusCode  | {response.StatusCode}");
        //    sb.AppendLine($"  ResponseTime  | {ResponseTime.TotalSeconds}");
        //    return sb.ToString();
        //}
    }
}
