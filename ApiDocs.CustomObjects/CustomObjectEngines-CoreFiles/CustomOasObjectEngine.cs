using ApiTestGenerator.Models.ApiDocs;
using ApiTestGenerator.Models.Enums;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDocs.CustomObjects
{
    /// <summary>
    /// Base class for describing custom objects that can be added
    /// to Swagger Documentation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This base class has all of the event hooks and handler methods that tie into the ApiSet\Endpoint parser.
    /// </para>
    /// <para>
    /// To add custom objects, create your own class and have it inherit from this class. Then, update the 
    /// <see cref="AddAllCustomObjectEngines.BuildCustomObjects"/> method to call your custom class.
    /// </para>
    /// </remarks>
    public class CustomOasObjectEngine : ICustomOasObjectEngine<CustomOasObjectEngine>
    {
        /// <summary>
        /// This method triggers the building of event handlers and the triggering of the
        /// events themselves. It is called by the <c>Endpoint Engine</c>.
        /// </summary>
        /// <remarks>
        /// This method is used by the EndPoint Engine and should not be called by your code. 
        /// </remarks>
        /// <param name="openApiOperation">This is the OAS operation that is being parsed to build the EndPoint object</param>
        /// <param name="items">This is the Endpoint's collection of custom objects.</param>
        public void LookForCustomObjects(OpenApiOperation openApiOperation, CustomOasObjectCollection items)
        {
            if(openApiOperation.Extensions != null && openApiOperation.Extensions.Count > 0)
            {
                HandleCustomObjectEventProcesssing(openApiOperation, items);
            }
        }

        #region -- Custom Object Event Handler Code -----
        /// <summary>
        /// This is the method that you should override in your derived class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// This code example how to create your own custom parser
        /// <code language="cs">
        /// public override void ParseObject(object sender, CustomOasObjectEventArgs e)
        /// {
        ///    // First, verify that this operation contains at least one extension 
        ///    if (e.operation.Extensions != null &amp;&amp; e.operation.Extensions.Count > 0)
        ///    {
        ///        // Loop through the extensions
        ///        foreach (var operationExtension in e.operation.Extensions)
        ///        {
        ///            // Make sure the current extensoin is the one you are looking for
        ///            if (operationExtension.Key == "x-Whatever-YourTokenNameMioghtBe")
        ///            {
        ///                // Create a new CustomOasObject for the ApiSet
        ///                var Item = new CustomOasObject();
        ///
        ///                // Name the object
        ///                Item.CustomObjectName = "x-Whatever-YourTokenNameMioghtBe";
        ///
        ///                // Retrieve the value stored in the OAS (this example assumes it is a string)
        ///                // For more information, see the section below.
        ///                string endpointNames = ((OpenApiString)(operationExtension.Value)).Value;
        ///
        ///                // Make sure that there is a legitimate value to use
        ///                if (endpointNames.Length > 0)
        ///                {
        ///                    // Here you can convert the string to a different object type as needed. In
        ///                    // this case, the string contains a comma separated list of strings, so we
        ///                    // use the CsvStrToList(string, bool) extension method to create a list 
        ///                    // and add that to the CustomOasObject.
        ///                    Item.CustomObjectValue = endpointNames.CsvStrToList();
        ///                    
        ///                    // Finally, we add the CustomOasObject to the endpoint's collection
        ///                    e.customObjects.collection.Add(Item);
        ///                }
        ///            }
        ///        }
        ///    }
        /// }
        /// </code>
        /// <para>
        /// The extension object as specified in the schema is of type <see cref="IOpenApiAny"/>. 
        ///  The value can be null, a primitive, an array or an object. Can have any valid JSON format value.
        /// </para>
        /// <para>
        /// For more information on the OAS Specification Extensions, see <see href="https://spec.openapis.org/oas/v3.0.0#specification-extensions">
        /// this article</see>.
        /// </para>
        /// </remarks>
        public virtual void ParseObject(object sender, CustomOasObjectEventArgs e) { }

        private event EventHandler<CustomOasObjectEventArgs> OpenApiOperationEvent;

        /// <summary>
        /// This method is part of the C# event handler functionality.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnOpenApiOperationEvent(CustomOasObjectEventArgs e)
        {
            EventHandler<CustomOasObjectEventArgs> handler = OpenApiOperationEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void HandleCustomObjectEventProcesssing(OpenApiOperation openApiOperation, CustomOasObjectCollection items)
        {
            var engines = AddAllCustomObjectEngines.BuildCustomObjects();
            foreach (var engine in engines)
            {
                    OpenApiOperationEvent += engine.ParseObject;
            }
            FireOpenApiPathItemEventHandler(openApiOperation, items);
        }

        private void FireOpenApiPathItemEventHandler(OpenApiOperation openApiOperation, CustomOasObjectCollection items)
        {
            CustomOasObjectEventArgs args = new CustomOasObjectEventArgs();
            args.operation = openApiOperation;
            args.customObjects = items;
            OnOpenApiOperationEvent(args);
        }
        #endregion
    }
}
