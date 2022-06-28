using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    public class FileUploadObject
    {
        /// <summary>
        /// Contains the name of the file to upload. _Not the path_.
        /// A null src indicates that no file has been selected as a part of the request body.
        /// </summary>
        [JsonProperty("src", NullValueHandling = NullValueHandling.Include)]
        public string Source { get; set; }

        /// <summary>
        /// No description given 
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
