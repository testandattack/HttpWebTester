using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PostmanManager.Models
{
    public class UrlEncodedParameter
    {
        /// <summary>
        /// No description given 
        /// </summary>
        [JsonProperty("key"), JsonRequired]
        public string Key { get; set; }

        /// <summary>
        /// No description given 
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// No description given 
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
