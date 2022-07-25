using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSet.Models.ApiDocs
{
    /// <summary>
    /// This class defines a container to house the custom class objects
    /// that are used for responses from the API. 
    /// </summary>
    /// <remarks>
    /// This class bears the same name as the <see cref="http://spec.openapis.org/oas/v3.0.3#components-object">
    /// Components</see> object in the OpenApiSpec, but it only implements a part of the functionality, specifically
    /// the Schema objects stored under the Components object.
    /// </remarks>
    public class Component
    {
        #region -- Properties -----
        /// <summary>
        /// The name of the schema object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the class inside source code for the object being stored.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// The list of <see cref="Property"/> items
        /// that are associated with the schema.
        /// </summary>
        public Dictionary<string, Property> properties { get; set; }
        #endregion

        #region -- Constructors -----
        public Component()
        {
            Name = string.Empty;
            ClassName = string.Empty;
            properties = new Dictionary<string, Property>();
        }
        #endregion
    }
}
