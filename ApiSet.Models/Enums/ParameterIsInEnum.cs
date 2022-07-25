using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiSet.Models.Enums
{
    /// <summary>
    /// Lists the locations within an OpenApiOperation that a parameter can show up.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ParameterIsInEnum
    {
        /// <summary>
        /// 
        /// </summary>
        query,

        /// <summary>
        /// 
        /// </summary>
        header,

        /// <summary>
        /// 
        /// </summary>
        path,

        /// <summary>
        /// 
        /// </summary>
        formData,

        /// <summary>
        /// 
        /// </summary>
        body
    }
}
