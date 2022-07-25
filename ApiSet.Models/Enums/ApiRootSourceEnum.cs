using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ApiSet.Models.ApiDocs;

namespace ApiSet.Models.Enums
{
    /// <summary>
    /// Lists the source for the <see cref="ApiSet.apiRoot"/> object
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApiRootSourceEnum
    {
        /// <summary>
        /// The value defined in the <c>basePath</c> node
        /// </summary>
        basePath,

        /// <summary>
        /// The value added to the <c>settings.json</c> file
        /// </summary>
        settingsFile,

        /// <summary>
        /// The Servers Url addresses will be searched for a common value with an 
        /// extension method
        /// </summary>
        //serversUrl,

        /// <summary>
        /// An empty string if there is not a common basePath, or if the value is
        /// not provided by one of the above items.
        /// </summary>
        empty
    }
}
