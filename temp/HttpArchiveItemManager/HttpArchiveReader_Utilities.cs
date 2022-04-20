using Automatonic.HttpArchive;
using GTC.Utilities;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GTC.Utilities.WebTestProcessing;
using System.Text.RegularExpressions;

namespace GTC_HttpArchiveReader
{
    public partial class HttpArchiveReader
    {
        public void ResetCounters()
        {
            itemsProcessed = 0;
            itemsAdded = 0;
            itemsIgnored = 0;
            PayloadsFound_String = 0;
            PayloadsFound_FormPost = 0;
            PayloadsFound_Total = 0;
        }

        private bool LogResponse(Entry entry)
        {
            Response response = entry.Response;
            logMsg.Write(LoggingLevel.Detailed, "Response = {0};\t{1}", response.Status, entry.Request.Url.GetUrlWithoutQuery());
            return true;
        }

        public void LogAllResponseErrors()
        {
            foreach (HttpArchiveObjectEx entry in SortedEntries.Values)
            {
                if (entry.ResponseStatusGroup != HttpStatusGroups.HttpStatusGood &&
                    entry.ResponseStatusGroup != HttpStatusGroups.HttpStatusRedirect)
                {
                    logMsg.Write(LoggingLevel.Summary, "ResponseError - item:{0}, Status:{1}, URL:{2}", entry.entryId, entry.entryEx.Response.Status,
                        entry.entryEx.Request.Url.GetUrlWithoutQuery());
                }
            }
        }

        public void SaveLogFile(string logFileName)
        {
            using (StreamWriter sw = new StreamWriter(logFileName, false))
            {
                sw.Write(logMsg.GetFinalLogAsString() + "\r\n" + GetAllResponseErrors());
            }
        }

        public int Get_StartedDateTime_CollisionCount()
        {
            int iCount = 0;

            foreach(HttpArchiveObjectEx obj in SortedEntries.Values)
            {
                if (obj.DetectedCollisionOnStartedDateTime)
                    iCount++;
            }
            return iCount;
        }

        private string GetUrlWithoutQuery(string sUrl)
        {
            int x = sUrl.IndexOf("?");
            if (x == -1)
                return sUrl.UrlDecode();
            else
                return sUrl.Substring(0, x).UrlDecode();
        }

        public string GetAllResponseErrors()
        {
            if (SortedEntries == null)
                return "Archive has not been built";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\r\nThere were {0} 'StartedDateTime' collisions building the archive\r\n", Get_StartedDateTime_CollisionCount());

            foreach (HttpArchiveObjectEx entry in SortedEntries.Values)
            {
                if (entry.ResponseStatusGroup != HttpStatusGroups.HttpStatusGood &&
                    entry.ResponseStatusGroup != HttpStatusGroups.HttpStatusRedirect)
                {
                    sb.AppendFormat("ResponseError - item:{0}, Status:{1}, URL:{2}\r\n", entry.entryId, entry.entryEx.Response.Status,
                        entry.entryEx.Request.Url.GetUrlWithoutQuery());
                }
            }

            return sb.ToString();
        }

        public void LogAllResponseContentData()
        {
            logMsg.Write(LoggingLevel.Detailed, "ID\tContent Size\tCompression\tHeader Size\tBody Size\tMimeType\tEncoding\tStatusCode\tText");
            foreach (KeyValuePair<int, HttpArchiveResponseObjectEx> kvp in Responses)
            {
                logMsg.Write(LoggingLevel.Detailed, "{0}", kvp.Value.GetResponseBodyStatisticsForTroubleshooting(128));
            }
        }

        public string GetAllResponseContentDataAsString(string Browser)
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendFormat("Browser\tID\tContent Size\tCompression\tHeader Size\tBody Size\tMimeType\tEncoding\tStatusCode\tText\r\n");
            foreach (KeyValuePair<int, HttpArchiveResponseObjectEx> kvp in Responses)
            {
                sb.AppendFormat("{0}\t{1}\r\n", Browser, kvp.Value.GetResponseBodyStatisticsForTroubleshooting(128));
            }
            return sb.ToString();
        }


        public string GetCountersAsString()
        {
            return string.Format(@"
        itemsProcessed: {0}
        itemsAdded: {1}
        itemsIgnored: {2}
        pagesIgnored: {3}
        ReferersIgnored: {4}
        PayloadsFound_String: {5}
        PayloadsFound_FormPost: {6}
        PayloadsFound_Total: {7}",
                itemsProcessed,
                itemsAdded,
                itemsIgnored,
                extensionsIgnored,
                ReferersIgnored,
                PayloadsFound_String,
                PayloadsFound_FormPost,
                PayloadsFound_Total);
        }

        /// <summary>
        /// strips the http or SSL pre-amble from the name AND
        /// removes querystring params, if present.
        /// </summary>
        /// <param name="sTitle"></param>
        /// <returns></returns>
        private string GetPageTitleWithoutNoise(string sTitle)
        {
            if (sTitle.GetUrlWithoutQuery().ToLower().StartsWith("http://"))
                return sTitle.GetUrlWithoutQuery().Substring(7);
            else if (sTitle.GetUrlWithoutQuery().ToLower().StartsWith("https://"))
                return sTitle.GetUrlWithoutQuery().Substring(8);
            else
                return sTitle.GetUrlWithoutQuery();
        }

        private bool IgnoreRequest_EndsWith(string sUrl)
        {
            foreach (string str in wtps.UnwantedPages)
            {
                if (sUrl.ToLower().EndsWith(str.ToLower()))
                {
                    logMsg.Write(LoggingLevel.Detailed, "Page Ignored: {0}", sUrl.GetUrlWithoutQuery());
                    extensionsIgnored++;
                    return true;
                }
            }
            return false;
        }

        private bool IgnoreRequest_Contains(string sUrl)
        {
            foreach (string str in wtps.UnwantedItems)
            {
                if (sUrl.ToLower().Contains(str.ToLower()))
                {
                    logMsg.Write(LoggingLevel.Detailed, "Request Ignored: {0}", sUrl.GetUrlWithoutQuery());
                    itemsIgnored++;
                    return true;
                }
            }
            return false;
        }

        private bool IgnoreRequest_ReferrerContains(Request request)
        {
            if (request.Headers.Count == 0)
                return false;

            foreach (string str in wtps.UnwantedReferers)
            {
                foreach (NamedValue kvp in request.Headers)
                {
                    if (kvp.Name == "Referer" && kvp.Value.Contains(str))
                    {
                        logMsg.Write(LoggingLevel.Detailed, "Referer Request Ignored: {0}", request.Url.GetUrlWithoutQuery());
                        ReferersIgnored++;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
