using ApiTestGenerator.Models.Enums;
using GTC.OpenApiUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiTestGenerator.Models.ApiAnalyzer
{
    public class EndpointSummary
    {
        #region -- Properties -----
        public int endpointId { get; set; }
        public bool IsDepricated { get; set; }
        public bool IsTestMethod { get; set; }

        public bool HasSummary { get; set; }

        public bool IsLookup { get; set; }

        public int NumberOfParams { get; set; }
        
        public int NumberOfRequiredParams { get; set; }       

        public int NumberOfParamsWithExample { get; set; }
        
        public int NumberOfParamsWithExamples { get; set; }

        public string customEndPointObjectTypes { get; set; }

        public string Responses { get; set; }
        
        /// <summary>
        /// an enum defining the type of content in the request body
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public RequestBodyContentTypeEnum? RequestBodyContentType { get; set; }
        #endregion

        #region -- Constructors -----
        public EndpointSummary() 
        {
            IsDepricated = false;
            IsTestMethod = false;
            HasSummary = false;
            IsLookup = false;
            NumberOfParams = -1;
            NumberOfRequiredParams = -1;
            NumberOfParamsWithExample = 0;
            NumberOfParamsWithExamples = 0;
            customEndPointObjectTypes = string.Empty;
            endpointId = -1;
        }
        #endregion

        public EndpointSummary ShallowCopy()
        {
            return (EndpointSummary)this.MemberwiseClone();
        }
    }
}
