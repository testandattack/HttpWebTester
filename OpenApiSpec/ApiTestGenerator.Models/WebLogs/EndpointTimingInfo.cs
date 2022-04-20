using ApiTestGenerator.Models.ApiAnalyzer;
using ApiTestGenerator.Models.HttpArchiveAnalysis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.WebLogs
{
    public class EndpointTimingInfo
    {

        public int Id { get; set; }
        public string Method { get; set; }
        public string uriStem { get; set; }
        public int minTime { get; set; }
        public int avgTime { get; set; }
        public int maxTime { get; set; }
        public int count { get; set; }

        public EndpointTimingInfo() { }

        public EndpointTimingInfo(int id, string method, string uri, int min, int avg, int max, int qty)
        {
            Id = id;
            Method = method;
            uriStem = uri;
            minTime = min;
            avgTime = avg;
            maxTime = max;
            count = qty;
        }
    }
}
