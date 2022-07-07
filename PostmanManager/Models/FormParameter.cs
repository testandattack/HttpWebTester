using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PostmanManager.Models
{
    public class FormParameter
    {
        /// <summary>
        /// No description given 
        /// </summary>
        [JsonProperty("key"), JsonRequired]
        public string Key { get; set; }


        #region -- The two items here are duplicates because of "oneOf" handling -----
        /// <summary>
        /// No description given 
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        /// <summary>
        /// No description given 
        /// </summary>
        [JsonConverter(typeof(StringOrStringArrayConverter))]
        [JsonProperty("src", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Src { get; set; }
        #endregion


        /// <summary>
        /// When set to true, prevents this form data entity from being sent.
        /// </summary>
        [JsonProperty("disabled")]
        [DefaultValue(false)]
        public bool Disabled { get; set; }


        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FormParameterType_Enum Type { get; set; }

        /// <summary>
        /// Override Content-Type header of this form data entity.
        /// </summary>
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// A description of the header
        /// </summary>
        [JsonProperty("description")]
        public Description Description { get; set; }
    }
}
