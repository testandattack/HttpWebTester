using ApiTestGenerator.Models.ApiDocs;
using Engines.ApiDocs.Extensions;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using ApiDocs.CustomObjects;
using GTC.HttpWebTester.Settings;

namespace Engines.ApiDocs
{
    public class EndPointEngine
    {
        #region -- Properties -----
        private Settings settings;

        public KeyValuePair<OperationType, OpenApiOperation> operation { get; set; }

        public CustomOas_Operation_ObjectEngine customEndPointEngine { get; set; }

        #endregion

        #region -- Constructors -----
        public EndPointEngine() 
        {
            customEndPointEngine = new CustomOas_Operation_ObjectEngine();
            operation = new KeyValuePair<OperationType, OpenApiOperation>();
            settings = new Settings();
        }

        public EndPointEngine(CustomOas_Operation_ObjectEngine customObjects)
        {
            customEndPointEngine = customObjects;
            operation = new KeyValuePair<OperationType, OpenApiOperation>();
            settings = new Settings();
        }

        public EndPointEngine(CustomOas_Operation_ObjectEngine customObjects, KeyValuePair<OperationType, OpenApiOperation> apiOperation)
        {
            customEndPointEngine = customObjects;
            operation = apiOperation;
            settings = new Settings();
        }

        public EndPointEngine(CustomOasObjectCollection customObjects, KeyValuePair<OperationType, OpenApiOperation> apiOperation, Settings Settings)
        {
            customEndPointEngine = new CustomOas_Operation_ObjectEngine(customObjects);
            operation = apiOperation;
            settings = Settings;
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

            // Add a summary if present
            endPoint.Summary = operation.Value.Summary;

            // Add a description if present
            if (operation.Value.Description != null)
                endPoint.Description = operation.Value.Description.Replace("\r\n", "");

            // Build a reporting name
            endPoint.ReportingName = pathUri.Replace(settings.swaggerSettings.apiRoot, "")
                .Replace("/", "-")
                .Replace("{", "<")
                .Replace("}", ">");

            // Add the parameters
            endPoint.AddParameters(operation.Value, controller.EndPoints.Count + 1);
            foreach (var parm in item.Parameters)
            {
                if (parm != null)
                {
                    endPoint.AddParameter(controller.EndPoints.Count, parm);
                }
            }

            // Handle extra parsing here
            endPoint.CheckForDynamicDates(operation.Value);
            endPoint.CheckFor_IsLookupMethod(operation.Value);

            // Call the custom object engine to look for any custom object handlers that need to be executed.
            customEndPointEngine.LookForCustomObjects(operation.Value);

            // Look for and add request body info
            if (endPoint.Method.ToUpper() == "POST" || endPoint.Method.ToUpper() == "PUT" || endPoint.Method.ToUpper() == "PATCH")
                endPoint.AddRequestBody(operation.Value);

            // Add response items
            endPoint.AddResponseItems(operation.Value);

            // Build the endpoint name, add the endpoint to the controller, increment and return the id
            string endPointKey = $"{endPoint.Method} | {endPoint.UriPath}";
            controller.EndPoints.Add(endPointKey, endPoint);
            startingId++;
            return startingId;
        }
        #endregion

    }
}
