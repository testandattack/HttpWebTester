using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PostmanManager.Models
{
    /// <summary>
    /// Using the Proxy, you can configure your custom proxy into 
    /// the postman for particular url match
    /// </summary>
    public class Proxy
    {
        /// <summary>
        /// The Url match for which the proxy config is defined.
        /// </summary>
        [JsonProperty("match")]
        [DefaultValue("http+https://*/*")]
        public string Match { get; set; }

        /// <summary>
        /// The proxy server host
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// The proxy server port
        /// </summary>
        [JsonProperty("port")]
        [DefaultValue(8080)]
        public int Port { get; set; }

        /// <summary>
        /// The tunneling details for the proxy config
        /// </summary>
        [JsonProperty("tunnel")]
        [DefaultValue(false)]
        public bool Tunnel { get; set; }

        /// <summary>
        /// When set to true, ignores this proxy configuration entity
        /// </summary>
        [JsonProperty("disabled")]
        [DefaultValue(false)]
        public bool Disabled { get; set; }
    }
}
