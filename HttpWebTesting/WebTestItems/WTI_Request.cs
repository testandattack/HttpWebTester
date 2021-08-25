﻿using HttpWebTesting.Collections;
using HttpWebTesting.CoreObjects;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.
using GTC.Extensions;
using System.Net.Http.Headers;

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

        #region -- Properties -----
        /// <summary>
        /// The request object that gets executed by the <see cref="HttpClient"/>.
        /// </summary>
        [Browsable(false)]
        [JsonIgnore]
        public HttpRequestMessage requestItem { get; set; }

        //#region -- Properties that map to HttpRequestMessage -----
        //public HttpRequestHeaders HeaderCollection { get; set; }
        //public PropertyCollection QueryStringCollection { get; set; }
        //public HttpMethod Method { get; set; }
        //public string Url { get; set; }
        //public string Version { get; set; }
        //#endregion

        #region -- Public Properties -----
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

        ///// <summary>
        ///// If true, this flag tells the test engine to parse the response and attempt to execute all
        ///// the dependent requests that would normally be automatically executed by a browser making
        ///// the call for this request.
        ///// </summary>
        //[DisplayName("Parse Dependent Requests")]
        //[Description("")]
        //[Category("Behavior")]
        //[DefaultValue(true)]
        //public bool ParseDependentRequests { get; set; }

        /// <summary>
        /// If true, then the request will have all built in data binding occur BEFORE
        /// it executes any PreRequest event handlers.
        /// </summary>
        [DisplayName("Fire PreRequestHandlers After DataBinding")]
        [Description("If true, then the request will have all built in data binding occur BEFORE it executes any PreRequest event handlers.")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool FirePreRequestHandlersAfterDataBinding { get; set; }
        #endregion

        internal PropertyDisplayInfoCollection displayInfo;
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
            //HttpRequestToProperties();
        }

        private void InitializeObject()
        {
            ReportingName = string.Empty;
            ThinkTime = 0;
            RecordResults = true;
            FollowRedirects = true;
            //ParseDependentRequests = true;
            FirePreRequestHandlersAfterDataBinding = true;

            objectItemType = Enums.WebTestItemType.Wti_RequestObject;
            Enabled = true;
            guid = Guid.NewGuid();
            itemComment = string.Empty;
            Rules = new RuleCollection();
            displayInfo = new PropertyDisplayInfoCollection();
            displayInfo.AddAllItems(this, "Request Object");
        }
        #endregion

        //private void HttpRequestToProperties()
        //{
        //    if (requestItem.RequestUri == null)
        //        return;

        //    Url = requestItem.RequestUri.AbsolutePath;
        //    Version = requestItem.Version.ToString();
        //    Method = requestItem.Method;
        //    if(requestItem.RequestUri.Query != string.Empty)
        //    {
        //        QueryStringCollection.AddKeyValuePairs(requestItem.RequestUri.Query.GetQueryParameters());
        //    }
        //    HeaderCollection = requestItem.Headers;
        //}

        //private void PropertiesToHttpRequestMessage()
        //{

        //}
    }
}
