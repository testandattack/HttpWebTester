using Automatonic.HttpArchive;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiTestGenerator.Models.HttpArchive
{
    /// <summary>
    /// Represents the summary of a single <see cref="Entry"/> item
    /// in the <see cref="HttpArchiveSummary"/> report.
    /// </summary>
    public class HarEntrySummary
    {
        #region -- Properties -----
        [JsonIgnore]
        public DateTime StartedDateTime { get; set; }

        public string StartTime { get; set; }

        public int RequestId { get; set; }

        public string UriPath { get; set; }
        
        public string UriStem { get; set; }

        public string Method { get; set; }

        public string Version { get; set; }

        public string Connection { get; set; }

        public string ResourceType { get; set; }

        public List<string> queryString { get; set; }

        public int Time_InMs { get; set; }

        public int requestBytes { get; set; }

        public int responseBytes { get; set; }

        public int responseStatus { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ApiEndpointRequestId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? endpointNameMatchWasExact { get; set; }

        #region -- Json Items that are serialized based on config settings -----
        public Content ResponseContent { get; set; }

        public Timings RequestTimings { get; set; }

        public Entry Entry { get; set; }

        [JsonIgnore]
        public bool _includeResponseContentInSummaryJson = true;
        [JsonIgnore]
        public bool _includeTimingsInSummaryJson = true;
        [JsonIgnore]
        public bool _includeEntriesInSummaryJson = false;
        #endregion
        #endregion

        #region -- Constructors -----
        public HarEntrySummary()
        {
            queryString = new List<string>();
            RequestId = -1;
        }

        public HarEntrySummary(bool serializeEntry)
        {
            queryString = new List<string>();
            _includeEntriesInSummaryJson = serializeEntry;
            RequestId = -1;
        }
        #endregion

        #region -- Methods -----
        public string AsString(string separator)
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}",
                separator,
                $"{Method}_{UriPath}",
                StartedDateTime,
                ResourceType,
                Time_InMs,
                requestBytes,
                responseBytes,
                responseStatus);
        }

        public static string GetStringHeaders(string separator)
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}",
                separator,
                "Uri",
                "StartedDateTime",
                "ResourceType",
                "Time_InMs",
                "requestBytes",
                "responseBytes",
                "responseStatus");
        }

        public string GetRequestName(bool includeId = false)
        {
            if (includeId)
                return $"{RequestId}_{Method} | {UriPath}";
            else
                return $"{Method} | {UriPath}";
        }
        #endregion

        /// <summary>
        /// Built in Json Serializer Attribute override
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeResponseContent()
        {
            return _includeResponseContentInSummaryJson;
        }

        public bool ShouldSerializeRequestTimings()
        {
            return _includeTimingsInSummaryJson;
        }

        public bool ShouldSerializeEntry()
        {
            return _includeEntriesInSummaryJson;
        }
    }
}
