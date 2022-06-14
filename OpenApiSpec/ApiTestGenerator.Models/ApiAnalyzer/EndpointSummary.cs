using ApiTestGenerator.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiTestGenerator.Models.ApiAnalyzer
{
    public class EndpointSummary
    {
        #region -- Properties -----
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
        /// <see cref="RequestBody.RequestBodyContentType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public RequestBodyContentTypeEnum? RequestBodyContentType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EndpointParsingData endpointParsingData { get; set; }
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
        }
        #endregion

        public EndpointSummary ShallowCopy()
        {
            return (EndpointSummary)this.MemberwiseClone();
        }
    }
}
