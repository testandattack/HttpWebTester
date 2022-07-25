using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSet.Models.ApiDocs
{
    /// <summary>
    /// An object loosely based on the <see cref="http://spec.openapis.org/oas/v3.0.3#example-object"/>
    /// object.
    /// </summary>
    public class ExampleValue
    {
        #region -- Properties -----
        /// <summary>
        /// The <see cref="http://spec.openapis.org/oas/v3.0.3#data-types">OpenApi defined Type</see> 
        /// of the Example value being provided.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The actual value of the provided example
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// [Extension] - Used to store a formula or other item 
        /// describing how to generate values for the example.
        /// </summary>
        [JsonProperty(PropertyName = "generatedValue")]
        public string GeneratedValue { get; set; }
        #endregion

        #region -- Constructors -----
        /// <summary>
        /// Creates a new instance of the <see cref="ExampleValue"/> object.
        /// </summary>
        public ExampleValue()
        {
            Type = string.Empty;
            Value = string.Empty;
            GeneratedValue = string.Empty;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ExampleValue"/> object
        /// and initiates the <see cref="Type"/> and <see cref="Value"/> properties.
        /// </summary>
        /// <param name="type">The <see cref="http://spec.openapis.org/oas/v3.0.3#data-types">OpenApi defined Type</see> of the example</param>
        /// <param name="value">The actual value to use.</param>
        public ExampleValue(string type, string value)
        {
            Type = type;
            Value = value;
            GeneratedValue = string.Empty;
        }
        #endregion
    }
}
