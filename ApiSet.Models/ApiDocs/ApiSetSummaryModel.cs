using ApiSet.Models.Enums;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApiSet.Models.ApiDocs
{
    /// <summary>
    /// A set of counts for various items in the ApiDoc after
    /// parasing it.
    /// </summary>
    public class ApiSetSummaryModel
    {
        #region -- Properties -----
        #region -- items inherited from ApiSet -----
        /// <summary>
        /// A string containing the Open API Specification version of the OAS document that this summary represents.
        /// </summary>
        public string oasVersion { get; set; }
        
        /// <summary>
        /// A copy of the <see cref="http://spec.openapis.org/oas/v3.0.3#info-object">OpenApiInfo</see> object
        /// from the API Documentation
        /// </summary>
        public OpenApiInfo apiInfo { get; set; }

        /// <summary>
        /// The UriStem portion of the Swagger Operation that preceeds the 
        /// "controller" name i nthe path.
        /// </summary>
        public string apiRoot { get; set; }

        /// <summary>
        /// Lists the source for the <see cref="ApiSet.apiRoot"/> object
        /// </summary>
        [DefaultValue(ApiRootSourceEnum.empty)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ApiRootSourceEnum apiRootSourceLocation { get; set; }
        #endregion

        /// <summary>
        /// the number of <see cref="Controller"/> items in the set.
        /// </summary>
        public int numControllers { get; set; }

        /// <summary>
        /// The number of non-depricated <see cref="EndPoint"/> items in the set.
        /// </summary>
        public int numActiveEndpoints { get; set; }

        /// <summary>
        /// The number of depricated <see cref="EndPoint"/> items in the set.
        /// </summary>
        public int numDepricated { get; set; }

        /// <summary>
        /// The number of non-depricated <see cref="EndPoint"/> items
        /// in the set that exist solely for testing services.
        /// </summary>
        public int numTestMethods { get; set; }

        /// <summary>
        /// The number of <see cref="Component"/> items in the set.
        /// </summary>
        public int numComponents { get; set; }

        /// <summary>
        /// The number of non-fatal errors that occurred during analysis
        /// </summary>
        public int numErrors { get; set; }

        /// <summary>
        /// The number of Lookup Endpoint items found in the set.
        /// </summary>
        public int numLookupEndpoints { get; set; }

        /// <summary>
        /// The number of DTOs that are responses from Lookup Endpoint items
        /// </summary>
        /// <remarks>
        /// This count is tracked separately from the Lookup endpoints because there are
        /// sometimes multiple endpoints returning the same lookup DTO. ALSO, this count does
        /// not include primitive response types.
        /// </remarks>
        public int numLookupComponents { get; set; }

        /// <summary>
        /// The number of individual objects that can be extracted from returned
        /// <see cref="Component"/>s of Lookup Endpoints.
        /// </summary>
        public int numLookupProperties { get; set; }

        /// <summary>
        /// The number of <see cref="Component"/> Properties that are used as
        /// input parameters.
        /// </summary>
        public int numInputProperties { get; set; }

        /// <summary>
        /// The number of input parameters that do not appear to be related
        /// to any <see cref="Component"/>s in the API. 
        /// </summary>
        public int numInputParametersWithoutProperty { get; set; }

        /// <summary>
        /// The number of input parameters that do not appear to be related
        /// to any Lookup <see cref="Component"/>s in the API. 
        /// </summary>
        public int numInputParametersWithoutLookupProperty { get; set; }

        /// <summary>
        /// The number of endpoints that have one or more <see cref="ExampleValue"/> items 
        /// for their input parameters.
        /// </summary>
        public int NumEndpointsWithExample { get; set; }

        /// <summary>
        /// The number of endpoints that have one or more <see cref="List{ExampleValue}"/> items 
        /// for their input parameters.
        /// </summary>
        public int NumEndpointsWithExamples { get; set; }

        /// <summary>
        /// A list of all unique <see cref="OpenApiResponse"/> status 
        /// codes found in the documentation.
        /// </summary>
        public List<string> responseStatuses { get; set; }

        /// <summary>
        /// A list of all of the unique <see cref="Property.Type"/>
        /// entries found in the documentation.
        /// </summary>
        public List<string> propertyTypes { get; set; }

        /// <summary>
        /// A list of all of the unique <see cref="Property.Format"/>
        /// entries found in the documentation.
        /// </summary>
        public List<string> propertyFormats { get; set; }
        #endregion

        #region -- Constructors -----
        public ApiSetSummaryModel()
        {
            apiRoot = string.Empty;
            Initialize();
        }

        public ApiSetSummaryModel(string ApiRoot)
        {
            apiRoot = ApiRoot;
            Initialize();
        }


        private void Initialize()
        {
            responseStatuses = new List<string>();

            numControllers = 0;
            numActiveEndpoints = 0;
            numDepricated = 0;
            numTestMethods = 0;

            numErrors = 0;
            numLookupEndpoints = 0;
            numLookupComponents = 0;

            numLookupProperties = 0;
            numInputProperties = 0;
            numInputParametersWithoutProperty = 0;
            numInputParametersWithoutLookupProperty = 0;

            NumEndpointsWithExample = 0;
            NumEndpointsWithExamples = 0;
        }
        #endregion
    }
}
