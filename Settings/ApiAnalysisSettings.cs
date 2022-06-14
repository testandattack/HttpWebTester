using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace GTC.HttpWebTester.Settings
{
    public class ApiAnalysisSettings
    {
        public bool AnalyzeApiEndpoints { get; set; }

        public bool AnalyzeRequestBodies { get; set; }

        public bool AnalyzeApiComponents { get; set; }

        public bool AnalyzeInputParameters { get; set; }

        public bool AnalyzeEndPointRestrictions { get; set; }

        public bool AnalyzeEndpointRestrictionSummary { get; set; }

        public bool AnalyzeProperties { get; set; }

        public bool AnalyzeLookupProperties { get; set; }

        public bool AnalyzeInputParametersNotInProperties { get; set; }

        public bool AnalyzeInputParametersNotInLookupProperties { get; set; }

        public bool AddEndpointParsingData { get; set; }

        public bool IncludeOnlyEndpointSummariesWithMatchingRequests { get; set; }
    }
}
