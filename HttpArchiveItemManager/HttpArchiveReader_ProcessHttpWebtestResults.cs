using Automatonic.HttpArchive;
using GTC.Extensions;
using GTC.Utilities;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
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
        public void SaveNewWebtestResults(string fileName)
        {
            int iStart = fileName.LastIndexOf("\\") + 1;
            httpWebTest.Name = fileName.Substring(iStart);
            httpWebTestResults.SaveTestResults(fileName);
            logMsg.Write(LoggingLevel.Summary, "webtest {0} saved", fileName);
        }

        public void BuildWebtestResults()
        {
            if (ArchiveContainsPageInfo)
                BuildTransactionTimerResults();

            foreach (HttpArchiveObjectEx obj in SortedEntries.Values)
                AddEntryToWebTestResults(obj);

            foreach (WTRI_Transaction tt in httpWebTransactionResults.Values)
            {
                httpWebTestResults.webTestResultsItems.Add(tt);
                httpWebTestResults.webTestResultsItems.Add(new WTRI_Comment(new Guid()));
            }

            ConfigureWebtestSettings();

            logMsg.Write(LoggingLevel.Summary, "Conversion to Webtest complete.{0}", GetCountersAsString());
        }

        private void BuildTransactionTimerResults()
        {
            foreach (Automatonic.HttpArchive.Page page in mainPages.Values)
            {
                var trans = WebTestResultsItemManager.CreateNewTransactionResults($"PageGroup #{page.Id}");
                httpWebTransactionResults.Add(page.Id, trans);
            }
        }

        private void AddEntryToWebTestResults(HttpArchiveObjectEx obj)
        {
            // First, get the request as it appears in the HAR file.
            var requestObj = CreateWebTestRequest(obj);
            if (requestObj == null)
                return;

            // Next add it to a WTRI object
            WTRI_Request response = BuildWebTestResultsEntry(obj, requestObj);
            
            // Finally, add it to the right place in the overall collection
            if (obj.parentPageId == String.Empty)   // No parent object, so we add this directly to the webtest
                httpWebTestResults.webTestResultsItems.Add(response);
            else      // Had a parent page, so add it to the transaction timer associated with the parent.
                httpWebTransactionResults[obj.entryEx.PageRef].webTestResultsItems.Add(response);

            itemsAdded++;
        }

        private static WTRI_Request BuildWebTestResultsEntry(HttpArchiveObjectEx obj, WTI_Request requestObj)
        {
            var response = WebTestResultsItemManager.CreateNewRequestResult(requestObj);
            // Get total request/response time (stored in milliseconds)
            var totalTime =
                obj.entryEx.Timings.Blocked ?? 0 +
                obj.entryEx.Timings.Connect ?? 0 +
                obj.entryEx.Timings.Dns ?? 0 +
                obj.entryEx.Timings.Receive ?? 0 +
                obj.entryEx.Timings.Send ?? 0 +
                obj.entryEx.Timings.Ssl ?? 0;
            response.ResponseTime = TimeSpan.FromMilliseconds(totalTime);


            // Headers
            foreach (NamedValue kvp in obj.entryEx.Request.Headers)
            {
                response.responseHeaders.Add(kvp.Name, new string[] { kvp.Value.UrlDecode() });
            }

            // Response (if present)
            Automatonic.HttpArchive.Response harResponse = obj.entryEx.Response;
            if (harResponse.Status == 302)
            {
                response.redirectUrl = harResponse.RedirectUrl;
            }

            if (harResponse.Content != null)
            {
                if (harResponse.Content.Text != null)
                {
                    response.responseBody = harResponse.Content.Text;
                }
            }

            return response;
        }
    }
}
