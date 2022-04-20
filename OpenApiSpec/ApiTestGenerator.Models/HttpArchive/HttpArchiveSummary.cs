using Automatonic.HttpArchive;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Serilog;
using GTC.Extensions;

namespace ApiTestGenerator.Models.HttpArchive
{
    /// <summary>
    /// This class contains objects that summarize several 
    /// aspects of the <see cref="ParsedHttpArchive"/> class
    /// </summary>
    public class HttpArchiveSummary
    {
        #region -- Public Properties ---------------------------------------
        public HarStatistics harStatistics { get; set; }

        public SortedList<DateTime, EntryEx> Entries { get; set; }

        //public Dictionary<string, HarEntrySummary> requests { get; set; }
        
        public Dictionary<int, HarEntrySummary> Requests { get; set; }

        public Dictionary<double, string> SlowRequests { get; set; }

        [JsonIgnore]
        public Settings readerSettings { get; set; }
        #endregion

        #region -- Constructors -----
        public HttpArchiveSummary()
        {
            Initialize();
        }

        public HttpArchiveSummary(Settings settings)
        {
            readerSettings = settings;
            Initialize();
        }

        private void Initialize()
        {
            harStatistics = new HarStatistics();
            //requests = new Dictionary<string, HarEntrySummary>();
            Requests = new Dictionary<int, HarEntrySummary>();
            Entries = new SortedList<DateTime, EntryEx>();
            SlowRequests = new Dictionary<double, string>();
        }
        #endregion

        #region -- Public Methods -----
        public void BuildRequestSummary()
        {
            int currentEntryId = 0;
            foreach (var entry in Entries.Values)
            {
                if (entry.baseEntry.Request.Url.Contains("collins-ascentia-web") == false
                    || entry.baseEntry.Request.Method == "OPTIONS")
                    continue;

                currentEntryId++;
                HarEntrySummary summary = new HarEntrySummary(readerSettings.harFileProcessingSettings.IncludeFullHarInRequestsList);
                summary.StartedDateTime = entry.baseEntry.StartedDateTime;
                summary.StartTime = entry.baseEntry.StartedDateTime.ToString("hh:mm:ss");
                summary.UriPath = entry.baseEntry.Request.Url.GetLeftPart("?", false);
                summary.UriStem = summary.UriPath.Substring(summary.UriPath.IndexOf("/api/", StringComparison.CurrentCultureIgnoreCase));
                summary.Method = entry.baseEntry.Request.Method;
                summary.Version = entry.baseEntry.Request.HttpVersion;
                summary.Connection = entry.baseEntry.Connection ?? "NullConnection";
                summary.ResourceType = entry.baseEntry.ResourceType;
                if (entry.baseEntry.Request.QueryString != null)
                {
                    summary.queryString = GetQueryList(entry.baseEntry.Request.QueryString);
                }
                summary.Time_InMs = Convert.ToInt32(entry.baseEntry.Time);
                summary.requestBytes = entry.baseEntry.Request.HeadersSize + entry.baseEntry.Request.BodySize;
                summary.responseBytes = GetResponseSize(entry.baseEntry.Response);
                summary.responseStatus = entry.baseEntry.Response.Status;
                summary.RequestTimings = entry.baseEntry.Timings;
                summary.ResponseContent = entry.baseEntry.Response.Content;
                if(readerSettings.harFileProcessingSettings.EncodeResponseText == true)
                {
                    EncodeResponseText(summary.ResponseContent);
                }

                summary._includeEntriesInSummaryJson = readerSettings.harFileProcessingSettings.IncludeEntriesInSummaryJson;
                summary._includeResponseContentInSummaryJson = readerSettings.harFileProcessingSettings.IncludeResponseContentInSummaryJson;
                summary._includeTimingsInSummaryJson = readerSettings.harFileProcessingSettings.IncludeTimingsInSummaryJson;

                summary.RequestId = currentEntryId;
                //requests.Add($"{currentEntry}_{summary.Method} | {summary.UriPath}", summary);
                Requests.Add(currentEntryId, summary);

                if (summary.Time_InMs > readerSettings.harFileProcessingSettings.minimumMillisecondsForSlowPage)
                {
                    SlowRequests.Add(summary.Time_InMs, $"{summary.Method} | {summary.UriPath}");
                }
            }
        }

        public void BuildHarSummary(int pages, int processed, int ignored)
        {
            harStatistics.numPages = pages;
            harStatistics.numItemsProcessed = processed;
            harStatistics.numItemsIgnored = ignored;
            harStatistics.numItemsInEntriesList = Entries.Count;
            harStatistics.numItemsInRequestsList = Requests.Count;
            harStatistics.minimumMillisecondsForSlowPage_ValueUsed
                = readerSettings.harFileProcessingSettings.minimumMillisecondsForSlowPage;
        }

        /// <summary>
        /// Built in Json Serializer Attribute override
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeEntries()
        {
            return readerSettings.harFileProcessingSettings.IncludeEntriesInSummaryJson;
        }
        #endregion

        #region -- Read and Write methods -----
        public void SerializeAndSaveHttpArchiveSummary(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
                }
                Serilog.Log.ForContext<HttpArchiveSummary>().Information("SerializeAndSaveHttpArchiveSummary completed successfully");
            }
            catch (Exception ex)
            {
                Serilog.Log.ForContext<HttpArchiveSummary>().Error(ex, "[EXCEPTION] {callingMethod} failed.", "SerializeAndSaveHttpArchiveSummary");
            }
        }

        public static HttpArchiveSummary LoadHttpArchiveSummaryFromFile(string fileName)
        {
            HttpArchiveSummary httpArchiveSummary = null;
            using (StreamReader sr = new StreamReader(fileName))
            {
                httpArchiveSummary = JsonConvert.DeserializeObject<HttpArchiveSummary>(sr.ReadToEnd());
            }
            if (httpArchiveSummary == null)
            {
                Serilog.Log.ForContext<HttpArchiveSummary>().Error("LoadHttpArchiveSummaryFromFile failed to load the set from {fileName}", fileName);
                throw new NullReferenceException($"LoadHttpArchiveSummaryFromFile failed to load the set from {fileName}");
            }
            return httpArchiveSummary;
        }
        #endregion

        #region -- Private Methods -----
        private List<string> GetQueryList(IList<NamedValue> queries)
        {
            List<string> list = new List<string>();
            foreach (var query in queries)
            {
                list.Add(query.ToString());
            }
            return list;
        }

        private int GetResponseSize(Response response)
        {
            int totalSize = 0;
            if (response.BodySize != null)
            {
                totalSize = (int)response.BodySize;
            }
            if(response.HeadersSize != null)
            {
                totalSize += (int)response.HeadersSize;
            }
            return totalSize;
        }

        private void EncodeResponseText(Content content)
        {
            if(content.Text != null)
            {
                content.Text = content.Text.Base64Encode();
            }
        }
        #endregion
    }
}
