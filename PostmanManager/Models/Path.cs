using JsonSubTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    /// <summary>
    /// The complete path of the current url, broken down into segments. A segment could be a string, or a path variable.
    /// </summary>
    [JsonObject(Title = "path")]
    [JsonConverter(typeof(PostmanPath_JsonConverter))]
    public class Path
    {
        /// <summary>
        /// No Description Given
        /// </summary>
        public string stringPath { get; set; }

        /// <summary>
        /// The complete path of the current url, broken down into segments. A segment could be a string, or a path variable.
        /// </summary>
        public string[] stringArrayPath { get; set; }

        /// <summary>
        /// No Description Given
        /// </summary>
        public object[] objectPath { get; set; }

        public PathObjectType_Enum Type { get; set; }
    }

    public enum PathObjectType_Enum
    {
        String,

        StringArray,

        ObjectArray
    }
}
