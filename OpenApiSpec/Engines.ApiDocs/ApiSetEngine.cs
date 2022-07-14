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
using ApiDocs.CustomObjects;
using OpenApiUtilities;

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
        private Settings settings;

        public ApiSet apiSet { get; private set; }

        #region -- Constructors -----
        public ApiSetEngine() 
        {
            settings = new Settings();
        }

        public ApiSetEngine(Settings Settings)
        {
            settings = Settings;
        }

        public void BuildApiSet(OpenApiDocument openApiDocument, string ApiRoot, Dictionary<string, string> extraInfo)
        {
            apiSet = new ApiSet(ApiRoot, settings);
            // This call adds all of the custom objects that have been registered in the "ApiDocs.CustomObjects" namespace.
            //apiSet.CustomObjects.collection = AddAllCustomObjects.BuildCustomObjects();

            Log.ForContext("SourceContext", "ApiSetEngine").Information("BuildApiSetEngine: Starting parse of {@value1}", openApiDocument.Info);

            // First, take care of the basePath
            SetExtraInfo(ApiRoot, extraInfo);

            apiSet.Info = openApiDocument.Info;
            GetSecurityInfo(openApiDocument);
            AddServers(openApiDocument);
            BuildControllerList(openApiDocument);
            BuildComponentList(openApiDocument);
        }
        #endregion

        #region -- Public Methods -----
        public void SetExtraInfo(string apiRootFromSettings, Dictionary<string, string> extraInfo)
        {
            if (extraInfo.ContainsKey("basePath"))
            {
                if (extraInfo["basePath"] != "")
                {
                    apiSet.apiRoot = extraInfo["basePath"];
                    apiSet.apiRootSourceLocation = ApiTestGenerator.Models.Enums.ApiRootSourceEnum.basePath;
                    return;
                }
            }
            if(apiRootFromSettings != string.Empty)
            {
                apiSet.apiRoot = apiRootFromSettings;
                apiSet.apiRootSourceLocation = ApiRootSourceEnum.settingsFile;
                return;
            }
            apiSet.apiRoot = string.Empty;
            apiSet.apiRootSourceLocation = ApiRootSourceEnum.empty;
        }

        public void GetSecurityInfo(OpenApiDocument openApiDocument)
        {
            this.GetSecurityRequirementInfo(openApiDocument.SecurityRequirements.ToList());
        }

        public void BuildControllerList(OpenApiDocument openApiDocument)
        {
            int currentRequestId = 1;
            foreach (var path in openApiDocument.Paths)
            {
                Controller controller = GetController(path);
                currentRequestId = AddEndPoints(controller, path.Key, path.Value, currentRequestId);
            }
            AddRequestBodyItems(openApiDocument, apiSet);
            AddResponseObjectDetails(openApiDocument, apiSet);
        }

        public void BuildComponentList(OpenApiDocument openApiDocument)
        {
            int x = 0;
            Log.ForContext<ApiSetEngine>().Information("[{method}]: Adding Components to ApiSet", "BuildComponentList");
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

        public void AddServers(OpenApiDocument openApiDocument)
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
        private Controller GetController(KeyValuePair<string, OpenApiPathItem> path)
        {
            // The path Key is the UriPath of the API endpoint. The controller name is
            // made by taking the first part of the path after the root.
            // Get the controller name that this path would belong to,
            string controllerName = GetControllerName(path.Key);
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
            Log.ForContext("SourceContext", "ApiSetEngine").Information("GetController: Made new Controller: {controllerName}", controllerName);
            return newController;
        }

        private string GetControllerName(string pathKey)
        {
            // Note, Need to make sure the string does not start with a '/' character.
            string cleanPathKey;
            if (pathKey.StartsWith("/") == true)
                cleanPathKey = pathKey.Substring(1);
            else
                cleanPathKey = pathKey;

            // Now get the first part of the URL
            switch(apiSet.apiRootSourceLocation)
            {
                case ApiRootSourceEnum.basePath:
                case ApiRootSourceEnum.empty:
                    return cleanPathKey.GetLeftPart("/", false);

                case ApiRootSourceEnum.settingsFile:
                    return pathKey.FindSubString(apiSet.apiRoot, "/", true);

                default:
                    return cleanPathKey.GetLeftPart("/", false);
            }
        }

        private int AddEndPoints(Controller controller, string pathUri, OpenApiPathItem path, int startingId)
        {
            OpenApiPathItem item = path;

            foreach (var operation in item.Operations)
            {
                var endpointEngine = new EndPointEngine(operation, settings);
                startingId = endpointEngine.ParseEndpoint(controller, pathUri, startingId, item);
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
        public void LoadApiSetFromFile(string fileName)
        {
            ApiSet apiSet = null;
            using (StreamReader sr = new StreamReader(fileName))
            {
                apiSet = JsonConvert.DeserializeObject<ApiSet>(sr.ReadToEnd());
            }
            if (apiSet == null)
            {
                Log.ForContext<ApiSet>().Error("LoadApiSetFromFile failed to load the set from {fileName}", fileName);
                throw new NullReferenceException($"LoadApiSetFromFile failed to load the set from {fileName}");
            }
        }

        public void SerializeAndSaveApiSet(bool append = false)
        {
            string str = $"{apiSet.settings.DefaultOutputLocation}\\OAS_ApiSet {apiSet.Info.Title}.json";
            SerializeAndSaveApiSet(str, append);
        }

        public void SerializeAndSaveApiSet(string fileName, bool append = false)
        {
            try
            {
                string str = JsonConvert.SerializeObject(this, Formatting.Indented);

                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(str);
                }
                Log.ForContext<ApiSet>().Information("SerializeAndSaveApiSet completed successfully");
            }
            catch (Exception ex)
            {
                Log.ForContext<ApiSet>().Error(ex, "[EXCEPTION] {callingMethod} failed.", "SerializeAndSaveApiSet");
            }
        }

        public void SaveListOfURLs(string fileName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Controller controller in apiSet.Controllers.Values)
            {
                sb.Append($"----- {controller.Name} -----\r\n");
                foreach (EndPoint endPoint in controller.EndPoints.Values)
                {
                    sb.Append($"[{endPoint.Method}] {endPoint.UriPath}\r\n");
                }
                sb.Append("\r\n");
            }

            using (StreamWriter sw = new StreamWriter($"{apiSet.settings.DefaultOutputLocation}\\{fileName}", false))
            {
                sw.Write(sb.ToString());
            }
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
