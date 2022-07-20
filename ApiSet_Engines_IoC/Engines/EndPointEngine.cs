using ApiTestGenerator.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using GTC.HttpWebTester.Settings;
using ApiDocs.CustomObjects;
using ApiSet.Engines.Interfaces;

namespace ApiSet.Engines
{
    public class EndPointEngine
    {
        #region -- Properties -----
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IParameterEngine _parameterEngine;

        public KeyValuePair<OperationType, OpenApiOperation> operation { get; set; }

        public CustomOasObjectEngine customEngine { get; set; }
        #endregion

        #region -- Constructors -----
        public EndPointEngine(ILogger logger, IParameterEngine parameterEngine, ISettings settings, KeyValuePair<OperationType, OpenApiOperation> apiOperation)
        {
            CustomOasObjectCollection objectCollection = new CustomOasObjectCollection();
            customEngine = new CustomOasObjectEngine();
            operation = apiOperation;
            _parameterEngine = parameterEngine;
            _settings = settings;
            _logger = logger;
        }
        #endregion

        #region -- Methods -----
        public int ParseEndpoint(Controller controller, string pathUri, int startingId, OpenApiPathItem item)
        {
            _logger.ForContext<EndPointEngine>().Debug("[{method}]: Adding {@OpenApiPathItem} {OpenApiMethod}", "AddEndPoint", pathUri, operation.Key);
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
            //NOTE TODO: The reporting name has to include the apiRoot since sometimes the 
            // apiRoot is empty and the Replace() method does not handle empty values.
            endPoint.ReportingName = pathUri
                .Replace("/", "-")
                .Replace("{", "<")
                .Replace("}", ">");

            // Add the parameters
            foreach (var parm in item.Parameters)
            {
                if (parm != null)
                {
                    var myParm = _parameterEngine.GetParameter(parm, controller.Name, pathUri, endPoint.Method);
                    endPoint.parameters.Add(myParm.Name, myParm);
                }
            }

            // Handle extra parsing here
            endPoint.CheckForDynamicDates(operation.Value);
            endPoint.CheckFor_IsLookupMethod(operation.Value);

            // Call the custom object engine to look for any custom object handlers that need to be executed.
            customEngine.LookForCustomObjects(operation.Value, endPoint.customEndPointObjects);

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
