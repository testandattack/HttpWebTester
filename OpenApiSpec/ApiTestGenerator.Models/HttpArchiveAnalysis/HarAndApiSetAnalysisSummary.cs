using System.Collections.Generic;

namespace ApiTestGenerator.Models.HttpArchiveAnalysis
{
    public class HarAndApiSetAnalysisSummary
    {
        public int totalNumberOfUsableHarRequests { get; set; }
        
        public int totalNumberOfEndpoints { get; set; }
        
        public int totalNumberOfEndpointsWithUrlParameters { get; set; }

        public int totalNumberOfApiSetEntriesWithMatchingHarRequest { get; set; }

        public int totalNumberOfParameters { get; set; }

        public int totalNumberOfUniqueParameters { get; set; }

        public int totalNumberOfInvalidEntries { get; set; }

        public List<string> urlParameters { get; set; }
        
        public List<string> queryParameters { get; set; }

        //public List<string> parameterValues { get; set; }

        public HarAndApiSetAnalysisSummary()
        {
            totalNumberOfUsableHarRequests = 0;
            totalNumberOfEndpoints = 0;
            totalNumberOfEndpointsWithUrlParameters = 0;
            totalNumberOfApiSetEntriesWithMatchingHarRequest = 0;
            totalNumberOfParameters = 0;
            totalNumberOfUniqueParameters = 0;
            totalNumberOfInvalidEntries = 0;
            urlParameters = new List<string>();
            queryParameters = new List<string>();
            //parameterValues = new List<string>();
        }
    }
}
