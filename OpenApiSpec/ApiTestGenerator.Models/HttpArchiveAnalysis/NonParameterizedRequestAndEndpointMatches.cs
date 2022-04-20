using ApiTestGenerator.Models.ApiAnalyzer;
using System.Collections.Generic;


namespace ApiTestGenerator.Models.HttpArchiveAnalysis
{
    public class NonParameterizedRequestAndEndpointMatches
    {
        public EndpointParsingData endpointParsingData { get; set; }

        public Dictionary<int, string> RequestsWithoutParams { get; set; }

        public NonParameterizedRequestAndEndpointMatches()
        {
            endpointParsingData = new EndpointParsingData();
            RequestsWithoutParams = new Dictionary<int, string>();
        }

        public NonParameterizedRequestAndEndpointMatches(EndpointParsingData data, Dictionary<int, string> requests)
        {
            endpointParsingData = data;
            RequestsWithoutParams = requests;
        }
    }
}
