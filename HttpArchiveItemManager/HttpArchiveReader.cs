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
using HttpWebTesting;
using HttpWebTesting.WebTestItems;

namespace GTC_HttpArchiveReader
{
    public partial class HttpArchiveReader
    {
        #region -- Public Properties ---------------------------------------
        public Document archiveDocument { get; set; }
        public mLogMsg logMsg { get; internal set; }
        public DeclarativeWebTest webtest { get; private set; }
        public HttpWebTest httpWebTest { get; set; }

        public SortedList<DateTime, HttpArchiveObjectEx> SortedEntries { get; set; }
        public Dictionary<int, HttpArchiveResponseObjectEx> Responses { get; set; }
        public SortedList<DateTime, Page> mainPages { get; set; }
        public Dictionary<string, TransactionTimer> vsWebTransactions { get; set; }
        public Dictionary<string, WTI_Transaction> httpWebTransactions { get; set; }
        #endregion

        #region -- Private Properties --------------------------------------
        private int itemsProcessed = 0;
        private int itemsAdded = 0;
        private int itemsIgnored = 0;
        private int extensionsIgnored = 0;
        private int ReferersIgnored = 0;
        private int PayloadsFound_String = 0;
        private int PayloadsFound_FormPost = 0;
        private int PayloadsFound_Total = 0;
        private WebTestProcessingSettings wtps;
        private string RecordedValueRegex = "Value=\".+?\" RecordedValue=\"\"";

        private bool ArchiveContainsPageInfo = false;
        #endregion

        #region -- Constructors --------------------------------------------
        public HttpArchiveReader()
        {
            ConstructorItems();
            logMsg = new mLogMsg();
            logMsg.globalLevel = LoggingLevel.Summary;
        }

        public HttpArchiveReader(LoggingLevel loggingLevel)
        {
            ConstructorItems();
            logMsg = new mLogMsg();
            logMsg.globalLevel = loggingLevel;
        }

        public HttpArchiveReader(mLogMsg log, LoggingLevel loggingLevel)
        {
            ConstructorItems();
            logMsg = log;
            logMsg.globalLevel = loggingLevel;
        }

        private void ConstructorItems()
        {
            wtps = LoadWebTestProcessingSettings.LoadRecorderSettings("WebTestProcessingSettings.xml");
            webtest = new DeclarativeWebTest();
            httpWebTest = new HttpWebTest();
            mainPages = new SortedList<DateTime, Page>();
            SortedEntries = new SortedList<DateTime, HttpArchiveObjectEx>();
            vsWebTransactions = new Dictionary<string, TransactionTimer>();
            httpWebTransactions = new Dictionary<string, WTI_Transaction>();
            Responses = new Dictionary<int, HttpArchiveResponseObjectEx>();
        }
        #endregion
    }

    public enum HttpStatusGroups
    {
        HttpStatusAuthFailures = 1,  // 401, 403, 407, 511
        HttpStatusClientErrors = 2,  // 400, 404, 405, 411
        HttpStatusServerErrors = 3,  // 500, 501, 502, 503
        HttpStatusRedirect = 4,      // 301, 302, 307
        HttpStatusGood = 5,          // 100, 200, 204, 206, 304
        HttpStatusZero = 6,          // 0
        HttpStatusUnknown
    }
}
