using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.WebLogs
{
    public class WebLogSummary
    {
        public int CountOfTotalRequests { get; set; }
        public int CountOfRequestsNotCallingApi { get; set; }
        public int CountOfRequeststCallingApi { get; set; }
        public int CountOfOptionsRequests { get; set; }

        public Dictionary<string, int> UniqueIpAddresses { get; set; }
        public int UniqueIpAddressCount { get; set; }

        public Dictionary<string, int> UniqueStatusCodes { get; set; }
        public int UniqueStatusCodeCount { get; set; }

        public Dictionary<string, int> UniqueHosts { get; set; }
        public int UniqueHostCount { get; set; }

        public Dictionary<string, int> UniqueIpAddressesForRequestsNotCallingApi { get; set; }
        public Dictionary<string, int> UniqueUriStemsForRequestsNotCallingApi { get; set; }

        public int CountOfParameterizedEndpointsWithRequests { get; set; }
        public int CountOfNonParameterizedEndpointsWithRequests { get; set; }
        public int CountOfUnUsedEndpoints { get; set; }

        public WebLogSummary()
        {
            UniqueIpAddresses = new Dictionary<string, int>();
            UniqueStatusCodes = new Dictionary<string, int>();
            UniqueHosts = new Dictionary<string, int>();
            CountOfTotalRequests = 0;
            CountOfOptionsRequests = 0;

            UniqueIpAddressCount = 0;
            UniqueStatusCodeCount = 0;
            UniqueHostCount = 0;

            CountOfRequestsNotCallingApi = 0;
            UniqueIpAddressesForRequestsNotCallingApi = new Dictionary<string, int>();
            UniqueUriStemsForRequestsNotCallingApi = new Dictionary<string, int>();

            CountOfParameterizedEndpointsWithRequests = 0;
            CountOfNonParameterizedEndpointsWithRequests = 0;
            CountOfUnUsedEndpoints = 0;
        }
    }
}
