using Automatonic.HttpArchive;
using GTC.Utilities;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GTC.Utilities.WebTestProcessing;
using System.Text.RegularExpressions;
using System;

namespace GTC_HttpArchiveReader
{
    public class HttpArchiveObjectEx
    {
        #region -- Public Properties ---------------------------------------
        public int entryId { get; set; }
        public string parentPageId { get; set; }
        public HttpStatusGroups ResponseStatusGroup { get; set; }
        public Entry entryEx { get; set; }

        public bool DetectedCollisionOnStartedDateTime = false;
        #endregion

        #region -- Constructors --------------------------------------------
        public HttpArchiveObjectEx()
        {
            entryEx = new Entry();
            entryId = -1;
        }

        public HttpArchiveObjectEx(Entry entry)
        {
            entryEx = entry;
            entryId = -1;
            parentPageId = string.Empty;
        }

        public HttpArchiveObjectEx(Entry entry, int id)
        {
            entryEx = entry;
            entryId = id;
            parentPageId = string.Empty;
        }

        public HttpArchiveObjectEx(Entry entry, int id, int Status)
        {
            entryEx = entry;
            entryId = id;
            parentPageId = string.Empty;
        }
        #endregion

        #region -- Public Methods ------------------------------------------
        public HttpStatusGroups GetResponseStatusGroup(int Status)
        {
            switch (Status)
            {
                case 100:
                case 200:
                case 204:
                case 206:
                case 304:
                    return HttpStatusGroups.HttpStatusGood;

                case 301:
                case 302:
                case 307:
                    return HttpStatusGroups.HttpStatusRedirect;

                case 401:
                case 403:
                case 407:
                case 511:
                    return HttpStatusGroups.HttpStatusAuthFailures;

                case 400:
                case 404:
                case 405:
                case 411:
                case 500:
                case 501:
                case 502:
                case 503:
                    return HttpStatusGroups.HttpStatusServerErrors;

                case 0:
                    return HttpStatusGroups.HttpStatusZero;

                default:
                    return HttpStatusGroups.HttpStatusUnknown;
            }
        }
        #endregion
    }
}
