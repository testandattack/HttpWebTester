using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace GTC.HttpWebTester.Settings
{
    public class WebLogAnalysisSettings
    {
        public int minimumNumRequestsForSlowEndpointProcessing { get; set; }

        public int minimumNumRequestsForPercentileProcessing { get; set; }

        public bool useNormal_StdDev { get; set; }

        public List<string> includeTheseStatusCodesForTimingAnalysis { get; set; }
    }
}
