using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApiTestGenerator.Models.ApiDocs;
using GTC.HttpWebTester.Settings;
using ApiTestGenerator.Models.ApiAnalyzer;
using ApiTestGenerator.Models.Enums;
using Engines.ApiDocs.Extensions;
using GTC.OpenApiUtilities;
using GTC.Extensions;
using Newtonsoft.Json;

namespace Engines.ApiDocs
{
    public class ApiSetAnalysisEngine
    {
        private ApiSet apiSet;
        private ApiSetSummaryModel summaryInfo;
        public Settings settings { get; private set; }

        public ApiSetAnalysis asa { get; set; }

        #region -- Constructors -----
        public ApiSetAnalysisEngine()
        {
            asa = new ApiSetAnalysis();
            apiSet = asa.apiSet;
            summaryInfo = asa.summaryInfo;
            asa.AnalysisName = summaryInfo.apiInfo.Title;
        }

        public ApiSetAnalysisEngine(ApiSet ApiSet, Settings Settings)
        {
            asa = new ApiSetAnalysis(ApiSet);
            
            apiSet = asa.apiSet;
            summaryInfo = asa.summaryInfo;
            summaryInfo.apiInfo = apiSet.Info;
            summaryInfo.apiRoot = apiSet.apiRoot;
            asa.AnalysisName = summaryInfo.apiInfo.Title;
            settings = Settings;
        }
        #endregion

        #region -- Public Methods -----
        public void PerformAnalysis()
        {
            if (settings.apiAnalysisSettings.AnalyzeApiEndpoints)
                AnalyzeApiEndpoints();
            if (settings.apiAnalysisSettings.AnalyzeApiEndpointsWithMultipleMethods)
                AnalyzeEndpointsWithMultipleMethods();
            if (settings.apiAnalysisSettings.AnalyzeRequestBodies)
                AnalyzeRequestBodies();
            if (settings.apiAnalysisSettings.AnalyzeApiComponents)
                AnalyzeApiComponents();
            if (settings.apiAnalysisSettings.AnalyzeInputParameters)
                AnalyzeInputParameters();
            if (settings.apiAnalysisSettings.AnalyzeProperties)
                AnalyzeProperties();
            if (settings.apiAnalysisSettings.AnalyzeLookupProperties)
                AnalyzeLookupProperties();
            if (settings.apiAnalysisSettings.AnalyzeInputParametersNotInProperties)
                AnalyzeInputParametersNotInProperties();
            if (settings.apiAnalysisSettings.AnalyzeInputParametersNotInLookupProperties)
                AnalyzeInputParametersNotInLookupProperties();
        }

        public void AnalyzeApiEndpoints()
        {
            Log.ForContext<ApiSetAnalysis>().Information("Executing [{method}]", "AnalyzeApiEndpoints");
            foreach (var controller in apiSet.Controllers.Values)
            {
                summaryInfo.numControllers++;
                foreach (var endPoint in controller.EndPoints)
                {
                    summaryInfo.numActiveEndpoints++;
                    if (asa.endpointSummaries.ContainsKey(endPoint.Key))
                    {
                        summaryInfo.numErrors++;
                        ApiSetAnalyzerError error = new ApiSetAnalyzerError("Duplicate Endpoint Name", endPoint);
                        AddAnalyzerError(summaryInfo.numErrors, AnalyzerErrorCategoryEnum.DuplicateEndpoint, error);
                    }
                    else
                    {
                        CreateEndpointSummary(endPoint);
                        if (endPoint.Value.UriPath.Contains("{"))
                            asa.endpointsWithUrlParams.Add(endPoint.Value.EndpointId);
                        else
                            asa.endpointsWithoutUrlParams.Add(endPoint.Value.EndpointId);
                    }

                    if (endPoint.Value.IsLookupMethod)
                    {
                        HandleLookupEndpoint(endPoint);
                    }
                }
            }
        }

