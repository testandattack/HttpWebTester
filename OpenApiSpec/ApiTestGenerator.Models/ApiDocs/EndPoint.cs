using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    public class EndPoint
    {
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
        /// The version of the API that contains this operation.
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
        /// <see cref="ParseTokens.TKN_LookupMethod"/> tag indicating
        /// that the method is used to grab lookup values for other
        /// methods in the API.
        /// </summary>
        public bool IsLookupMethod { get; set; }

        /// <summary>
        /// A boolean that indicates if this method is exposed solely for
        /// the Tester Role and woill not be used by the application.
        /// All Test methods contain <see cref="ParseTokens.DESC_ForTestingPurposes"/>
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
        /// A list of <see cref="CustomEndPointObject"/> items discovered in
        /// the Api Document json.
        /// </summary>
        /// <remarks>
        /// The types of objects can be seen in this enum:
        /// <see cref="CustomEndPointObjectTypeEnum"/>
        /// </remarks>
        public List<CustomEndPointObject> customEndPointObjects { get; set; }
        #endregion

        #region -- Constructors -----
        /// <summary>
        /// Creates a new instance of the <see cref="EndPoint"/> object.
        /// </summary>
        public EndPoint()
        {
            UriPath = string.Empty;
            Method = string.Empty;
            Version = "Not Implemenmted";
            parameters = new Dictionary<string, Parameter>(StringComparer.InvariantCultureIgnoreCase);
            Depricated = false;
            Description = string.Empty;
            Summary = string.Empty;

            ReportingName = string.Empty;
            controllerName = string.Empty;
            IsLookupMethod = false;
            IsForTestingPurposes = false;
            customEndPointObjects = new List<CustomEndPointObject>();

        }

        /// <summary>
        /// Creates a new instance of the <see cref="EndPoint"/> object
        /// and assigns the passed in value to the <see cref="controllerName"/> property.
        /// </summary>
        /// <param name="ControllerName">the name of the API controller that houses this endpoint.</param>
        public EndPoint(string ControllerName)
        {
            UriPath = string.Empty;
            Method = string.Empty;
            Version = "Not Implemenmted";
            parameters = new Dictionary<string, Parameter>(StringComparer.InvariantCultureIgnoreCase);
            Depricated = false;
            Description = string.Empty;
            Summary = string.Empty;

            ReportingName = string.Empty;
            controllerName = ControllerName;
            IsLookupMethod = false;
            IsForTestingPurposes = false;
            customEndPointObjects = new List<CustomEndPointObject>();
        }
        #endregion
    }
}
