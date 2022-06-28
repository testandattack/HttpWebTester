using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PostmanManager.Models
{
    public class Header
    {
        /// <summary>
        /// This holds the LHS of the HTTP Header, e.g ``Content-Type`` or ``X-Custom-Header``
        /// </summary>
        [JsonProperty("key"), JsonRequired]
        public string Key { get; set; }

        /// <summary>
        /// The value (or the RHS) of the Header is stored in this field.
        /// </summary>
        [JsonProperty("value"), JsonRequired]
        public string Value { get; set; }

        /// <summary>
        /// If set to true, the current header will not be sent with requests.
        /// </summary>
        [JsonProperty("disabled")]
        [DefaultValue(false)]
        public bool Disabled { get; set; }

        /// <summary>
        /// A description of the header
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
