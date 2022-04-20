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
        public void SaveNewWebtest(string fileName)
        {
            DeclarativeWebTestSerializer.Save(webtest, fileName);
            logMsg.Write(LoggingLevel.Summary, "webtest {0} saved");
        }

        public void BuildWebtest()
        {
            if (ArchiveContainsPageInfo)
                BuildTransactionTimers();

            foreach(HttpArchiveObjectEx obj in SortedEntries.Values)
                AddEntryToWebTest(obj);

            foreach(TransactionTimer tt in webTransactions.Values)
            {
                webtest.Items.Add(tt);
                webtest.Items.Add(new Comment(""));
            }

            ConfigureWebtestSettings();

            logMsg.Write(LoggingLevel.Summary, "Conversion to Webtest complete.{0}", GetCountersAsString());
        }

        private void BuildTransactionTimers()
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
            if (obj.parentPageId == String.Empty)   // No parent object, so we add this directly to the webtest
                webtest.Items.Add(CreateWebTestRequest(obj));

            else      // Had a parent page, so add it to the transaction timer associated with the parent.
                webTransactions[obj.entryEx.PageRef].Items.Add(CreateWebTestRequest(obj));

            itemsAdded++;
        }

        private WebTestRequest CreateWebTestRequest(HttpArchiveObjectEx obj)
        {
            Request request = obj.entryEx.Request;
            string requestUrl = obj.entryEx.Request.Url.GetUrlWithoutQuery();

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

        private void ConfigureWebtestSettings()
        {
            webtest.StopOnError = (wtps.globalSettings.setStopOnErrorToTrue) ? true : false;
            webtest.PreAuthenticate = (wtps.globalSettings.setPreAuthenticateToFalse) ? false : true;
        }
    }
}
