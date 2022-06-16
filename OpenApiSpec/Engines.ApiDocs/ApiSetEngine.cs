using ApiTestGenerator.Models.Consts;
using ApiTestGenerator.Models.Enums;
using Engines.ApiDocs.Extensions;
using ApiTestGenerator.Models.ApiDocs;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.OpenApi.Writers;
using System.IO;
using GTC.Extensions;
using System.Text.RegularExpressions;
using GTC.HttpWebTester.Settings;

namespace Engines.ApiDocs
{
    /// <summary>
    /// A collection of objects and information that cn be used to 
    /// generate webtests for the API.
    /// </summary>
    /// <remarks>
    /// This set of information is language agnostic and built from OpenApi 
    /// Documentation so that it can be consumed by test creation software
    /// directly. The reason for this extra step is because the ApiSet object
    /// incorporates custom code and OpenApiSchema extensions that enhance
    /// the swagger documentation way beyond the normal information available.
    /// </remarks>
    public class ApiSetEngine
    {

        #region -- Constructors -----
        public ApiSetEngine() { }

        public ApiSet BuildApiSet(OpenApiDocument openApiDocument, string ApiRoot)
        {
            Settings settings = new Settings();

            ApiSet apiSet = new ApiSet(ApiRoot, settings);
            Log.ForContext("SourceContext", "ApiSetEngine").Debug("BuildApiSetEngine: Starting parse of {@value1}", openApiDocument.Info);
            apiSet.Info = openApiDocument.Info;
            GetSecurityInfo(openApiDocument, apiSet);
            AddServers(openApiDocument, apiSet);
            BuildControllerList(openApiDocument, apiSet);
            BuildComponentList(openApiDocument, apiSet);
            return apiSet;
        }
        #endregion

        #region -- Public Methods -----
        public void GetSecurityInfo(OpenApiDocument openApiDocument, ApiSet apiSet)
        {
            apiSet.GetSecurityRequirementInfo(openApiDocument.SecurityRequirements.ToList());
        }

        public void BuildControllerList(OpenApiDocument openApiDocument, ApiSet apiSet)
        {
            int currentRequestId = 1;
            foreach (var path in openApiDocument.Paths)
            {
                Controller controller = GetController(path, apiSet);
                currentRequestId = AddEndPoints(controller, path.Key, path.Value, currentRequestId);
            }
            AddRequestBodyItems(openApiDocument, apiSet);
            AddResponseObjectDetails(openApiDocument, apiSet);
        }

        public void BuildComponentList(OpenApiDocument openApiDocument, ApiSet apiSet)
        {
            int x = 0;
            foreach (var componentSchema in openApiDocument.Components.Schemas)
            {
                Log.ForContext<ApiSetEngine>().Debug("[{method}]: {@ComponentSchema}", "BuildComponentList", componentSchema.Key);
                Component component = new Component();
                component.Name = componentSchema.Key;
                component.AddClassName(componentSchema.Value);

                if (componentSchema.Value.Type != null && componentSchema.Value.Type == "object")
                {
                    component.AddProperties(componentSchema.Value, componentSchema.Key);
                }
                apiSet.Components.Add(componentSchema.Key, component);
                x++;
            }

        }

        public void AddServers(OpenApiDocument openApiDocument, ApiSet apiSet)
        {
            if (openApiDocument.Servers != null)
            {
                apiSet.Servers = new List<OpenApiServer>();
                foreach (var server in openApiDocument.Servers)
                {
                    apiSet.Servers.Add(server);
                }
            }
        }
        #endregion

        #region -- Private Methods -----
        private Controller GetController(KeyValuePair<string, OpenApiPathItem> path, ApiSet apiSet)
        {
            // The path Key is the UriPath of the API endpoint. The controller name is
            // made by taking the first part of the path after the root.
            // Get the controller name that this path would belong to,
            string controllerName = path.Key.FindSubString(apiSet.apiRoot, "/", true);
            foreach (var controller in apiSet.Controllers.Values)
            {
                if (controller.Name == controllerName)
                {
                    Log.ForContext("SourceContext", "ApiSetEngine").Debug("GetController: found existing Controller: {controllerName}", controllerName);
                    return controller;
                }
            }

            // Didn't find a controller. Make a new one and return it.
            Controller newController = new Controller();
            newController.Name = controllerName;
            apiSet.Controllers.Add(controllerName, newController);
            Log.ForContext("SourceContext", "ApiSetEngine").Debug("GetController: Made new Controller: {controllerName}", controllerName);
            return newController;
        }

        private int AddEndPoints(Controller controller, string pathUri, OpenApiPathItem path, int startingId)
        {
            OpenApiPathItem item = path;

            foreach (var operation in item.Operations)
            {
                Log.ForContext<Controller>().Debug("[{method}]: Adding {@OpenApiPathItem} {OpenApiMethod}", "AddEndPoint", pathUri, operation.Key);
                EndPoint endPoint = new EndPoint(controller.Name);
                endPoint.EndpointId = startingId;

                endPoint.UriPath = pathUri;
                endPoint.Method = operation.Key.ToString();
                endPoint.Depricated = operation.Value.Deprecated;

                endPoint.Summary = operation.Value.Summary;
                if (operation.Value.Summary != null && operation.Value.Summary.Contains(ParserTokens.DESC_ForTestingPurposes))
                {
                    endPoint.IsForTestingPurposes = true;
                }

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
                endPoint.AddRestrictions(operation.Value);
                endPoint.AddMethodsThatUseThisResponse(operation.Value);
                endPoint.AddSourceMethodName(operation.Value);
                endPoint.AddTestDataFilter(operation.Value);
                endPoint.CheckFor_IsLookupMethod(operation.Value);

                if (endPoint.Method.ToUpper() == "POST" || endPoint.Method.ToUpper() == "PUT")
                {
                    endPoint.AddRequestBody(operation.Value);
                }
                endPoint.AddResponseItems(operation.Value);

                string endPointKey = $"{endPoint.Method} | {endPoint.UriPath}";
                controller.EndPoints.Add(endPointKey, endPoint);
                startingId++;
            }
            return startingId;
        }

