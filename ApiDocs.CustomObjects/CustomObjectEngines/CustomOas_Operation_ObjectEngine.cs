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
    public class CustomOas_Operation_ObjectEngine : CustomOasObjectEngine
    {
        #region -- Porperties -----
        //public OpenApiOperation openApiOperation { get; set; }

        public OperationType operationType { get; set; }
        #endregion

        #region -- Constructors -----
        public CustomOas_Operation_ObjectEngine() { }

        public CustomOas_Operation_ObjectEngine(CustomOasObjectCollection CustomObjects)
        {
            this.customObjects = CustomObjects;
        }
        #endregion

        #region -- Methods -----
        /// <summary>
        /// Call this method to fire off any custom event handlers
        /// </summary>
        /// <param name="openApiOperation"></param>
        public void LookForCustomObjects(OpenApiOperation openApiOperation)
        {
            if(openApiOperation.Extensions != null && openApiOperation.Extensions.Count > 0)
            {
                HandleCustomObjectEventProcesssing(openApiOperation);
            }
        }
        #endregion

        #region -- Custom Object Event Handler Code -----
        public event EventHandler<CustomOas_Operation_ObjectEventArgs> OpenApiOperationEvent;

        protected virtual void OnOpenApiOperationEvent(CustomOas_Operation_ObjectEventArgs e)
        {
            EventHandler<CustomOas_Operation_ObjectEventArgs> handler = OpenApiOperationEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void HandleCustomObjectEventProcesssing(OpenApiOperation openApiOperation)
        {
            foreach (var item in customObjects.collection.Values)
            {
                if (item.CustomObjectType == "CustomOas_Operation_Object")
                {
                    OpenApiOperationEvent += (item as CustomOas_Operation_Object).ParseObject;
                }
            }
            FireOpenApiPathItemEventHandler(openApiOperation);
        }

        public void FireOpenApiPathItemEventHandler(OpenApiOperation openApiOperation)
        {
            CustomOas_Operation_ObjectEventArgs args = new CustomOas_Operation_ObjectEventArgs();
            args.operation = openApiOperation;
            args.operationType = operationType;
            OnOpenApiOperationEvent(args);
        }
        #endregion
    }
}
