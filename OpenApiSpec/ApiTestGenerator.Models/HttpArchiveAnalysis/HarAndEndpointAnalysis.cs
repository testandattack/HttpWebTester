using ApiTestGenerator.Models.ApiAnalyzer;
using ApiTestGenerator.Models.HttpArchive;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
//using Utilities;

namespace ApiTestGenerator.Models.HttpArchiveAnalysis
{
    public class HarAndEndpointAnalysis
    {
        #region -- Properties -----
        public HarAndApiSetAnalysisSummary harAndApiSetAnalysisSummary { get; set; }

        public Dictionary<int, EndpointParsingData> endpointParsingData { get; set; }

        public Dictionary<int, string> requestsWithoutUrlParams { get; set; }

        public Dictionary<string, ParameterizedRequestAndEndpointMatches> requestAndEndpointMatches { get; set; }

        public List<string> requestsWithoutEndpointMatch { get; set; }

        public Dictionary<string, CaseSensitivityMismatches> caseSensitivityPatternMismatches { get; set; }
        #endregion

        #region -- Constructors -----
        public HarAndEndpointAnalysis()
        {
            requestAndEndpointMatches = new Dictionary<string, ParameterizedRequestAndEndpointMatches>();
            endpointParsingData = new Dictionary<int, EndpointParsingData>();
            requestsWithoutEndpointMatch = new List<string>();
            requestsWithoutUrlParams = new Dictionary<int, string>();
            harAndApiSetAnalysisSummary = new HarAndApiSetAnalysisSummary();
            caseSensitivityPatternMismatches = new Dictionary<string, CaseSensitivityMismatches>();
        }
        #endregion

    }

}
