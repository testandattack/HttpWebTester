using HttpWebTesting.Collections;
using System;
using System.Net.Http;

namespace HttpWebTesting.WebTestItems
{
    /// <summary>
    /// Represents a single <see cref="HttpRequestMessage"/> and all of the necessary testing items necessary to 
    /// modify and execute the request, capture result information, and extract any information needed for
    /// subsequent test requests.
    /// </summary>
    public class WTI_Request : WebTestItem
    {
        // The built in items (These items are all part of the System.Net.Http namespace
        //public System.Net.Http.HttpContent Content { get; set; }
        //public sealed class HttpRequestHeaders : System.Net.Http.Headers.HttpHeaders
        //public System.Net.Http.HttpMethod Method { get; set; }
        //public System.Collections.Generic.IDictionary<string,object> Properties { get; }
        //public Uri RequestUri { get; set; }
        //public Version Version { get; set; }
        

        /// <summary>
        /// The request object that gets executed by the <see cref="HttpClient"/>.
        /// </summary>
        public HttpRequestMessage requestItem { get; set; }

        /// <summary>
        /// a collection of rules to execute either before or after the request gets executed.
        /// </summary>
        public RuleCollection Rules { get; set; }

        /// <summary>
        /// The Reporting Name is a report friendly name for this request. If the value is empty, then
        /// the request's URL will be used for the reporting.
        /// </summary>
        public string ReportingName { get; set; }

        /// <summary>
        /// The amount of time (in seconds) to wait (after this request completes) before executing
        /// the next request in this test.
        /// </summary>
        public int ThinkTime { get; set; }

        /// <summary>
        /// Should the results of this request be recorded in the final test result set and report?
        /// </summary>
        /// <remarks>
        /// This flag allows you to tell the test results to ignore certain requests that may be 
        /// necessary to complete a test but are not important for tracking in the results files.
        /// For instance, OPTIONS calls to APIs are often needed, but not important to track.
        /// </remarks>
        public bool RecordResults { get; set; }

        /// <summary>
        /// If true, this flag tells the test engine to execute any redirects received from the request.
        /// </summary>
        public bool FollowRedirects { get; set; }

        /// <summary>
        /// If true, this flag tells the test engine to parse the response and attempt to execute all
        /// the dependent requests that would normally be automatically executed by a browser making
        /// the call for this request.
        /// </summary>
        public bool ParseDependentRequests { get; set; }

        #region -- Constructors -----
        /// <summary>
        /// Creates a new Request object.
        /// </summary>
        /// <remarks>
        /// The object is created with the following defaults
        /// <list type="bullet">
        /// <item>ReportingName = ""</item>
        /// <item>ThinkTime = 0</item>
        /// <item>RecordResults = true</item>
        /// <item>FollowRedirects = true</item>
        /// <item>ParseDependentRequests = true</item>
        /// </list>
        /// The 
        /// </remarks>
        public WTI_Request() 
        {
            InitializeObject();
            requestItem = new HttpRequestMessage();
        }

        public WTI_Request(HttpRequestMessage httpRequestMessage)
        {
            InitializeObject();
            requestItem = httpRequestMessage;
        }

        private void InitializeObject()
        {
            ReportingName = string.Empty;
            ThinkTime = 0;
            RecordResults = true;
            FollowRedirects = true;
            ParseDependentRequests = true;

            objectItemType = Enums.WebTestItemType.Wti_RequestObject;
            Enabled = true;
            guid = Guid.NewGuid();
            itemComment = string.Empty;
            Rules = new RuleCollection();
        }
        #endregion

    }
}
