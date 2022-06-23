using ApiTestGenerator.Models.ApiDocs;
using ApiTestGenerator.Models.Enums;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDocs.CustomObjects
{
    /// <summary>
    /// Base Abstract class for describing custom objects that can be added
    /// to Swagger Documentation.
    /// </summary>
    public class CustomOasObjectEngine : ICustomOasObjectEngine<CustomOasObjectEngine>
    {
        /// <summary>
        /// This method triggers the building of event handlers and the triggering of the
        /// events themselves. It is called by the <c>Endpoint Engine</c>.
        /// </summary>
        /// <param name="openApiOperation"></param>
        public void LookForCustomObjects(OpenApiOperation openApiOperation, CustomOasObjectCollection items)
        {
            if(openApiOperation.Extensions != null && openApiOperation.Extensions.Count > 0)
            {
                HandleCustomObjectEventProcesssing(openApiOperation, items);
            }
        }

        #region -- Custom Object Event Handler Code -----
        public virtual void ParseObject(object sender, CustomOasObjectEventArgs e) { }

        private event EventHandler<CustomOasObjectEventArgs> OpenApiOperationEvent;

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
