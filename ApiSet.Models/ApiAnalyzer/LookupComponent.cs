using ApiSet.Models.ApiDocs;
using ApiSet.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace ApiSet.Models.ApiAnalyzer
{
    public class LookupComponent
    {
        #region -- Properties -----
        /// <summary>
        /// The names of the Endpoints returning this DTO.
        /// </summary>
        public List<string> EndpointNames { get; set; }

        /// <summary>
        /// [Extension] - The class 'name' of response object for
        /// responses that use a $ref tag to reference a <see cref="ComponentEngine"/> 
        /// </summary>
        public string ResponseObjectName { get; set; }

        /// <summary>
        /// [Extension] - This is a collection of objects in the response 
        /// </summary>
        public Dictionary<string, AbbreviatedResponseObject> ResponseObject { get; set; }

        /// <summary>
        /// A <see cref="ResponseTypeEnum"/> value that describes the
        /// type of response object returned.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseTypeEnum ResponseObjectType { get; set; }
        #endregion

        #region -- Constructors -----
        public LookupComponent() 
        {
            EndpointNames = new List<string>();
            ResponseObjectName = string.Empty;
            ResponseObjectType = ResponseTypeEnum.none;
            ResponseObject = new Dictionary<string, AbbreviatedResponseObject>();
        }

        public LookupComponent(string name, string responseObjectName, ResponseTypeEnum typeEnum, Dictionary<string, AbbreviatedResponseObject> responseObject)
        {
            EndpointNames = new List<string>();
            EndpointNames.Add(name);
            ResponseObjectName = responseObjectName;
            ResponseObjectType = typeEnum;
            ResponseObject = responseObject;
        }
        #endregion

        public bool AddEndpointNameSafely(string endpointName)
        {
            if (EndpointNames.Contains(endpointName))
                return false;

            EndpointNames.Add(endpointName);
            return true;
        }
    }
}
