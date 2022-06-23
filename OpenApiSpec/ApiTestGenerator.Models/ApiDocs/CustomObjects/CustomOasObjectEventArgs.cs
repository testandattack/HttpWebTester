using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.OpenApi.Models;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// The class to hold the properties that get passed into any event handler for
    /// custom objects.
    /// </summary>
    public class CustomOasObjectEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="OpenApiOperation"/> that might contain custom objects
        /// </summary>
        public OpenApiOperation operation { get; set; }

        /// <summary>
        /// The <see cref="CustomOasObjectCollection"/> for the endpoint being processed.
        /// This is passed to the event handler so that the method can add the new object
        /// to the collection.
        /// </summary>
        public CustomOasObjectCollection customObjects { get; set; }
    }
}
