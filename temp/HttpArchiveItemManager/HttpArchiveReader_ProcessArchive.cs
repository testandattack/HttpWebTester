using Automatonic.HttpArchive;
using GTC.Utilities;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GTC_HttpArchiveReader
{
    public partial class HttpArchiveReader
    {
        public bool LoadArchive(string logFileToLoad)
        {
            bool archiveWasLoaded = false;
            using (StreamReader re = new StreamReader(logFileToLoad))
            {
                using (JsonTextReader reader = new JsonTextReader(re))
                {
                    try
                    {
                        JsonSerializer se = new JsonSerializer();
                        object parsedData = se.Deserialize(reader, typeof(Document));

                        archiveDocument = (Document)parsedData;
                        logMsg.Write(LoggingLevel.Summary, "the archive '{0}' was successfully loaded into memory.");
                        archiveWasLoaded = true;
                    }
                    catch (Exception ex)
                    {
                        logMsg.Write(LoggingLevel.Error, "Exception thrown in 'LoadArchive':\r\n{0}\r\n{1}", ex.Message, ex.InnerException.ToString());
                        archiveWasLoaded = false;
                    }
                }
            }
            return archiveWasLoaded;
        }

        public void BuildSortedListOfRequests()
        {
            if (archiveDocument == null)
            {
                logMsg.Write(LoggingLevel.Summary, "BuildSortedListOfRequests failed. Document object was NULL\r\n");
                return;
            }
            ProcessPagesInArchive();

            foreach (Entry entry in archiveDocument.Log.Entries)
                AddEntry(entry);

            logMsg.Write(LoggingLevel.Summary, "Conversion to SortedList complete.{0}", GetCountersAsString());
        }

        /// <summary>
        /// look for top level pages. If found, build a list of them for
        /// converting into Transaction Timers in the final webtest.
        /// </summary>
        private void ProcessPagesInArchive()
        {
            if (archiveDocument.Log.Pages == null)
            {
                logMsg.Write(LoggingLevel.Summary, "ProcessPagesInArchive: Pages element of the archive was NULL.");
                return;
            }

            foreach (Page page in archiveDocument.Log.Pages)
                mainPages.Add(page.StartedDateTime, page);

            if (mainPages.Count > 0)
            {
                logMsg.Write(LoggingLevel.Summary, "ProcessPagesInArchive found and processed {0} main level page requests.", mainPages.Count);
                ArchiveContainsPageInfo = true;
            }
            else
                logMsg.Write(LoggingLevel.Summary, "ProcessPagesInArchive: Did not find any main level page requests.");

        }

        private void AddEntry(Entry entry)
        {
            if (entry != null)
            {
                Request request = entry.Request;
                if (request != null)
                {
                    itemsProcessed++;
                    string requestUrl = request.Url.GetUrlWithoutQuery();

                    if (IgnoreRequest_EndsWith(requestUrl))
                        return;

                    if (IgnoreRequest_Contains(requestUrl))
                        return;

                    if (IgnoreRequest_ReferrerContains(request))
                        return;

                    try
                    {
                        int entryId = SortedEntries.Count + 1;
                        HttpArchiveObjectEx newEntry = new HttpArchiveObjectEx(entry, entryId);
                        newEntry.ResponseStatusGroup = newEntry.GetResponseStatusGroup(entry.Response.Status);
                        newEntry.parentPageId = Add_NonNull_ParentPageInfo(entry);
                        SortedEntry_SafeAdd(entry.StartedDateTime, newEntry);

                        HttpArchiveResponseObjectEx newResponse = new HttpArchiveResponseObjectEx(entry.Response, entryId);
                        Responses.Add(entryId, newResponse);
                    }
                    catch (Exception ex)
                    {
                        logMsg.Write(LoggingLevel.Error, "Exception thrown in 'AddEntry': Item = {0}\r\n{1}\r\n{2}", entry.Request.Url.GetUrlWithoutQuery(), ex.Message, ex.InnerException.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Looks for a collision in the DateTime Keys of the Sorted List. If a collision is
        /// detected, the routine adds one millisecond to the time and keeps trying until
        /// there is not a collision.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="entry"></param>
        private void SortedEntry_SafeAdd(DateTime dt, HttpArchiveObjectEx entry)
        {
            if(SortedEntries.ContainsKey(dt))
            {
                DateTime newDt = dt.AddMilliseconds(1);
                while (SortedEntries.ContainsKey(newDt))
                    newDt = newDt.AddMilliseconds(1);
                SortedEntries.Add(newDt, entry);
                entry.DetectedCollisionOnStartedDateTime = true;
            }
            else
                SortedEntries.Add(dt, entry);
        }

        /// <summary>
        /// This routine converts any NULL input values to String.Empty
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        private string Add_NonNull_ParentPageInfo(Entry entry)
        {
            if (entry.PageRef != null)
            {
                return entry.PageRef;
            }
            else
                return string.Empty;
        }
    }
}
