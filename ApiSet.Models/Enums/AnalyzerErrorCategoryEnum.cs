using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ApiSet.Models.Enums
{
    /// <summary>
    /// Defines the category of error in the ApiSetAnalyzerError list
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AnalyzerErrorCategoryEnum
    {
        /// <summary>
        /// 
        /// </summary>
        DuplicateProperty,

        /// <summary>
        /// 
        /// </summary>
        Property_MissingType,

        /// <summary>
        /// 
        /// </summary>
        AnalyzeEndpointRestrictionSummary,

        /// <summary>
        /// 
        /// </summary>
        AnalyzeEndPointRestrictions,

        /// <summary>
        /// 
        /// </summary>
        AnalyzeRequestBodies,

        /// <summary>
        /// 
        /// </summary>
        AnalyzeInputParameters,

        /// <summary>
        /// 
        /// </summary>
        AnalyzeApiComponents,

        /// <summary>
        /// 
        /// </summary>
        ResponseObject_MissingType,

        /// <summary>
        /// 
        /// </summary>
        DuplicateEndpoint,

        /// <summary>
        /// 
        /// </summary>
        DuplicateLookupEndpoint
    }
}
