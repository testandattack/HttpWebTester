using Automatonic.HttpArchive;
using GTC.Utilities;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GTC_HttpArchiveReader
{
    public partial class HttpArchiveReader
    {
        #region -- Failure Strings --------------------------------------------------
        private string Status100 = "100 Continue";
        private string Status200 = "200 OK";
        private string Status203 = "203 Non Authoratative Info";
        private string Status204 = "204 No Content";
        private string Status206 = "206 Partial Content";
        private string Status301 = "301 Moved Permanently";
        private string Status302 = "302 Found";
        private string Status304 = "304 Not Modified";
        private string Status307 = "307 Temporary Redirect";
        private string Status400 = "400 Bad Request";
        private string Status401 = "401 Unauthorized";
        private string Status403 = "403 Forbidden";
        private string Status404 = "404 Not Found";
        private string Status405 = "405  Method Not Allowed";
        private string Status407 = "407 Proxy Authentication Required";
        private string Status411 = "411 Length Required";
        private string Status500 = "500 Server Errors";
        private string Status501 = "501 Not Implemented";
        private string Status502 = "502 Bad Gateway";
        private string Status503 = "503 Service Unavailable";
        private string Status511 = "511 Network Authentication Required";
        #endregion

        private HttpStatusGroups HandleResponseStatuses(Entry entry, bool logStatusCodes)
        {
            switch (entry.Response.Status)
            {
                case 100:
                    return HttpStatusGroups.HttpStatusGood;
                case 200:
                    return HttpStatusGroups.HttpStatusGood;
                case 204:
                    return HttpStatusGroups.HttpStatusGood;
                case 206:
                    return HttpStatusGroups.HttpStatusGood;
                case 301:
                    return HttpStatusGroups.HttpStatusRedirect;
                case 302:
                    return HttpStatusGroups.HttpStatusRedirect;
                case 304:
                    return HttpStatusGroups.HttpStatusGood;
                case 307:
                    return HttpStatusGroups.HttpStatusRedirect;
                case 400:
                    return HttpStatusGroups.HttpStatusClientErrors;
                case 401:
                    return HttpStatusGroups.HttpStatusAuthFailures;
                case 403:
                    return HttpStatusGroups.HttpStatusAuthFailures;
                case 404:
                    return HttpStatusGroups.HttpStatusClientErrors;
                case 405:
                    return HttpStatusGroups.HttpStatusClientErrors;
                case 407:
                    return HttpStatusGroups.HttpStatusAuthFailures;
                case 411:
                    return HttpStatusGroups.HttpStatusClientErrors;
                case 500:
                    return HttpStatusGroups.HttpStatusServerErrors;
                case 501:
                    return HttpStatusGroups.HttpStatusServerErrors;
                case 502:
                    return HttpStatusGroups.HttpStatusServerErrors;
                case 503:
                    return HttpStatusGroups.HttpStatusServerErrors;
                case 511:
                    return HttpStatusGroups.HttpStatusAuthFailures;
                default:
                    return HttpStatusGroups.HttpStatusUnknown;
            }
        }
    }
}
