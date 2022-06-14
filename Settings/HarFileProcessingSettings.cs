using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace GTC.HttpWebTester.Settings
{
    public class HarFileProcessingSettings
    {
        public bool AddEndpointParsingDataFromHar { get; set; }

        public string HarFileName { get; set; }

        public bool processMultipleHarFiles { get; set; }

        public string HarFileFolderLocation { get; set; }

        public bool IncludeFullHarInRequestsList { get; set; }

        public bool IncludeResponseContentInSummaryJson { get; set; }

        public bool IncludeResponseTextInSummaryJson { get; set; }

        public bool IncludeTimingsInSummaryJson { get; set; }
        
        public bool IncludeEntriesInSummaryJson { get; set; }

        public bool SaveParsedHttpArchiveInsteadOfSummary { get; set; }

        public int minimumMillisecondsForSlowPage { get; set; }

        public bool EncodeResponseText { get; set; }

        public List<string> DomainsToInclude { get; set; }

        public List<string> UnwantedItems { get; set; }

        public List<string> UnwantedPages { get; set; }

        public List<string> UnwantedReferers { get; set; }

    }
}
