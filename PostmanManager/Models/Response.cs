using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PostmanManager.Models
{
    /// <summary>
    /// A response represents an HTTP response.
    /// </summary>
    [JsonObject(Title = "response")]
    public class Response
    {

        /// <summary>
        /// A unique, user defined identifier that can  be used to 
        /// refer to this response from requests.
        /// </summary>
        [JsonProperty("name")]
        public string Id { get; set; }

        /// <summary>
        /// <see cref="Request"/>
        /// </summary>
        [JsonProperty("originalRequest")]
        public Request OriginalRequest { get; set; }

        /// <summary>
        /// The time taken by the request to complete. If a number, the '
        /// unit is milliseconds. If the response is manually created, 
        /// this can be set to `null`.
        /// </summary>
        [JsonProperty("responseTime")]
        [JsonConverter(typeof(StringOrNumberConverter))]
        public StringOrNumber ResponseTime { get; set; }

        /// <summary>
        /// Set of timing information related to request and response in milliseconds
        /// </summary>
        [JsonProperty("timings", NullValueHandling = NullValueHandling.Ignore)]
        public object Timings { get; set; }

        /// <summary>
        /// No HTTP request is complete without its headers, and the 
        /// same is true for a Postman request. This field is an array 
        /// containing all the headers.
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
