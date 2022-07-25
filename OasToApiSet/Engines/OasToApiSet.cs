using ApiSet.Engines.Interfaces;
using ApiSet.Models.ApiDocs;
using ApiSet.Models.Enums;
using ApiSet.Models.Extensions;
using GTC.Extensions;
using GTC.HttpWebTester.Settings;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OasToApiSet.Extensions;

namespace ApiSet.Engines
{
    public class OasToApiSet : IApiSet
    {
        #region -- Properties -----
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IController _controllerEngine;
        private readonly IComponent _componentEngine;
        private readonly IEndpoint _endpointEngine;

        public ApiDoc apiDoc { get; set; }
        #endregion

        #region -- Constructors -----
        public OasToApiSet(ILogger logger
                            , ISettings settings
                            , IController controllerEngine
                            , IComponent componentEngine
                            , IEndpoint endpointEngine)
        {
            _settings = settings;
            _logger = logger;
            _controllerEngine = controllerEngine;
            _componentEngine = componentEngine;
            _endpointEngine = endpointEngine;
            apiDoc = new ApiDoc();
        }
        #endregion

        #region -- Methods -----
        public void BuildApiDoc(OpenApiDocument openApiDocument, string ApiRoot, Dictionary<string, string> extraInfo)
        {

        }
        #endregion

        #region -- Private Methods -----
        private void SetExtraInfo(string apiRootFromSettings, Dictionary<string, string> extraInfo)
        {
            if (extraInfo.ContainsKey("basePath"))
            {
                if (extraInfo["basePath"] != "")
                {
                    apiDoc.apiRoot = extraInfo["basePath"];
                    apiDoc.apiRootSourceLocation = ApiSet.Models.Enums.ApiRootSourceEnum.basePath;
                    return;
                }
            }
            if (apiRootFromSettings != string.Empty)
            {
                apiDoc.apiRoot = apiRootFromSettings;
                apiDoc.apiRootSourceLocation = ApiRootSourceEnum.settingsFile;
                return;
            }
            apiDoc.apiRoot = string.Empty;
            apiDoc.apiRootSourceLocation = ApiRootSourceEnum.empty;
        }

        private void GetSecurityInfo(OpenApiDocument openApiDocument)
        {
            apiDoc.GetSecurityRequirementInfo(openApiDocument.SecurityRequirements.ToList());
        }

        private void BuildControllerList(OpenApiDocument openApiDocument)
        {
            List<string> controllerNames = openApiDocument.GetAllOperationTags();

            int currentRequestId = 1;
            foreach (var path in openApiDocument.Paths)
            {
                Controller controller = GetController(path);
                currentRequestId = AddEndPoints(controller, path.Key, path.Value, currentRequestId);
            }
            AddRequestBodyItems(openApiDocument, apiDoc);
            AddResponseObjectDetails(openApiDocument, apiDoc);
        }

        private void BuildComponentList(OpenApiDocument openApiDocument)
        {
            int x = 0;
            Log.ForContext<OasToApiSet>().Information("[{method}]: Adding Components to ApiDoc", "BuildComponentList");
            foreach (var componentSchema in openApiDocument.Components.Schemas)
            {
                Log.ForContext<OasToApiSet>().Debug("[{method}]: {@ComponentSchema}", "BuildComponentList", componentSchema.Key);
                Component component = new Component();
                component.Name = componentSchema.Key;
                component.AddClassName(componentSchema.Value);

                if (componentSchema.Value.Type != null && componentSchema.Value.Type == "object")
                {
                    component.AddProperties(componentSchema.Value, componentSchema.Key);
                }
                apiDoc.Components.Add(componentSchema.Key, component);
                x++;
            }

        }

        private void AddServers(OpenApiDocument openApiDocument)
        {
            if (openApiDocument.Servers != null)
            {
                apiDoc.Servers = new List<OpenApiServer>();
                foreach (var server in openApiDocument.Servers)
                {
                    apiDoc.Servers.Add(server);
                }
            }
        }

        private Controller GetController(KeyValuePair<string, OpenApiPathItem> path)
        {
            // The path Key is the UriPath of the API endpoint. The controller name is
            // made by taking the first part of the path after the root.
            // Get the controller name that this path would belong to.


            string controllerName = GetControllerNameFromApiRoot(path.Key);
            foreach (var controller in apiDoc.Controllers.Values)
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
            apiDoc.Controllers.Add(controllerName, newController);
            Log.ForContext("SourceContext", "ApiSetEngine").Information("GetController: Made new Controller: {controllerName}", controllerName);
            return newController;
        }

