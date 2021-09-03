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
        public HttpResponseMessage response { get; set; }

        public ContextCollection contextCollection { get; set; }
        
        public bool HttpResponseMessageWasNull { get; set; }

        public WTRI_Request(WTI_Request originalRequest)
        {
            objectItemType = WebTestResultItemType.Wtri_RequestObject;
            webTestItem = (WTI_Request)originalRequest;
            HttpResponseMessageWasNull = false;
        }
    }
}
