using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    /// <summary>
    /// Detailed description of the info block
    /// </summary>
    public class Info
    {
        /// <summary>
        /// A collection's friendly name is defined by this field. 
        /// You would want to set this field to a value that would 
        /// allow you to easily identify this collection among a 
        /// bunch of other collections, as such outlining its usage or content.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Every collection is identified by the unique value of 
        /// this field. The value of this field is usually easiest 
        /// to generate using a UID generator function. If you already 
        /// have a collection, it is recommended that you maintain the 
        /// same id since changing the id usually implies that is a 
        /// different collection than it was originally.\n *Note: This 
        /// field exists for compatibility reasons with Collection Format V1.*
        /// </summary>
        [JsonProperty("_postman_id")]
        public string PostmanId { get; set; }

        /// <summary>
        /// No description given
        /// </summary>
        [JsonProperty("description")]
        public Description Description { get; set; }

        /// <summary>
        /// see the <see cref="Version"/> class for info.
        /// </summary>
        [JsonProperty("version")]
        public Version Version { get; set; }

        /// <summary>
        /// This should ideally hold a link to the Postman schema 
        /// that is used to validate this collection. 
        /// E.g: https://schema.getpostman.com/collection/v1
        /// </summary>
        [JsonProperty("schema", Required = Required.Always)]
        public string Schema { get; set; }

    }
}
