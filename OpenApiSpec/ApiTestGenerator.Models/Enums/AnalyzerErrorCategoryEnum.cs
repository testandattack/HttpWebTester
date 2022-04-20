using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ApiTestGenerator.Models.Enums
{
    /// <summary>
    /// Defines the category of error in the ApiSetAnalyzerError list
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AnalyzerErrorCategoryEnum
    {
        DuplicateProperty,

        Property_MissingType,

        AnalyzeEndpointRestrictionSummary,

        AnalyzeEndPointRestrictions,

        AnalyzeRequestBodies,

        AnalyzeInputParameters,

        AnalyzeApiComponents,

        ResponseObject_MissingType,

        DuplicateEndpoint,

        DuplicateLookupEndpoint
    }
}
