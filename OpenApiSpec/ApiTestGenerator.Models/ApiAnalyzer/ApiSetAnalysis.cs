using ApiTestGenerator.Models.ApiDocs;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;

namespace ApiTestGenerator.Models.ApiAnalyzer
{
    public class ApiSetAnalysis
    {
        #region -- Properties -----
        /// <summary>
        /// The <see cref="ApiDocs"/> object to analyze
        /// </summary>
        [JsonIgnore]
        public ApiSet apiSet { get; set; }

        /// <summary>
        /// A collection of <see cref="EndpointSummary"/> items found while analyzing the ApiSet.
        /// </summary>
        [JsonIgnore]
        public SortedDictionary<string, EndpointSummary> sortedEndpointSummaries { get; private set; }


        /// <summary>
        /// <see cref="ApiSetSummaryModel"/>
        /// </summary>
        public ApiSetSummaryModel summaryInfo { get; set; }

        /// <summary>
        /// A collection of <see cref="ApiSetAnalyzerError"/> items found while analyzing the ApiSet.
        /// </summary>
        public Dictionary<string, ApiSetAnalyzerError> analyzerErrors { get; set; }

        /// <summary>
        /// A list of every endpoint with an <see cref="EndpointSummary"/> for each one.
        /// </summary>
        public Dictionary<string, EndpointSummary> endpointSummaries { get; private set; }

        public Dictionary<string, List<int>> endpointsWithMultipleMethods { get; private set; }

        /// <summary>
        /// A list showing the quantities and types of request bodies in the API
        /// </summary>
        public RequestBodySummary requestBodySummary { get; private set; }

        /// <summary>
        /// A list of all the <see cref="ApiDocs.Engines.Parameter"/> items.
        /// these are all of the items that will be used at some point as
        /// inpouts to the API calls.
        /// </summary>
        public Dictionary<string, InputParameter> inputParameters { get; set; }

        /// <summary>
        /// A list of all the <see cref="ApiDocs.Engines.Property"/> items. 
        /// This lists all of the primitive values that get returned as part
        /// of the response objects.
        /// </summary>
        public SortedDictionary<string, PropertySummary> properties { get; set; }

        /// <summary>
        /// A list of the different RestrictTo filters in the API along with
        /// all of the endpoints that use the filter.
        /// </summary>
        public EndpointRestrictionSummary endpointRestrictionSummary { get; set; }

        /// <summary>
        /// A list of every endpoint showing what filter restrictions it allows.
        /// </summary>
        public Dictionary<string, string> endPointRestrictions { get; set; }

        /// <summary>
        /// A collection of <see cref="LookupEndPoint"/> items
        /// </summary>
        public SortedDictionary<string, LookupEndPoint> lookupEndpoints { get; private set; }

        /// <summary>
        /// A collection of <see cref="LookupComponent"/> items
        /// </summary>
        public SortedDictionary<string, LookupComponent> lookupComponents { get; private set; }

        /// <summary>
        /// A collection of <see cref="Property"/> objects that are in components that act 
        /// as responses to Lookup Endpoints.
        /// </summary>
        public SortedDictionary<string, AbbreviatedResponseObject> lookupProperties { get; private set; }

        /// <summary>
        /// A list of the <see cref="InputParameter"/>s that do not have matching entries in
        /// the <see cref="properties"/> collection.
        /// </summary>
        public SortedDictionary<string, InputParameter> inputParametersNotInProperties { get; private set; }

        /// <summary>
        /// A list of the <see cref="InputParameter"/>s that do not have matching entries in
        /// the <see cref="lookupProperties"/> collection.
        /// </summary>
        public SortedDictionary<string, InputParameter> inputParametersNotInLookupProperties { get; private set; }


        /// <summary>
        /// A list of all endpoints that have the 'Depricated' attribute.
        /// </summary>
        public List<string> depricatedEndpoints { get; private set; }