        public void AnalyzeEndpointsWithMultipleMethods()
        {
            Dictionary<int, string> endpoints = new Dictionary<int, string>();
            foreach (var item in asa.endpointSummaries)
            {
                //string url = item.Key.Substring(item.Key.IndexOf("/api/"));
                string url = item.Key.Substring(item.Key.IndexOf(asa.summaryInfo.apiRoot));
                if(endpoints.ContainsValue(url) == true)
                {
                    if (asa.endpointsWithMultipleMethods.ContainsKey(url))
                    {
                        asa.endpointsWithMultipleMethods[url].Add(item.Value.endpointId, item.Key.FindSubString("_", " "));
                    }
                    else
                    {
                        var newDictionary = new Dictionary<int, string>();
                        newDictionary.Add(item.Value.endpointId, item.Key.FindSubString("_", " "));
                        asa.endpointsWithMultipleMethods.Add(url, newDictionary);
                    }
                }
                else
                {
                    endpoints.Add(item.Value.endpointId, url);

                    // We add every entry to the multiple list so we do not miss the first item
                    // from each multiple collection. We clear the singles out after we're done here.
                    var newDictionary = new Dictionary<int, string>();
                    newDictionary.Add(item.Value.endpointId, item.Key.FindSubString("_", " "));
                    asa.endpointsWithMultipleMethods.Add(url, newDictionary);
                }
            }

            // Here we clear out the single entries
            for (int x = asa.endpointsWithMultipleMethods.Count -1; x >=0; x--)
            {
                var item = asa.endpointsWithMultipleMethods.ElementAt(x);
                if(item.Value.Count == 1)
                {
                    asa.endpointsWithMultipleMethods.Remove(item.Key);
                }
            }
        }

        public void AnalyzeApiComponents()
        {
            Log.ForContext<ApiSetAnalysis>().Information("Executing [{method}]", "AnalyzeApiComponents");
            summaryInfo.numComponents = apiSet.Components.Count;
        }

        public void AnalyzeInputParameters()
        {
            Log.ForContext<ApiSetAnalysis>().Information("Executing [{method}]", "AnalyzeInputParameters");
            InputParameterAnalyzer inputParameterAnalyzer = new InputParameterAnalyzer();
            inputParameterAnalyzer.LoadInputParameters(this.apiSet);
            asa.inputParameters = inputParameterAnalyzer.InputParameters.OrderBy(ip => ip.Key).ToDictionary(ip => ip.Key, ip => ip.Value);
            summaryInfo.numInputProperties = asa.inputParameters.Count();
        }

        public void AnalyzeRequestBodies()
        {
            Log.ForContext<ApiSetAnalysis>().Information("Executing [{method}]", "AnalyzeRequestBodies");
            foreach (var endPointSummary in asa.endpointSummaries)
            {
                if (endPointSummary.Value.RequestBodyContentType != null)
                {
                    switch (endPointSummary.Value.RequestBodyContentType)
                    {
                        case RequestBodyContentTypeEnum.OAS_FormDataContentType:
                            asa.requestBodySummary.numOAS_FormDataContentType++;
                            break;
                        case RequestBodyContentTypeEnum.OAS_JsonContentType:
                            asa.requestBodySummary.numOAS_JsonContentType++;
                            break;
                        case RequestBodyContentTypeEnum.OAS_NoContentFound:
                            asa.requestBodySummary.numOAS_NoContentFound++;
                            break;
                        case RequestBodyContentTypeEnum.OAS_Other:
                            asa.requestBodySummary.numOAS_Other++;
                            break;
                        default:
                            break;
                    }

                    if (endPointSummary.Key.Contains("Post |"))
                    {
                        asa.requestBodySummary.numPostRequests++;
                    }
                    else if (endPointSummary.Key.Contains("Put |"))
                    {
                        asa.requestBodySummary.numPutRequests++;
                    }
                    else if (endPointSummary.Key.Contains("Patch |"))
                    {
                        asa.requestBodySummary.numPatchRequests++;
                    }
                    else
                    {
                        asa.requestBodySummary.numOtherRequestTypesWithBody++;
                        asa.requestBodySummary.endPointsWithInvalidRequestBody.Add(endPointSummary.Key);
                    }
                }
            }
        }

        //public void AnalyzeEndPointRestrictions()
        //{
        //    Log.ForContext<ApiSetAnalysis>().Information("Executing [{method}]", "AnalyzeEndPointRestrictions");
        //    foreach (var controller in apiSet.Controllers)
        //    {
        //        foreach (var endpoint in controller.Value.EndPoints)
        //        {
        //            RestrictTo restrictTo =
        //                endpoint.Value.customEndPointObjects.GetSpecificObject(CustomEndPointObjectTypeEnum.RestrictTo)
        //                as RestrictTo;
        //            if (restrictTo != null)
        //            {
        //                asa.endPointRestrictions.Add(endpoint.Key, restrictTo.RestrictToRoles.ToString(" "));
        //            }
        //            else
        //            {
        //                asa.endPointRestrictions.Add(endpoint.Key, "No RestrictTo Roles on EndPoint.");
        //            }
        //        }
        //    }
        //}

