using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.CommonItems
{
    public abstract class RequestEntry
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ApiEndpointOperationId { get; set; }

        public DateTime RequestTime { get; set; }

        public string IpAddress { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Method { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Host { get; set; }

        public string UriStem { get; set; }

        public string GetRequestName()
        {
            if (Method != null)
                return $"{Method} | {UriStem}";
            else
                return $"UNKNOWN_METHOD | {UriStem}";
        }
    }
}
