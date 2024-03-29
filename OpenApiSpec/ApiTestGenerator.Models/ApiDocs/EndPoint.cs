﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using GTC.OpenApiUtilities;
using ApiTestGenerator.Models.Enums;
using ApiTestGenerator.Models.Consts;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// This object is the equivalent to an OAS "Operation" object.
    /// </summary>
    public class EndPoint
    {
        /// <summary>
        /// 
        /// </summary>
        public int EndpointId { get; set; }

        #region -- Properties that map directly to OpenApiScec properties -----
        /// <summary>
        /// This is the path of the endpoint and is derived from the 'Name' of the
        /// <see cref="http://spec.openapis.org/oas/v3.0.3#path-item-object"/> object 
        /// which describes the type of request that the endpoint expects. 
        /// When combined with the <see cref="Method"/>
        /// property, it describes a unique operation on an API.
        /// </summary>
        public string UriPath { get; set; }

        /// <summary>
        /// This is the 'Name' of the 
        /// <see cref="http://spec.openapis.org/oas/v3.0.3#operation-object"/> object 
        /// which is essentially the URI. When combined with the <see cref="UriPath"/>
        /// property, it describes a unique operation on an API.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// This will allow people to extend the ApiSet to manage versioning of endpoints
        /// at a future time. 
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// A list of <see cref="Parameter"/> objects.
        /// </summary>
        public Dictionary<string, Parameter> parameters { get; set; }

        /// <summary>
        /// From the <see cref="http://spec.openapis.org/oas/v3.0.3#operation-object"/>
        /// field by the same name.
        /// </summary>
        /// <remarks>
        /// Declares this operation to be deprecated. Consumers SHOULD refrain from usage 
        /// of the declared operation. Default value is false.
        /// </remarks>
        public bool Depricated { get; set; }

        /// <summary>
        /// From the <see cref="http://spec.openapis.org/oas/v3.0.3#operation-object"/>
        /// field by the same name.
        /// </summary>
        /// <remarks>
        /// A verbose explanation of the operation behavior. CommonMark syntax MAY be used 
        /// for rich text representation.
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// From the <see cref="http://spec.openapis.org/oas/v3.0.3#operation-object"/>
        /// field by the same name.
        /// </summary>
        /// <remarks>
        /// A short summary of what the operation does.
        /// </remarks>
        public string Summary { get; set; }
        #endregion

        #region -- Properties that are from custom items or are calculated values -----
        /// <summary>
        /// [Extension] This is a name to add to the request in the test harness that will
        /// be used for grouping results of the tests.
        /// </summary>
        public string ReportingName { get; set; }

        /// <summary>
        /// [Extension] The name of the <see cref="Controller"/> object
        /// that contains this endpoint.
        /// </summary>
        public string controllerName { get; set; }

        /// <summary>
        /// A boolean that describes if the method contains the
        /// <see cref="ParserTokens.TKN_LookupMethod"/> tag indicating
        /// that the method is used to grab lookup values for other
        /// methods in the API.
        /// </summary>
        public bool IsLookupMethod { get; set; }

        /// <summary>
        /// A boolean that indicates if this method is exposed solely for
        /// the Tester Role and woill not be used by the application.
        /// All Test methods contain <see cref="ParserTokens.DESC_ForTestingPurposes"/>
        /// in the Description field.
        /// </summary>
        public bool IsForTestingPurposes { get; set; }

        /// <summary>
        /// A list of <see cref="ResponseObject"/> items that the endpoint can supply.
        /// </summary>
        public Dictionary<string, ResponseObject> ResponseItems { get; set; }

        /// <summary>
        /// <see cref="RequestBody"/>
        /// </summary>
        public RequestBody requestBody { get; set; }

        /// <summary>
        /// A list of <see cref="CustomOasObjectEngine"/> items discovered in
        /// the Api Document json.
        /// </summary>
        /// <remarks>
        /// The types of objects can be seen in this enum:
        /// <see cref="CustomEndPointObjectTypeEnum"/>
        /// </remarks>
        public CustomOasObjectCollection customEndPointObjects { get; set; }

        /// <summary>
        /// This string holds the response body text that was present
        /// for the given Http Endpoint. Note: This only applies when 
        /// building an ApiSet from sources like HTTP Archive files.
        /// </summary>
        public string recordedResponseBody { get; set; }

        /// <summary>
        /// This object holds the response object that was present
        /// for the given Http Endpoint. Note: This only applies when 
        /// building an ApiSet from sources like HTTP Archive files.
        /// </summary>
        public HttpResponseMessage recordedResponseMessage { get; set; }
        #endregion

        #region -- Constructors -----
        /// <summary>
        /// Creates a new instance of the <see cref="EndPoint"/> object.
        /// </summary>
        public EndPoint()
        {
            controllerName = string.Empty;
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="EndPoint"/> object
        /// and assigns the passed in value to the <see cref="controllerName"/> property.
        /// </summary>
        /// <param name="ControllerName">the name of the API controller that houses this endpoint.</param>
        public EndPoint(string ControllerName)
        {
            controllerName = ControllerName;
            Initialize();
        }

        private void Initialize()
        {
            UriPath = string.Empty;
            Method = string.Empty;
            Version = "Not Implemenmted";
            parameters = new Dictionary<string, Parameter>(StringComparer.InvariantCultureIgnoreCase);
            Depricated = false;
            Description = string.Empty;
            Summary = string.Empty;
            customEndPointObjects = new CustomOasObjectCollection();

            ReportingName = string.Empty;
            IsLookupMethod = false;
            IsForTestingPurposes = false;
        }
        #endregion
    }
}
