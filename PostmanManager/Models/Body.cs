using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PostmanManager.Models
{
    public class Body
    {
        /// <summary>
        /// Postman stores the type of data associated with this request in this field.
        /// </summary>
        [JsonProperty("mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BodyType_Enum Mode { get; set; }

        /// <summary>
        /// No description given 
        /// </summary>
        [JsonProperty("raw")]
        public string Raw { get; set; }

        /// <summary>
        /// No description given 
        /// </summary>
        [JsonProperty("urlencoded")]
        public List<UrlEncodedParameter> UrlEncoded { get; set; }

        /// <summary>
        /// No description given 
        /// </summary>
        [JsonProperty("formdata")]
        public List<FormParameter> FormData { get; set; }

        /// <summary>
        /// No description given 
        /// </summary>
        [JsonProperty("file")]
        public FileUploadObject File { get; set; }

        /// <summary>
        /// No description given 
        /// </summary>
        [JsonProperty("graphql")]
        public object Graphql { get; set; }

        /// <summary>
        /// Additional configurations and options set for various body modes.
        /// </summary>
        [JsonProperty("options")]
        public object Options { get; set; }

        /// <summary>
        /// When set to true, prevents this form data entity from being sent.
        /// </summary>
        [JsonProperty("disabled")]
        [DefaultValue(false)]
        public bool Disabled { get; set; }
    }
}
