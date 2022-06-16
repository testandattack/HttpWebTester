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

        public bool AnalyzeApiEndpointsWithMultipleMethods { get; set; }

        public bool AnalyzeRequestBodies { get; set; }

        public bool AnalyzeApiComponents { get; set; }

        public bool AnalyzeInputParameters { get; set; }

        public bool AnalyzeProperties { get; set; }

        public bool AnalyzeLookupProperties { get; set; }

        public bool AnalyzeInputParametersNotInProperties { get; set; }

        public bool AnalyzeInputParametersNotInLookupProperties { get; set; }
    }
}
