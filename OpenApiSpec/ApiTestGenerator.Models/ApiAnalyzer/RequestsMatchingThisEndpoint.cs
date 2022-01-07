using ApiTestGenerator.Models.WebLogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiAnalyzer
{
    public class RequestsMatchingThisEndpoint
    {
        /// <summary>
        /// If the ApiSetAnalysis is executed with HttpArchive log files, this
        /// list will contain the har requests that call this endpoint.
        /// </summary>
        public List<int> requestList { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? NumRequestsUsingThisEndpoint { get; set; }

        #region -- Timing Info -----
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MinResponseTime { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? AvgResponseTime { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxResponseTime { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? StdDeviation_Time { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Median_ResponseTime { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? Pct_Variance_Time { get; set; }

        #endregion

        #region -- Payload Info -----
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MinResponseSize { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? AvgResponseSize { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxResponseSize { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? StdDeviation_Size { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Median_ResponseSize { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? Pct_Variance_Size { get; set; }
        #endregion

        public RequestsMatchingThisEndpoint()
        {
            requestList = new List<int>();
        }
    }
}
