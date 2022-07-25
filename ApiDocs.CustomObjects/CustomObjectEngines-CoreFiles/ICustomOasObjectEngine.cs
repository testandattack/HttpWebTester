using ApiSet.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Text;
using Microsoft.OpenApi.Models;
using System;
using ApiSet.Models.ApiDocs;

namespace ApiDocs.CustomObjects
{
    /// <summary>
    /// Interface for describing custom objects that can be added
    /// to Swagger Documentation.
    /// </summary>
    public interface ICustomOasObjectEngine<T>
    {
        /// <summary>
        /// the type of custom object
        /// </summary>
        public Type CustomOasObjectEngineType { get { return this.GetType();  } }

        /// <summary>
        /// This method is the entry point for parsing a custom object added to the OpenApiDocument.
        /// The default immplementation returns null. This allows the custom object event handler to
        /// get wired up to any OAS type and not fail if that type doesn't have any custome events.
        /// </summary>
        /// <param name="item">the item which might contain the custom object.</param>
        /// <returns></returns>
        public object CheckForObject(T item)
        {
            return null;
        }
    }
}
