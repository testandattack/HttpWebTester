using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    public class Url
    {
        /// <summary>
        /// The string representation of the request URL, including the protocol, host, path, hash, query parameter(s) and path variable(s).
        /// </summary>
        [JsonProperty("raw")]
        public string Raw { get; set; }

        /// <summary>
        /// The protocol associated with the request, E.g: 'http'
        /// </summary>
        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// The host for the URL, E.g: api.yourdomain.com. 
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// The complete path of the current url, broken down into segments. A segment could be a string, or a path variable.
        /// </summary>
        [JsonProperty("path")]
        public PathItem Path { get; set; }

        /// <summary>
        /// The port number present in this URL. An empty value implies 80/443 depending on whether the protocol field contains http/https.
        /// </summary>
        [JsonProperty("port")]
        public string Port { get; set; }

        /// <summary>
        /// An array of QueryParams, which is basically the query string part of the URL, parsed into separate variables
        /// </summary>
        [JsonProperty("query")]
        public List<Variable> QueryParams { get; set; }

        /// <summary>
        /// Contains the URL fragment (if any). Usually this is not transmitted over the network, but it could be useful to store this in some cases.
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("variable")]
        public List<Variable> Variables { get; set; }
    }
}