        public List<int> endpointsWithoutUrlParams { get; set; }
        public List<int> endpointsWithUrlParams { get; set; }
        #endregion

        #region -- Constructors -----
        public ApiSetAnalysis()
        {
            apiSet = new ApiSet();
            summaryInfo = new ApiSetSummaryModel();
            InitializeCollections();
        }

        public ApiSetAnalysis(ApiSet ApiSet)
        {
            apiSet = ApiSet;
            summaryInfo = new ApiSetSummaryModel();
            summaryInfo.apiInfo = apiSet.Info;
            InitializeCollections();
        }

        private void InitializeCollections()
        {
            requestBodySummary = new RequestBodySummary();
            lookupEndpoints = new SortedDictionary<string, LookupEndPoint>();
            lookupComponents = new SortedDictionary<string, LookupComponent>();
            endpointSummaries = new Dictionary<string, EndpointSummary>();
            endpointsWithMultipleMethods = new Dictionary<string, List<int>>();
            analyzerErrors = new Dictionary<string, ApiSetAnalyzerError>();
            inputParameters = new Dictionary<string, InputParameter>();
            endPointRestrictions = new Dictionary<string, string>();
            properties = new SortedDictionary<string, PropertySummary>();
            lookupProperties = new SortedDictionary<string, AbbreviatedResponseObject>();
            inputParametersNotInLookupProperties = new SortedDictionary<string, InputParameter>();
            inputParametersNotInProperties = new SortedDictionary<string, InputParameter>();
            depricatedEndpoints = new List<string>();
            endpointsWithoutUrlParams = new List<int>();
            endpointsWithUrlParams = new List<int>();
        }
        #endregion


        #region -- Read and Write methods -----
        public void SerializeAndSaveApiSetAnalysis(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
                }
                Log.ForContext<ApiSetAnalysis>().Information("SerializeAndSaveApiSetAnalysis completed successfully");
            }
            catch (Exception ex)
            {
                Log.ForContext<ApiSetAnalysis>().Error(ex, "[EXCEPTION] {callingMethod} failed.", "SerializeAndSaveApiSetAnalysis");
            }
        }

        public static ApiSetAnalysis LoadApiSetAnalysisFromFile(string fileName)
        {
            ApiSetAnalysis apiSetAnalysis = null;
            using (StreamReader sr = new StreamReader(fileName))
            {
                apiSetAnalysis = JsonConvert.DeserializeObject<ApiSetAnalysis>(sr.ReadToEnd());
            }
            if (apiSetAnalysis == null)
            {
                Log.ForContext<ApiSetAnalysis>().Error("LoadApiSetAnalysisFromFile failed to load the set from {fileName}", fileName);
                throw new NullReferenceException($"LoadApiSetAnalysisFromFile failed to load the set from {fileName}");
            }
            apiSetAnalysis.apiSet = new ApiSet();
            return apiSetAnalysis;
        }

        public static Dictionary<int, EndpointParsingData> GetEndpointParsingData(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                var analysis = JsonConvert.DeserializeObject<ApiSetAnalysis>(sr.ReadToEnd());

                Dictionary<int, EndpointParsingData> data = new Dictionary<int, EndpointParsingData>();
                foreach (var item in analysis.endpointSummaries.Values)
                {
                    data.Add(item.endpointParsingData.EndpointId, item.endpointParsingData);
                }
                return data;
            }

        }

        public Dictionary<string, EndpointSummary> CopyEndpointSummary()
        {
            Dictionary<string, EndpointSummary> summaries = new Dictionary<string, EndpointSummary>();
            foreach(var item in endpointSummaries)
            {
                summaries.Add(item.Key, item.Value.ShallowCopy());
            }

            return summaries;
        }

        public void SetEndpointSummaryValues(Dictionary<string, EndpointSummary> summaries)
        {
            endpointSummaries = summaries;
        }
        #endregion
    }
}
