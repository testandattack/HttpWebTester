using ApiTestGenerator.Models.ApiDocs;
using Engines.ApiDocs.Extensions;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace Engines.ApiDocs
{
    public class EndPointEngine
    {
        #region -- Properties -----
        public KeyValuePair<OperationType, OpenApiOperation> operation { get; set; }

        public CustomOasObjectCollection customEndPointObjects { get; set; }
        #endregion

        #region -- Constructors -----
        public EndPointEngine() 
        {
            customEndPointObjects = new CustomOasObjectCollection();
            operation = new KeyValuePair<OperationType, OpenApiOperation>();
        }

        public EndPointEngine(CustomOasObjectCollection customObjects)
        {
            customEndPointObjects = customObjects;
            operation = new KeyValuePair<OperationType, OpenApiOperation>();
        }

        public EndPointEngine(CustomOasObjectCollection customObjects, KeyValuePair<OperationType, OpenApiOperation> apiOperation)
        {
            customEndPointObjects = customObjects;
            operation = apiOperation;
        }
        #endregion

        #region -- Methods -----
        public int ParseEndpoint(Controller controller, string pathUri, int startingId, OpenApiPathItem item)
        {
            Log.ForContext<ApiSetEngine>().Debug("[{method}]: Adding {@OpenApiPathItem} {OpenApiMethod}", "AddEndPoint", pathUri, operation.Key);
            EndPoint endPoint = new EndPoint(controller.Name);
            endPoint.EndpointId = startingId;

            endPoint.UriPath = pathUri;
            endPoint.Method = operation.Key.ToString();
            endPoint.Depricated = operation.Value.Deprecated;

            endPoint.Summary = operation.Value.Summary;

            if (operation.Value.Description != null)
            {
                endPoint.Description = operation.Value.Description.Replace("\r\n", "");
            }

            endPoint.ReportingName = pathUri
                .Replace("/api/", "")
                .Replace("/", "-")
                .Replace("{", "<")
                .Replace("}", ">");


            endPoint.AddParameters(operation.Value, controller.EndPoints.Count + 1);
            foreach (var parm in item.Parameters)
            {
                if (parm != null)
                {
                    endPoint.AddParameter(controller.EndPoints.Count, parm);
                }
            }

            endPoint.CheckForDynamicDates(operation.Value);
            //endPoint.AddRestrictions(operation.Value);
            endPoint.AddMethodsThatUseThisResponse(operation.Value);
            //endPoint.AddSourceMethodName(operation.Value);
            //endPoint.AddTestDataFilter(operation.Value);
            endPoint.CheckFor_IsLookupMethod(operation.Value);

            if (endPoint.Method.ToUpper() == "POST" || endPoint.Method.ToUpper() == "PUT")
            {
                endPoint.AddRequestBody(operation.Value);
            }
            endPoint.AddResponseItems(operation.Value);

            string endPointKey = $"{endPoint.Method} | {endPoint.UriPath}";
            controller.EndPoints.Add(endPointKey, endPoint);
            startingId++;
            return startingId;
        }
        #endregion

        #region -- Custom Object Event Handler Code -----
        public event EventHandler<OpenApiOperationEventArgs> OpenApiPathItemEvent;

        protected virtual void OnOpenApiPathItemEvent(OpenApiOperationEventArgs e)
        {
            EventHandler<OpenApiOperationEventArgs> handler = OpenApiPathItemEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void HandleCustomObjectEventProcesssing()
        {
            foreach (var customObject in customEndPointObjects.collection)
            {
                CustomOasObjectEngine item = customObject;
                OpenApiPathItemEvent += item.OpenApiPathItemParsing;
            }
        }

        public void FireOpenApiPathItemEventHandler()
        {
            OpenApiOperationEventArgs args = new OpenApiOperationEventArgs();
            args.operation = operation;
        }
        #endregion
    }
}
