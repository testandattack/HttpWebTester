using ApiSet.Models.Consts;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Serilog;

namespace ApiSet.Models.ApiDocs
{
    /// <summary>
    /// [Extension] Holds a few key properties about the response object.
    /// </summary>
    /// <remarks>
    /// Used to quickly describe Primitive values that may not have a 
    /// <see cref="Component"/> to reference.
    /// </remarks>
    public class AbbreviatedResponseObject
    {
        #region -- Properties -----
        /// <summary>
        /// The <see cref="http://spec.openapis.org/oas/v3.0.3#data-types">OpenApi defined Type</see> 
        /// of the response object property.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// this field describes the format of the object
        /// </summary>
        /// <remarks>
        /// Primitives have an optional modifier property: format. OAS uses several known formats 
        /// to define in fine detail the data type being used. However, to support documentation 
        /// needs, the format property is an open string-valued property, and can have any value. 
        /// Formats such as "email", "uuid", and so on, MAY be used even though undefined by this 
        /// specification. Types that are not accompanied by a format property follow the type 
        /// definition in the JSON Schema. Tools that do not recognize a specific format MAY default 
        /// back to the type alone, as if the format is not specified.
        /// </remarks>
        public string format { get; set; }

        /// <summary>
        /// Indicates whether the property can be null.
        /// </summary>
        public string nullable { get; set; }

        /// <summary>
        /// A string pointing to another object to be referenced.
        /// <see cref="http://spec.openapis.org/oas/v3.0.3#fixed-fields-18"/> 
        /// for more information.
        /// </summary>
        public string reference { get; set; }
        #endregion

        #region -- Constructors -----
        public AbbreviatedResponseObject()
        {
            type = string.Empty;
            format = string.Empty;
            nullable = string.Empty;
            reference = string.Empty;
        }

        public AbbreviatedResponseObject(string Type, string Format)
        {
            type = Type;
            format = Format;
            nullable = string.Empty;
            reference = string.Empty;
        }
        #endregion
    }

}
