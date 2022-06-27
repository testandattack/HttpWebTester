using ApiTestGenerator.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    public class ResponseObject
    {
        #region -- Properties -----
        /// <summary>
        /// The description for the stsus code that this response
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// [Extension] - The class 'name' of response object for
        /// responses that use a $ref tag to reference a <see cref="Component"/> 
        /// </summary>
        public string ResponseObjectName { get; set; }

        /// <summary>
        /// A <see cref="ResponseTypeEnum"/> value that describes the
        /// type of response object returned.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseTypeEnum ResponseObjectType { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string responseObjectExampleText { get; set; }
        
        /// <summary>
        /// [Extension] - This is a collection of objects in the response 
        /// </summary>
        public Dictionary<string, AbbreviatedResponseObject> abbreviatedResponseObjects { get; set; }
        #endregion

        #region -- Constructors -----
        public ResponseObject()
        {
            abbreviatedResponseObjects = new Dictionary<string, AbbreviatedResponseObject>();
            responseObjectExampleText = null;
        }
        #endregion
    }
}
