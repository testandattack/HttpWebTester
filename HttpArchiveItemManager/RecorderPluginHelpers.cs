using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace GTC.Utilities
{
    public static class RecorderPluginHelpers
    {
        public static bool RequestOrRedirectContainsUrl(WebTestResultPage page, string sUrl)
        {
            if (page.RequestResult.Request.Url.Contains(sUrl))
                return true;

            foreach (WebTestResultPage redirectedPage in page.RedirectedPages)
            {
                if (redirectedPage.RequestResult.Request.Url.Contains(sUrl))
                    return true;
            }
            return false;
        }

        public static bool ResponseContainsString(WebTestResultPage page, string searchPhrase)
        {
            return ResponseContainsString(page, searchPhrase, true);
        }

        public static bool ResponseContainsString(WebTestResultPage page, string searchPhrase, bool AlsoSearchInRedirects)
        {
            string sResponse = GetResponseBodyAsString(page);
            if (sResponse == String.Empty)
                return false;
            else if (sResponse.Contains(searchPhrase))
                return true;
            else if (AlsoSearchInRedirects && sResponse.Contains("Web Test Recorder detected redirect to"))
            {
                foreach (var result in page.RedirectedPages)
                {
                    if (ResponseContainsString(result, searchPhrase, true)) ;
                    return true;
                }
                return false;
            }
            else
                return false;

        }

        private static string GetResponseBodyAsString(WebTestResultPage page)
        {
            if (page.RequestResult.Response.IsBodyEmpty)
                return String.Empty;

            if (page.RequestResult.Response.IsHtml
                || page.RequestResult.Response.IsText
                || page.RequestResult.Response.IsXml)
                return page.RequestResult.Response.BodyString;
            else
                return System.Text.Encoding.UTF8.GetString(page.RequestResult.Response.BodyBytes);

        }

        private static string GetResponseBodyAsString(WebTestResultPage page, bool UrlDecode)
        {
            if (page.RequestResult.Response.IsBodyEmpty)
                return String.Empty;

            if (page.RequestResult.Response.IsHtml
                || page.RequestResult.Response.IsText
                || page.RequestResult.Response.IsXml)
                return page.RequestResult.Response.BodyString;
            else
                return System.Text.Encoding.UTF8.GetString(page.RequestResult.Response.BodyBytes);

        }
    }
}
