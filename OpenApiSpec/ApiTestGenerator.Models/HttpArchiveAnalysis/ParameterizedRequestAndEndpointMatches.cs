using ApiTestGenerator.Models.ApiAnalyzer;
using System.Collections.Generic;


namespace ApiTestGenerator.Models.HttpArchiveAnalysis
{
    public class ParameterizedRequestAndEndpointMatches
    {
        public EndpointParsingData endpointParsingData { get; set; }

        public Dictionary<int, RequestWithParams> RequestsWithParams { get; set; }

        public List<string> invalidEntries { get; set; }

        public int numberOfInvalidEntries { get; set; }

        public ParameterizedRequestAndEndpointMatches()
        {
            endpointParsingData = new EndpointParsingData();
            RequestsWithParams = new Dictionary<int, RequestWithParams>();
            invalidEntries = new List<string>();
            numberOfInvalidEntries = 0;
        }

        public ParameterizedRequestAndEndpointMatches(EndpointParsingData data)
        {
            endpointParsingData = data;
            RequestsWithParams = new Dictionary<int, RequestWithParams>();
            invalidEntries = new List<string>();
            numberOfInvalidEntries = 0;
        }
    }
}
