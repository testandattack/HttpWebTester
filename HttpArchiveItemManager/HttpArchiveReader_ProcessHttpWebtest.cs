using Automatonic.HttpArchive;
using GTC.Extensions;
using GTC.Utilities;
using HttpWebTesting.WebTestItems;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using WebTestItemManager;

namespace GTC_HttpArchiveReader
{
    public partial class HttpArchiveReader
    {
        public void SaveNewWebtest(string fileName)
        {
            int iStart = fileName.LastIndexOf("\\") + 1;
            httpWebTest.Name = fileName.Substring(iStart);
            HttpWebTestSerializer.SerializeAndSaveTest(httpWebTest, fileName);
            logMsg.Write(LoggingLevel.Summary, "webtest {0} saved", fileName);
        }

        public void BuildWebtest()
        {
            if (ArchiveContainsPageInfo)
                BuildTransactionTimers();

            foreach (HttpArchiveObjectEx obj in SortedEntries.Values)
                AddEntryToWebTest(obj);

            foreach (WTI_Transaction tt in httpWebTransactions.Values)
            {
                httpWebTest.WebTestItems.Add(tt);
                httpWebTest.WebTestItems.Add(new WTI_Comment(""));
            }

            ConfigureWebtestSettings();

            logMsg.Write(LoggingLevel.Summary, "Conversion to Webtest complete.{0}", GetCountersAsString());
        }

        private void BuildTransactionTimers()
        {
            foreach (Automatonic.HttpArchive.Page page in mainPages.Values)
            {
                var trans = ItemManager.CreateNewTransaction(GetPageTitleWithoutNoise(page.Title));
                httpWebTransactions.Add(page.Id, trans);
            }
        }

        private void AddEntryToWebTest(HttpArchiveObjectEx obj)
        {
            var requestObj = CreateWebTestRequest(obj);
            if (requestObj == null)
                return;

            if (obj.parentPageId == String.Empty)   // No parent object, so we add this directly to the webtest
            {
                httpWebTest.WebTestItems.Add(requestObj);
            }

            else      // Had a parent page, so add it to the transaction timer associated with the parent.
                httpWebTransactions[obj.entryEx.PageRef].webTestItems.Add(requestObj);

            itemsAdded++;
        }

        private WTI_Request CreateWebTestRequest(HttpArchiveObjectEx obj)
        {
            Automatonic.HttpArchive.Request request = obj.entryEx.Request;
            string requestUrl = obj.entryEx.Request.Url.GetUrlWithoutQuery();

            // Make sure this is not a request to ignore
            string pageType = $".{requestUrl.Substring(requestUrl.LastIndexOf("."))}";
            if (wtps.UnwantedItems.Contains(pageType))
            {
                return null;
            }

            var wtRequest = ItemManager.CreateNewRequest(requestUrl);


            wtRequest.Method = GetMethodValue(request.Method);
            wtRequest.Version = GetVersionValue(request.HttpVersion);
            
            // Headers
            foreach (NamedValue kvp in request.Headers)
            {
                wtRequest.Headers.Add(kvp.Name, new string[] { kvp.Value.UrlDecode() });
            }
            
            // Query Params
            foreach (NamedValue kvp in request.QueryString)
            {
                wtRequest.QueryCollection.queryParams.Add(kvp.Name, kvp.Value.UrlDecode());
            }

            // Post Body
            if (request.PostData != null)
            {
                PayloadsFound_Total++;
                ProcessRequestPayload(request.PostData, ref wtRequest);
            }

            Automatonic.HttpArchive.Response response = obj.entryEx.Response;
            if(response.Content != null)
            {
                if (response.Content.Text != null)
                {
                    wtRequest.RecordedResponseBody = response.Content.Text;
                }
            }
            // Response Body (if present)

            return wtRequest;
        }

        private void ProcessRequestPayload(PostData postData, ref WTI_Request req)
        {
            if (postData.Params != null && postData.Params.Count > 0)
            {
                Dictionary<string, string> formPostParams = new Dictionary<string, string>();
                foreach (NamedValue kvp in postData.Params)
                {
                    formPostParams.Add(kvp.Name, kvp.Value.UrlDecode());
                }
                req.Content = new FormUrlEncodedContent(formPostParams);
                PayloadsFound_FormPost++;
            }
            else
            {
                req.Content = new StringContent(postData.Text.UrlDecode(), Encoding.UTF8, postData.MimeType);
                PayloadsFound_String++;
            }
        }

        private void ConfigureWebtestSettings()
        {
            // set test level properties
            httpWebTest.Description = "Web test for testing the execution engine.";
            httpWebTest.StopOnError = true;
            httpWebTest.SuppressAllCommentsInResults = true;

        }

        private HttpMethod GetMethodValue(string methodString)
        {
            switch (methodString.ToUpper())
            {
                case "DELETE":
                    return HttpMethod.Delete;
                case "GET":
                    return HttpMethod.Get;
                case "HEAD":
                    return HttpMethod.Head;
                case "OPTIONS":
                    return HttpMethod.Options;
                case "PATCH":
                    return HttpMethod.Patch;
                case "POST":
                    return HttpMethod.Post;
                case "PUT":
                    return HttpMethod.Put;
                case "TRACE":
                    return HttpMethod.Trace;
                default:
                    return HttpMethod.Get;
            }
        }

        private Version GetVersionValue(string versionString)
        {
            switch (versionString.ToLower())
            {
                case "1.0":
                    return HttpVersion.Version10;
                case "1.1":
                    return HttpVersion.Version11;
                case "http/2.0":
                    return HttpVersion.Version20;
                default:
                    return HttpVersion.Version10;
            }
        }
    }
}
