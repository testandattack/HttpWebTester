using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    public class Response
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("originalRequest")]
        public Request OriginalRequest { get; set; }

        /// <summary>
        /// 
        /// NOTE: Type = oneOf
        /// </summary>
        [JsonProperty("responseTime")]
        public string a { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timings", NullValueHandling = NullValueHandling.Ignore)]
        public object Timings { get; set; }

        /// <summary>
        /// 
        /// NOTE: Type = oneOf
        /// </summary>
        [JsonProperty("header")]
        public List<Header> Headers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cookie")]
        public List<Cookie> Cookies { get; set; }

        /// <summary>
        /// The raw text of the response
        /// </summary>
        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        /// <summary>
        /// The response status, e.g: '200 OK'
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The numerical response code, example: 200, 201, 404, etc.
        /// </summary>
        [JsonProperty("code")]
        public Int32 Code { get; set; }
    }
}
}
