using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSet.Models.ApiDocs
{
    /// <summary>
    /// This class defines a container to house the Request Body
    /// info needed to build a proper request.
    /// </summary>
    /// <remarks>
    /// This class is based loosely off the <see cref="http://spec.openapis.org/oas/v3.0.3#request-body-object">
    /// Request Body</see> object in the OpenApiSpec.
    /// </remarks>
    public class RequestBody
    {
        #region -- Properties -----
        /// <summary>
        /// Holds the media content type being passed in through the Request Body.
        /// </summary>
        [JsonRequired]
        public string RequestBodyContentType { get; set; }

        #region -- Application/Json Body properties -----
        /// <summary>
        /// If the operation is a POST, PUT or PATCH based request,
        /// this string holds the class name of the Input DTO that is used
        /// as a template for the request body.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? RequestBodyJsonObject { get; set; }

        /// <summary>
        /// If the operation is a POST, PUT or PATCH based request,
        /// this string holds the Swagger generated Input template
        /// text that is generated from the $ref entry in the 
        /// <see cref="http://spec.openapis.org/oas/v3.0.3#request-body-object"/>
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? RequestBodyString { get; set; }

        /// <summary>
        /// This property holds the <see cref="http://spec.openapis.org/oas/v3.0.3#media-type-object"/>
        /// of the request object to pass in. 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? RequestBodySchemaType { get; set; }
        #endregion

        #region -- multipart/form-data Body properties -----
        /// <summary>
        /// This property holds the <see cref="http://spec.openapis.org/oas/v3.0.3#media-type-object"/>
        /// of the request object to pass in.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? RequestBodyFormObjectOrType { get; set; }

        /// <summary>
        /// The list of <see cref="Property"/> items
        /// that are associated with the schema.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Property> properties { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? FormPostFileUploadPropertyName { get; set; }
        #endregion
        #endregion

        #region -- Constructors -----
        public RequestBody()
        {
            RequestBodyContentType = string.Empty;
        }
        #endregion
    }
}