        //public void AnalyzeEndpointRestrictionSummary()
        //{
        //    Log.ForContext<ApiSetAnalysis>().Information("Executing [{method}]", "AnalyzeEndpointRestrictionSummary");
        //    asa.endpointRestrictionSummary = new EndpointRestrictionSummary();

        //    foreach (var controller in apiSet.Controllers)
        //    {
        //        foreach (var endpoint in controller.Value.EndPoints)
        //        {
        //            if (endpoint.Value.customEndPointObjects.Contains(CustomEndPointObjectTypeEnum.RestrictTo))
        //            {
        //                asa.endpointRestrictionSummary.AddSummaryInfoForEndPoint(endpoint.Value.customEndPointObjects.GetRestrictsToList(), endpoint.Key);
        //            }
        //        }
        //    }
        //}

        public void AnalyzeProperties()
        {
            Log.ForContext<ApiSetAnalysis>().Information("Executing [{method}]", "AnalyzeProperties");
            foreach (var component in apiSet.Components.Values)
            {
                foreach (var property in component.properties.Values)
                {
                    if (property.propertyParsingError != null)
                    {
                        summaryInfo.numErrors++;
                        ApiSetAnalyzerError error = new ApiSetAnalyzerError(
                            $"Found Property with missing type - {property.Name}", property);
                        AddAnalyzerError(summaryInfo.numErrors, AnalyzerErrorCategoryEnum.Property_MissingType, error);
                    }

                    PropertySummary summary = new PropertySummary(
                        property.Name,
                        property.Type,
                        property.Format,
                        property.Reference);
                    summary.IsInTheseComponents.Add(component.Name);

                    // See if it is the same item
                    if (asa.properties.Values.Contains(summary))
                    {
                        asa.properties.GetMatchingPropertySummary(summary)
                            .IsInTheseComponents.Add(component.Name);
                    }
                    else if (asa.properties.ContainsKey(summary.Name) == false)
                    {
                        asa.properties.Add(summary.Name, summary);
                    }
                    else
                    {
                        summaryInfo.numErrors++;
                        ApiSetAnalyzerError error = new ApiSetAnalyzerError(
                            $"Found Duplicate property entry - {summary.Name}", summary);
                        AddAnalyzerError(summaryInfo.numErrors, AnalyzerErrorCategoryEnum.DuplicateProperty, error);
                        if (asa.properties.ContainsKey($"{summary.Name} - {summary.Type}_{summary.Format}"))
                            Log.ForContext<ApiSetAnalysisEngine>().Error("Duplicate property that can't be added was found.");
                        else
                            asa.properties.Add($"{summary.Name} - {summary.Type}_{summary.Format}", summary);
                    }
                }
            }

            summaryInfo.propertyFormats = new List<string>();
            summaryInfo.propertyTypes = new List<string>();

            // Now add the summaries of types and formats
            foreach (var item in asa.properties.Values)
            {
                summaryInfo.propertyTypes.AddUnique(item.Type);
                summaryInfo.propertyFormats.AddUnique(item.Format);
            }
        }

        public void AnalyzeLookupProperties()
        {
            Log.ForContext<ApiSetAnalysis>().Information("Executing [{method}]", "AnalyzeLookupProperties");
            foreach (var component in asa.lookupComponents.Values)
            {
                foreach (var property in component.ResponseObject)
                {
                    // Add to list if not already there.
                    if (asa.lookupProperties.ContainsKey(property.Key) == false)
                    {
                        asa.lookupProperties.Add(property.Key, property.Value);
                    }
                    // If there, be sure the value is the same type. If not, add it with they type name appended
                    else if (asa.lookupProperties.ContainsKey($"{property.Key} - {property.Value.type}") == false
                        && asa.lookupProperties.Values.Contains(property.Value) == false)
                    {
                        asa.lookupProperties.Add($"{property.Key} - {property.Value.type}", property.Value);
                    }
                }
            }
            summaryInfo.numLookupProperties = asa.lookupProperties.Count();
        }

