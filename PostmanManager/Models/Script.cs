using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    /// <summary>
    /// A script is a snippet of Javascript code that can be 
    /// used to to perform setup or teardown operations on a particular response.
    /// </summary>
    public class Script
    {

        /// <summary>
        /// A unique, user defined identifier that can  
        /// be used to refer to this script from requests.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Type of the script. E.g: 'text/javascript'
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// This is an array of strings, where each line 
        /// represents a single line of code. Having lines 
        /// separate makes it possible to easily track 
        /// changes made to scripts.
        /// NOTE: Type = oneOf
        /// </summary>
        [JsonProperty("exec")]
        public string Exec { get; set; }

        /// <summary>
        /// No Description Given
        /// </summary>
        [JsonProperty("url")]
        public Url Url { get; set; }

        /// <summary>
        /// script name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