        private void AddRequestBodyItems(OpenApiDocument openApiDocument, ApiSet apiSet)
        {
            foreach (Controller controller in apiSet.Controllers.Values)
            {
                foreach (var endPoint in controller.EndPoints)
                {
                    if (endPoint.Value.requestBody != null
                        && endPoint.Value.requestBody.RequestBodySchemaType == "object"
                        && endPoint.Value.requestBody.RequestBodyContentType == ParserTokens.OAS_JsonContentType)
                    {
                        var stringWriter = new StringWriter();
                        OpenApiJsonWriter writer = new OpenApiJsonWriter(stringWriter);
                        openApiDocument.Components.Schemas[endPoint.Value.requestBody.RequestBodyJsonObject].SerializeAsV3WithoutReference(writer);
                        writer.Flush();
                        Log.ForContext<Controller>().Debug("[{method}]: Adding request body string to {OpenApiMethod}", "AddRequestBodyItems", endPoint.Key);
                        endPoint.Value.requestBody.RequestBodyString = stringWriter.ToString().ToJsonCompact();
                    }
                }
            }
        }

        private void AddResponseObjectDetails(OpenApiDocument openApiDocument, ApiSet apiSet)
        {
            foreach (Controller controller in apiSet.Controllers.Values)
            {
                foreach (var endPoint in controller.EndPoints.Values)
                {
                    foreach (var responseItem in endPoint.ResponseItems.Values)
                    {
                        if (responseItem.ResponseObjectType == ResponseTypeEnum.Object
                            || responseItem.ResponseObjectType == ResponseTypeEnum.List_Object)
                        {
                            if (openApiDocument.Components.Schemas.ContainsKey(responseItem.ResponseObjectName))
                            {
                                foreach (var property in openApiDocument.Components.Schemas[responseItem.ResponseObjectName].Properties)
                                {
                                    responseItem.abbreviatedResponseObjects.Add(property.Key
                                        , BuildAndAddAbbreviatedResponseObject(property
                                        , $"{endPoint.UriPath} | {endPoint.Method}"));
                                    ;
                                }
                            }
                        }
                    }
                }
            }
        }

        private AbbreviatedResponseObject BuildAndAddAbbreviatedResponseObject(KeyValuePair<string, OpenApiSchema> property, string endPointName)
        {
            Log.ForContext<AbbreviatedResponseObject>().Debug("[{method}]: Adding AbbreviatedResponseObject to {EndPoint}."
                , "BuildAndAddAbbreviatedResponseObject", endPointName);
            AbbreviatedResponseObject item = new AbbreviatedResponseObject();

            #region -- handle Type -----
            // Even though Type is a required field, SwaggerGen does not handle
            // the C# type "Dynamic" properly, so we have to account for it here.
            if (property.Value.Type == null)
            {
                item.type = ParserTokens.PARAM_MissingTypeField;
                Log.ForContext<AbbreviatedResponseObject>().Warning("[{method}]: Found ResponseObject in {EndPoint} without a Type. Assuming it is of type Dynamic"
                    , "BuildAndAddAbbreviatedResponseObject", endPointName);
            }
            else
                item.type = property.Value.Type;
            #endregion

            #region -- handle Nullable -----
            if (property.Value.Nullable == true)
                item.nullable = "true";
            else
                item.nullable = "false";
            #endregion

            if (item.type == "array")
            {
                #region -- handle Reference -----
                if (property.Value.Items.Reference != null)
                    item.reference = property.Value.Items.Reference.Id;
                else if (property.Value.Items.Type != null)
                    item.reference = property.Value.Items.Type;
                else
                    item.reference = ParserTokens.PARAM_MissingInfo;
                #endregion

                #region -- handle Format -----
                if (property.Value.Items.Format != null)
                    item.format = property.Value.Items.Format;
                else
                    item.format = string.Empty;
                #endregion
            }
            else
            {
                #region -- handle Reference -----
                if (property.Value.Reference != null)
                    item.reference = property.Value.Reference.ReferenceV3;
                else
                    item.reference = string.Empty;
                #endregion

                #region -- handle Format -----
                if (property.Value.Format != null)
                    item.format = property.Value.Format;
                else
                    item.format = string.Empty;
                #endregion
            }

            return item;
        }
        #endregion


    }

    public static class JsonStringExtensions
    {

        public static string ToJsonCompact(this string source)
        {
            // First see if we are using full CR-LF or just LF
            if (source.Contains("\r\n"))
            {
                source = source.Replace("\r\n", "");
            }
            else
            {
                source = source.Replace("\n", "");
            }
            return Regex.Replace(source, @"\s+", " ");
        }

    }
}
