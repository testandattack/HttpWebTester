using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    public class Certificate
    {
        /// <summary>
        /// A name for the certificate for user reference
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A list of Url match pattern strings, to identify Urls this certificate can be used for.
        /// </summary>
        [JsonProperty("matches")]
        public string[] Matches { get; set; }

        /// <summary>
        /// An object containing path to file containing private key, on the file system
        /// </summary>
        [JsonProperty("key")]
        public object Key { get; set; }

        /// <summary>
        /// An object containing path to file certificate, on the file system
        /// </summary>
        [JsonProperty("cert")]
        public object Cert { get; set; }

        /// <summary>
        /// The passphrase for the certificate
        /// </summary>
        [JsonProperty("passphrase")]
        public string PassPhrase { get; set; }
    }
}