        private string GetControllerNameFromApiRoot(string pathKey)
        {
            // Note, Need to make sure the string does not start with a '/' character.
            string cleanPathKey;
            if (pathKey.StartsWith("/") == true)
                cleanPathKey = pathKey.Substring(1);
            else
                cleanPathKey = pathKey;

            // Now get the first part of the URL
            switch (apiDoc.apiRootSourceLocation)
            {
                case ApiRootSourceEnum.basePath:
                case ApiRootSourceEnum.empty:
                    return cleanPathKey.GetLeftPart("/", false);

                case ApiRootSourceEnum.settingsFile:
                    return pathKey.FindSubString(apiDoc.apiRoot, "/", true);

                default:
                    return cleanPathKey.GetLeftPart("/", false);
            }
        }

        private int AddEndPoints(Controller controller, string pathUri, OpenApiPathItem path, int startingId)
        {
            OpenApiPathItem item = path;

            foreach (var operation in item.Operations)
            {
                var endpointEngine = new OasToEndpoint(operation, settings);
                startingId = endpointEngine.ParseEndpoint(controller, pathUri, startingId, item);
            }
            return startingId;
        }

        private void AddRequestBodyItems(OpenApiDocument openApiDocument, ApiDoc apiDoc)
        {
            foreach (Controller controller in apiDoc.Controllers.Values)
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

        private void AddResponseObjectDetails(OpenApiDocument openApiDocument, ApiDoc apiDoc)
        {
            foreach (Controller controller in apiDoc.Controllers.Values)
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

            try
            {
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
                else if (item.type == "string")
                {
                    item.reference = "";
                    item.format = "";
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

            }
            catch (Exception ex)
            {
                Log.ForContext<AbbreviatedResponseObject>().Error(ex, "Failed to build AbbreviatedResponseObject for {propertyName} in {endpointName}", property.Key, endPointName);
                item.reference = "Failed to parse the item";
            }
            return item;
        }
        #endregion


        #region -- Read and Write methods -----
        public void LoadApiDocFromFile(string fileName)
        {
            ApiDoc apiDoc = null;
            using (StreamReader sr = new StreamReader(fileName))
            {
                apiDoc = JsonConvert.DeserializeObject<ApiDoc>(sr.ReadToEnd());
            }
            if (apiDoc == null)
            {
                Log.ForContext<ApiDoc>().Error("LoadApiDocFromFile failed to load the set from {fileName}", fileName);
                throw new NullReferenceException($"LoadApiDocFromFile failed to load the set from {fileName}");
            }
        }

        public void SerializeAndSaveApiDoc()
        {
            string str = $"{apiDoc.settings.DefaultOutputLocation}\\OAS_ApiDoc {apiDoc.Info.Title}.json";
            SerializeAndSaveApiDoc(str);
        }

        public void SerializeAndSaveApiDoc(string fileName)
        {
            try
            {
                string str = JsonConvert.SerializeObject(this, Formatting.Indented);

                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(str);
                }
                Log.ForContext<ApiDoc>().Information("SerializeAndSaveApiDoc completed successfully");
            }
            catch (Exception ex)
            {
                Log.ForContext<ApiDoc>().Error(ex, "[EXCEPTION] {callingMethod} failed.", "SerializeAndSaveApiDoc");
            }
        }

        public void SaveListOfURLs(string fileName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Controller controller in apiDoc.Controllers.Values)
            {
                sb.Append($"----- {controller.Name} -----\r\n");
                foreach (EndPoint endPoint in controller.EndPoints.Values)
                {
                    sb.Append($"[{endPoint.Method}] {endPoint.UriPath}\r\n");
                }
                sb.Append("\r\n");
            }

            using (StreamWriter sw = new StreamWriter($"{apiDoc.settings.DefaultOutputLocation}\\{fileName}", false))
            {
                sw.Write(sb.ToString());
            }
        }

        public void BuildApiSet(OpenApiDocument openApiDocument, string ApiRoot, Dictionary<string, string> extraInfo)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

