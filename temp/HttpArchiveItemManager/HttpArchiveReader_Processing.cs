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
        #region -- Build the Soted List -----------------------------------------------
        public void BuildSortedListOfRequests()
        {
            if (archiveDocument == null)
            {
                logMsg.Write(LoggingLevel.Summary, "Conversion to .webtest failed. Document object was NULL\r\n");
                return;
            }
            ProcessPagesInArchive();

            ProcessEntriesInArchive();
            logMsg.Write(LoggingLevel.Summary, "Conversion to SortedList complete.{0}", GetCountersAsString());
        }

        private void ProcessPagesInArchive()
        {
            if (archiveDocument.Log.Pages == null)
                return;

            foreach (Page page in archiveDocument.Log.Pages)
            {
                mainPages.Add(page.StartedDateTime, page);
            }
            if (mainPages.Count > 0)
            {
                ArchiveContainsPageInfo = true;
            }
        }

        private void ProcessEntriesInArchive()
        {
            foreach (Entry entry in archiveDocument.Log.Entries)
            {
                try
                {
                    AddEntry(entry);
                }
                catch (Exception ex)
                {
                    logMsg.Write(LoggingLevel.Error, "Exception thrown in 'BuildSortedListOfRequests' Entry {0}:\r\n{1}\r\n{2}", this.GetUrlWithoutQuery(entry.Request.Url), ex.Message, ex.InnerException.ToString());
                }
            }
        }

        private void AddEntry(Entry entry)
        {
            if (entry != null)
            {
                Request request = entry.Request;
                if (request != null)
                {
                    itemsProcessed++;
                    string requestUrl = GetUrlWithoutQuery(request.Url);

                    if (IgnoreRequest_EndsWith(requestUrl))
                    {
                        sb.AppendLine(logMsg.Write(LoggingLevel.Detailed, "Page Ignored: {0}", requestUrl));
                        pagesIgnored++;
                        return;
                    }

                    if (IgnoreRequest_Contains(requestUrl))
                    {
                        sb.AppendLine(logMsg.Write(LoggingLevel.Detailed, "Request Ignored: {0}", requestUrl));
                        itemsIgnored++;
                        return;
                    }

                    if (IgnoreRequest_ReferrerContains(request))
                    {
                        sb.AppendLine(logMsg.Write(LoggingLevel.Detailed, "Referer Request Ignored: {0}", requestUrl));
                        ReferersIgnored++;
                        return;
                    }
                    try
                    {
                        HttpArchiveObjectEx newEntry = new HttpArchiveObjectEx(entry, SortedEntries.Count + 1);
                        newEntry.ResponseStatusGroup = newEntry.GetResponseStatusGroup(entry.Response.Status);
                        newEntry.parentPageId = AddParentPageInfo(entry);
                        AddSortedEntry_Safe(entry.StartedDateTime, newEntry);
                    }
                    catch (Exception ex)
                    {
                        logMsg.Write(LoggingLevel.Error, "Exception thrown in 'AddEntry': Item = {0}\r\n{1}\r\n{2}", this.GetUrlWithoutQuery(entry.Request.Url), ex.Message, ex.InnerException.ToString());
                    }
                }
            }
        }

        private void AddSortedEntry_Safe(DateTime dt, HttpArchiveObjectEx entry)
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

        private string AddParentPageInfo(Entry entry)
        {
            if (entry.PageRef != null)
            {
                return entry.PageRef;
            }
            else
                return string.Empty;
        }
        #endregion

        #region -- Build the Webtest --------------------------------------------------
        public void BuildWebtest()
        {
            if (ArchiveContainsPageInfo)
                InitializeTransactionTimers();

            foreach(HttpArchiveObjectEx obj in SortedEntries.Values)
            {
                AddEntryToWebTest(obj);
            }
            foreach(TransactionTimer tt in webTransactions.Values)
            {
                webtest.Items.Add(tt);
                webtest.Items.Add(new Comment(""));
            }
            logMsg.Write(LoggingLevel.Summary, "Conversion to Webtest complete.{0}", GetCountersAsString());
        }

        private void InitializeTransactionTimers()
        {
            foreach(Page page in mainPages.Values)
            {
                TransactionTimer tt = new TransactionTimer();
                tt.Name = GetPageTitleWithoutNoise(page.Title);
                webTransactions.Add(page.Id, tt);
            }
        }

        private void AddEntryToWebTest(HttpArchiveObjectEx obj)
        {
            if (obj.parentPageId == String.Empty)
                webtest.Items.Add(CreateWebTestRequest(obj));
            else
                webTransactions[obj.entryEx.PageRef].Items.Add(CreateWebTestRequest(obj));
            itemsAdded++;
        }

        private WebTestRequest CreateWebTestRequest(HttpArchiveObjectEx obj)
        {
            Request request = obj.entryEx.Request;
            string requestUrl = GetUrlWithoutQuery(obj.entryEx.Request.Url);

            WebTestRequest wtRequest = new WebTestRequest(requestUrl);
            wtRequest.Method = request.Method;
            wtRequest.Version = request.HttpVersion;
            foreach (NamedValue kvp in request.Headers)
            {
                wtRequest.Headers.Add(kvp.Name, kvp.Value.UrlDecode());
            }
            foreach (NamedValue kvp in request.QueryString)
            {
                wtRequest.QueryStringParameters.Add(kvp.Name, kvp.Value.UrlDecode());
            }
            if (request.PostData != null)
            {
                PayloadsFound_Total++;
                ProcessRequestPayload(request.PostData, ref wtRequest);
            }
            return wtRequest;
        }

        private void ProcessRequestPayload(PostData postData, ref WebTestRequest req)
        {
            if(postData.Params != null && postData.Params.Count > 0)
            {
                FormPostHttpBody body = new FormPostHttpBody();
                foreach(NamedValue kvp in postData.Params)
                {
                    body.FormPostParameters.Add(kvp.Name, kvp.Value.UrlDecode());
                }
                req.Body = body;
                PayloadsFound_FormPost++;
            }
            else
            {
                StringHttpBody body = new StringHttpBody();
                body.BodyString = postData.Text.UrlDecode();
                body.ContentType = postData.MimeType;
                req.Body = body;
                PayloadsFound_String++;
            }
        }
        #endregion
    }
}