        public void AnalyzeInputParametersNotInLookupProperties()
        {
            foreach (var parameter in asa.inputParameters)
            {
                if (LookupPropertyListContainsInputParameter(parameter.Value) == false
                    && asa.inputParametersNotInLookupProperties.ContainsKey(parameter.Value.Name) == false)
                {
                    asa.inputParametersNotInLookupProperties.Add(parameter.Key, parameter.Value);
                }
            }
            summaryInfo.numInputParametersWithoutLookupProperty = asa.inputParametersNotInLookupProperties.Count();
        }

        public void AnalyzeInputParametersNotInProperties()
        {
            foreach (var parameter in asa.inputParameters)
            {
                if (PropertyListContainsInputParameter(parameter.Value) == false
                    && asa.inputParametersNotInProperties.ContainsKey(parameter.Value.Name) == false)
                {
                    asa.inputParametersNotInProperties.Add(parameter.Key, parameter.Value);
                }
            }
            summaryInfo.numInputParametersWithoutProperty = asa.inputParametersNotInProperties.Count();
        }
        #endregion

        #region -- Load and Save methods -----
        /// <summary>
        /// call this to make a table-like summary of the ApiSet to load into excel.
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveEndpointSummariesAsCsv(string fileName)
        {
            Log.ForContext<ApiSetAnalysis>().Information("Executing [{method}]", "SaveEndpointSummariesAsCsv");
            using (StreamWriter sw = new StreamWriter($"{settings.DefaultOutputLocation}\\{fileName}", false))
            {
                sw.WriteLine("Name,IsDepricated,HasSummary,IsLookup,NumberOfParams,NumberOfRequiredParams,CustomObjectTypes");
                foreach (var item in asa.endpointSummaries)
                {
                    sw.WriteLine($"{item.Key},{item.Value.ToString()}");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SerializeAndSaveApiSetAnalysis()
        {
            string str = $"{settings.DefaultOutputLocation}\\OAS_Analysis {asa.AnalysisName}.json";
            SerializeAndSaveApiSetAnalysis(str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public void SerializeAndSaveApiSetAnalysis(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(JsonConvert.SerializeObject(asa, Formatting.Indented));
                }
                Log.ForContext<ApiSetAnalysis>().Information("SerializeAndSaveApiSetAnalysis completed successfully");
            }
            catch (Exception ex)
            {
                Log.ForContext<ApiSetAnalysis>().Error(ex, "[EXCEPTION] {callingMethod} failed.", "SerializeAndSaveApiSetAnalysis");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public void LoadApiSetAnalysisFromFile(string fileName)
        {
            asa = null;
            using (StreamReader sr = new StreamReader(fileName))
            {
                asa = JsonConvert.DeserializeObject<ApiSetAnalysis>(sr.ReadToEnd());
            }
            if (asa == null)
            {
                Log.ForContext<ApiSetAnalysis>().Error("LoadApiSetAnalysisFromFile failed to load the set from {fileName}", fileName);
                throw new NullReferenceException($"LoadApiSetAnalysisFromFile failed to load the set from {fileName}");
            }
            asa.apiSet = new ApiSet();
        }
        #endregion

        #region -- Private Methods -----
        private void CreateEndpointSummary(KeyValuePair<string, EndPoint> endPoint)
        {
            // Endpoint Summary
            EndpointSummary summary = new EndpointSummary();
            summary.BuildEndpointSummary(endPoint.Value);

            if (endPoint.Value.ResponseItems != null)
            {
                AddResponseStatuses(endPoint.Value.ResponseItems.Keys.ToList());
                AnalyzeResponseObjectProperties(endPoint.Value.ResponseItems.Values.ToList(), endPoint.Key);
            }

            string endpointSummaryName = endPoint.Key;
            if (summary.IsDepricated)
            {
                endpointSummaryName = $"Depricated - {endpointSummaryName}";
                summaryInfo.numDepricated++;
                summaryInfo.numActiveEndpoints--;
                asa.depricatedEndpoints.Add(endpointSummaryName);
            }
            if (summary.IsTestMethod)
            {
                endpointSummaryName = $"TestMethod - {endpointSummaryName}";
                summaryInfo.numTestMethods++;
            }

            asa.endpointSummaries.Add($"{endPoint.Value.EndpointId}_{endpointSummaryName}", summary);

            summaryInfo.NumEndpointsWithExample += summary.NumberOfParamsWithExample;
            summaryInfo.NumEndpointsWithExamples += summary.NumberOfParamsWithExamples;
        }

        private void AddResponseStatuses(List<string> statuses)
        {
            foreach (string status in statuses)
            {
                if (summaryInfo.responseStatuses.Contains(status) == false)
                {
                    summaryInfo.responseStatuses.Add(status);
                }
            }
        }

        private void AnalyzeResponseObjectProperties(List<ResponseObject> objects, string endpointName)
        {
            foreach (var responseObject in objects)
            {
                foreach (var item in responseObject.abbreviatedResponseObjects)
                {
                    if (item.Value.type == ParseTokens.PARAM_MissingTypeField)
                    {
                        // Found a response object with an unknown type
                        summaryInfo.numErrors++;
                        ApiSetAnalyzerError error = new ApiSetAnalyzerError($"Found response object in {endpointName} with missing type.", item);
                        AddAnalyzerError(summaryInfo.numErrors, AnalyzerErrorCategoryEnum.ResponseObject_MissingType, error);
                    }
                }
            }
        }

        private void HandleLookupEndpoint(KeyValuePair<string, EndPoint> endPoint)
        {
            // Add to the main Lookups collection
            summaryInfo.numLookupEndpoints++;
            asa.lookupEndpoints.Add(endPoint.Key,
                new LookupEndPoint(
                    endPoint.Value.controllerName
                    , endPoint.Value.ResponseItems));

            // Now handle the lookups by Dto name collection
            AddLookupByDtoName(endPoint.Value, endPoint.Key);
        }

        private void AddLookupByDtoName(EndPoint endPoint, string endpointName)
        {
            foreach (var responseItem in endPoint.ResponseItems)
            {
                if (responseItem.Value.ResponseObjectName != string.Empty)

                    if (asa.lookupComponents.ContainsKey(responseItem.Value.ResponseObjectName))
                    {
                        // Already has the DTO Object, Add the endpoint name to the List of items returning this DTO
                        if (false == asa.lookupComponents[responseItem.Value.ResponseObjectName].AddEndpointNameSafely($"{endpointName}-{responseItem.Key}"))
                        {
                            // Found that the endpoint was already in the list. Something went wrong.
                            summaryInfo.numErrors++;
                            ApiSetAnalyzerError error = new ApiSetAnalyzerError("Found Duplicate Lookup endpoint for Response Object", $"{endpointName}-{responseItem.Key}");
                            AddAnalyzerError(summaryInfo.numErrors, AnalyzerErrorCategoryEnum.DuplicateLookupEndpoint, error);
                        }
                    }
                    else
                    {
                        // Not already there, add it
                        asa.lookupComponents.Add(responseItem.Value.ResponseObjectName, new LookupComponent(endpointName, responseItem.Value.ResponseObjectName, responseItem.Value.ResponseObjectType, responseItem.Value.abbreviatedResponseObjects));
                        summaryInfo.numLookupComponents++;
                    }
            }
        }

        private void AddAnalyzerError(int errorNum, AnalyzerErrorCategoryEnum category, ApiSetAnalyzerError error)
        {
            string errorCategory = $"{errorNum}-{category.ToString()}";
            asa.analyzerErrors.Add(errorCategory, error);
        }

        private bool LookupPropertyListContainsInputParameter(InputParameter inputParameter)
        {
            foreach (var item in asa.lookupProperties)
            {
                if (CompareParameterToResponseObject(inputParameter, item.Key, item.Value.type, item.Value.format) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private bool PropertyListContainsInputParameter(InputParameter inputParameter)
        {
            foreach (var item in asa.properties)
            {
                if (CompareParameterToResponseObject(inputParameter, item.Key, item.Value.Type, item.Value.Format) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CompareParameterToResponseObject(InputParameter parameter, string responseName, string responseType, string responseFormat)
        {

            if (parameter.Name != responseName)
                return false;
            if (parameter.Type != responseType)
                return false;
            if (parameter.Format != responseFormat)
                return false;

            return true;
        }
        #endregion
    }
}
