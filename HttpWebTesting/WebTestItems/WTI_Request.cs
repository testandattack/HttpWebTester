using HttpWebTesting.Collections;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GTC.HttpUtilities;

namespace HttpWebTesting.WebTestItems
{
    /// <summary>
    /// Represents a single <see cref="HttpRequestMessage"/> and all of the necessary testing items necessary to 
    /// modify and execute the request, capture result information, and extract any information needed for
    /// subsequent test requests.
    /// </summary>
    public class WTI_Request : WebTestItem
    {
        #region -- Core Request Properties -----
        // The built in items (These items are all part of the System.Net.Http namespace
        //public System.Net.Http.HttpContent Content { get; set; }
        //public sealed class HttpRequestHeaders : System.Net.Http.Headers.HttpHeaders
        //public System.Net.Http.HttpMethod Method { get; set; }
        //public System.Collections.Generic.IDictionary<string,object> Properties { get; }
        //public Uri RequestUri { get; set; }
        //public Version Version { get; set; }

        /// <summary>
        /// <see cref="HttpRequestMessage.Content"/>
        /// </summary>
        public HttpContent Content { get; set; }

        /// <summary>
        /// <see cref="HttpRequestMessage.Headers"/>
        /// </summary>
        public Dictionary<string, IEnumerable<string>> Headers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public QueryCollection QueryCollection { get; set; }

        /// <summary>
        /// <see cref="HttpRequestMessage.Method"/>
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// <see cref="HttpRequestMessage.Properties"/>
        /// </summary>
        public Dictionary<string, object> Properties { get; }

        /// <summary>
        /// <see cref="HttpRequestMessage.RequestUri"/>
        /// </summary>
        public string RequestUri { get; set; }

        /// <summary>
        /// <see cref="HttpRequestMessage.Version"/>
        /// </summary>
        public Version Version { get; set; }
        #endregion

        #region -- Properties -----
        /// <summary>
        /// The request object that gets executed by the <see cref="HttpClient"/>.
        /// </summary>
        [Browsable(false)]
        [JsonIgnore]
        public HttpRequestMessage requestItem { get; set; }

        // NOTE: Consider making this a custom class that handles all of the back and forth with the Content object
        [JsonIgnore]
        public Dictionary<string, string> FormPostParams 
        { 
            get
            {
                if (Content == null)
                    return null;

                if (Content.GetType() != typeof(FormUrlEncodedContent))
                    return new Dictionary<string, string>();
                else 
                    return (Content as FormUrlEncodedContent).GetFormPostParamsFromContent();
            }
            set
            {
                Content = new FormUrlEncodedContent(value);
            }
        }

        /// <summary>
        /// a collection of rules to execute either before or after the request gets executed.
        /// </summary>
        [Browsable(false)]
        public RuleCollection Rules { get; set; }

        /// <summary>
        /// The Reporting Name is a report friendly name for this request. If the value is empty, then
        /// the request's URL will be used for the reporting.
        /// </summary>
        [DisplayName("Reporting Name")]
        [Description("a report friendly name for this request.")]
        [Category("General")]
        [DefaultValue("empty")]
        public string ReportingName { get; set; }

        /// <summary>
        /// The amount of time (in seconds) to wait (after this request completes) before executing
        /// the next request in this test.
        /// </summary>
        [DisplayName("Think Time")]
        [Description("The amount of time (in seconds) to wait (or \"think\") after this request completes.")]
        [Category("General")]
        [DefaultValue(3)]
        public int ThinkTime { get; set; }

        /// <summary>
        /// Should the results of this request be recorded in the final test result set and report?
        /// </summary>
        /// <remarks>
        /// This flag allows you to tell the test results to ignore certain requests that may be 
        /// necessary to complete a test but are not important for tracking in the results files.
        /// For instance, OPTIONS calls to APIs are often needed, but not important to track.
        /// </remarks>
        [DisplayName("Record Results")]
        [Description("Should the results of this request be recorded in the final test result set and report")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool RecordResults { get; set; }

        /// <summary>
        /// If true, this flag tells the test engine to execute any redirects received from the request.
        /// </summary>
        [DisplayName("Follow Redirects")]
        [Description("If true, this flag tells the test engine to execute any redirects received from the request.")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool FollowRedirects { get; set; }

        public string RecordedResponseBody { get; set; }
        #endregion

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
        /// </list>
        /// </remarks>
        [JsonConstructor]
        public WTI_Request(string url, HttpMethod method) 
        {
            Method = method;
            RequestUri = url;
            InitializeObject();
        }

        public WTI_Request(Uri uri, HttpMethod method)
        {
            Method = method;
            RequestUri = uri.AbsoluteUri.ToString();
            InitializeObject();
        }

        private void InitializeObject()
        {
            Headers = new Dictionary<string, IEnumerable<string>>();
            Version = new Version("1.1");
            Content = null;

            ReportingName = string.Empty;
            ThinkTime = 0;
            RecordResults = true;
            FollowRedirects = true;

            objectItemType = Enums.WebTestItemType.Wti_RequestObject;
            Enabled = true;
            guid = Guid.NewGuid();
            itemComment = string.Empty;
            Rules = new RuleCollection();
            QueryCollection = new QueryCollection();
        }
        #endregion

    }
}
