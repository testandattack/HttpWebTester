using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// A set of counts for various items in the ApiSet after
    /// parasing it.
    /// </summary>
    public class ApiSetSummaryModel
    {
        #region -- Properties -----
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
