using ApiSet.Models.ApiAnalyzer;
using ApiSet.Models.ApiDocs;
using ApiSet.Models.Consts;
using ApiSet.Models.Enums;
using GTC.OpenApiUtilities;
using System.Linq;
using GTC.Extensions;

namespace Engines.ApiDocs.Extensions
{
    public static class EndpointSummaryExtensions
    {
        #region -- Methods -----
        public static void BuildEndpointSummary(this EndpointSummary source,EndPoint endPoint)
        {
            source.endpointId = endPoint.EndpointId;
            source.GetExampleCounts(endPoint);
            source.IsDepricated = endPoint.Depricated;
            source.IsTestMethod = endPoint.IsForTestingPurposes;
            source.HasSummary = !string.IsNullOrEmpty(endPoint.Summary);
            source.IsLookup = endPoint.IsLookupMethod;
            source.NumberOfParams = endPoint.parameters.Count;

            source.NumberOfRequiredParams = endPoint.parameters.Where(p =>
                p.Value.Required == true).ToList().Count;

            //source.customEndPointObjectTypes = CustomOasObjectEngine.GetCustomEndPointObjectTypesAsString(endPoint.customEndPointObjects);
            
            if (endPoint.requestBody != null)
                source.RequestBodyContentType = GetRequestBodyContentType(endPoint.requestBody.RequestBodyContentType);

            if (endPoint.ResponseItems != null)
                source.Responses = endPoint.ResponseItems.Keys.ToString(";");
        }

        private static void GetExampleCounts(this EndpointSummary source, EndPoint endPoint)
        {
            foreach(var item in endPoint.parameters)
            {
                if (item.Value.ExampleValue != null)
                {
                    source.NumberOfParamsWithExample++;
                }
                if (item.Value.ExampleValues.Count > 0)
                {
                    source.NumberOfParamsWithExamples++;
                }
            }
        }

        public static string ToString(this EndpointSummary source)
        {
            return $"{source.IsDepricated},{source.HasSummary},{source.IsLookup},{source.NumberOfParams},{source.NumberOfRequiredParams},{source.customEndPointObjectTypes},{source.Responses}";
        }

        //public static bool HasUriParams(this EndpointSummary source)
        //{
        //    if (source.endpointParsingData.UriPath.Contains("{"))
        //        return true;
        //    else
        //        return false;
        //}

        public static RequestBodyContentTypeEnum GetRequestBodyContentType(string contentType)
        {
            switch(contentType)
            {
                case ParseTokens.OAS_FormDataContentType:
                    return RequestBodyContentTypeEnum.OAS_FormDataContentType;
                case ParseTokens.OAS_JsonContentType:
                    return RequestBodyContentTypeEnum.OAS_JsonContentType;
                case ParseTokens.OAS_NoContentFound:
                    return RequestBodyContentTypeEnum.OAS_NoContentFound;
                default:
                    return RequestBodyContentTypeEnum.OAS_Other;
            }
        }
        #endregion
    }
}
