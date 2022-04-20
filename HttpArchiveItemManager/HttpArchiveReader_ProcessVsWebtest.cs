using Automatonic.HttpArchive;
using GTC.Extensions;
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
        public void SaveNewVsWebtest(string fileName)
        {
            DeclarativeWebTestSerializer.Save(webtest, fileName);
            logMsg.Write(LoggingLevel.Summary, "webtest {0} saved");
        }

        public void BuildVsWebtest()
        {
            if (ArchiveContainsPageInfo)
                BuildVsTransactionTimers();

            foreach (HttpArchiveObjectEx obj in SortedEntries.Values)
                AddEntryToVsWebTest(obj);

            foreach(TransactionTimer tt in vsWebTransactions.Values)
            {
                webtest.Items.Add(tt);
                webtest.Items.Add(new Comment(""));
            }

            ConfigureVsWebtestSettings();

            logMsg.Write(LoggingLevel.Summary, "Conversion to Webtest complete.{0}", GetCountersAsString());
        }

        private void BuildVsTransactionTimers()
        {
            foreach (Automatonic.HttpArchive.Page page in mainPages.Values)
            {
                TransactionTimer tt = new TransactionTimer();
                tt.Name = GetPageTitleWithoutNoise(page.Title);
                vsWebTransactions.Add(page.Id, tt);
            }
        }

        private void AddEntryToVsWebTest(HttpArchiveObjectEx obj)
        {
            var requestObj = CreateVsWebTestRequest(obj);
            if (requestObj == null)
                return;

            if (obj.parentPageId == String.Empty)   // No parent object, so we add this directly to the webtest
            {
                webtest.Items.Add(requestObj);
            }

            else      // Had a parent page, so add it to the transaction timer associated with the parent.
                vsWebTransactions[obj.entryEx.PageRef].Items.Add(requestObj);

            itemsAdded++;
        }

        private WebTestRequest CreateVsWebTestRequest(HttpArchiveObjectEx obj)
        {
            Automatonic.HttpArchive.Request request = obj.entryEx.Request;
            string requestUrl = obj.entryEx.Request.Url.GetUrlWithoutQuery();
            
            // Make sure this is not a request to ignore
            string pageType = $".{requestUrl.Substring(requestUrl.LastIndexOf("."))}";
            if (wtps.UnwantedItems.Contains(pageType))
            {
                return null;
            }

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
                ProcessVsRequestPayload(request.PostData, ref wtRequest);
            }

            return wtRequest;
        }

        private void ProcessVsRequestPayload(PostData postData, ref WebTestRequest req)
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

        private void ConfigureVsWebtestSettings()
        {
            webtest.StopOnError = (wtps.globalSettings.setStopOnErrorToTrue) ? true : false;
            webtest.PreAuthenticate = (wtps.globalSettings.setPreAuthenticateToFalse) ? false : true;
        }
    }
}
