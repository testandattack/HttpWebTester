using ApiTestGenerator.Models.ApiAnalyzer;
using ApiTestGenerator.Models.HttpArchiveAnalysis;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApiTestGenerator.Models.WebLogs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <code>
    /// AppServiceHTTPLogs
    /// | where TimeGenerated > ago(7days)
    /// | where UserAgent !contains "Edge+Health+Probe"
    /// | where CsHost !contains ".scm.azurewebsites.net"
    /// | project TimeGenerated, CIp, CsMethod, CsHost, CsUriStem, ScStatus, ScBytes, TimeTaken
    /// | order by CIp, TimeGenerated
    /// </code>
    /// </remarks>
    public class WebLogAnalysis
    {
        #region -- Properties -----
        public WebLogSummary webLogSummary { get; set; }

        public WebLogAnalysisSettings webLogAnalysisSettings { get; set; }

        public Dictionary<string, ParameterizedRequestAndEndpointMatches> parameterizedRequestAndEndpointMatches { get; set; }
        
        public Dictionary<string, EndpointParsingData> nonParameterizedRequestAndEndpointMatches { get; set; }
        
        public Dictionary<string, EndpointParsingData> unUsedEndpoints { get; set; }

        public Dictionary<string, EndpointTimingInfo> slowEndpoints { get; set; }

        public Dictionary<int, WebLogEntry> requestsThatFailedEndpointMatching { get; set; }
        #endregion

        #region -- properties that are not serialized by default -----
        public Dictionary<int, WebLogEntry> requests { get; set; }

        public Dictionary<int, WebLogEntry> requestsNotCallingApi { get; set; }

        public Dictionary<int, EndpointParsingData> endpoints { get; set; }

        [JsonIgnore]
        public bool serializeRequests { get; set; }
        [JsonIgnore]
        public bool serializeEndpoints { get; set; }
        #endregion

        #region -- Constructors -----
        public WebLogAnalysis()
        {
            requests = new Dictionary<int, WebLogEntry>();
            requestsThatFailedEndpointMatching = new Dictionary<int, WebLogEntry>();
            requestsNotCallingApi = new Dictionary<int, WebLogEntry>();
            endpoints = new Dictionary<int, EndpointParsingData>();
            parameterizedRequestAndEndpointMatches = new Dictionary<string, ParameterizedRequestAndEndpointMatches>();
            nonParameterizedRequestAndEndpointMatches = new Dictionary<string, EndpointParsingData>();
            unUsedEndpoints = new Dictionary<string, EndpointParsingData>();
            slowEndpoints = new Dictionary<string, EndpointTimingInfo>();
            webLogSummary = new WebLogSummary();
            serializeRequests = false;
            serializeEndpoints = false;

        }
        #endregion

        #region -- Read and Write methods -----
        public void SerializeAndSaveWebLogAnalysis(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(JsonConvert.SerializeObject(this));
                }
                Log.ForContext<WebLogAnalysis>().Information("SerializeAndSaveWebLogAnalysis completed successfully");
            }
            catch (Exception ex)
            {
                Log.ForContext<WebLogAnalysis>().Error(ex, "[EXCEPTION] {callingMethod} failed.", "SerializeAndSaveWebLogAnalysis");
            }
        }

        public static WebLogAnalysis LoadWebLogAnalysisFromFile(string fileName)
        {
            WebLogAnalysis webLogAnalysis = null;
            using (StreamReader sr = new StreamReader(fileName))
            {
                webLogAnalysis = JsonConvert.DeserializeObject<WebLogAnalysis>(sr.ReadToEnd());
            }
            if (webLogAnalysis == null)
            {
                Log.ForContext<WebLogAnalysis>().Error("LoadWebLogAnalysisFromFile failed to load the set from {fileName}", fileName);
                throw new NullReferenceException($"LoadWebLogAnalysisFromFile failed to load the set from {fileName}");
            }
            return webLogAnalysis;
        }
        #endregion

        #region -- Json Conditional Overrides -----
        public bool ShouldSerializerequests()
        {
            return serializeRequests;
        }

        public bool ShouldSerializerequestsNotCallingApi()
        {
            return serializeRequests;
        }

        public bool ShouldSerializeendpoints()
        {
            return serializeEndpoints;
        }
        #endregion
    }
}
