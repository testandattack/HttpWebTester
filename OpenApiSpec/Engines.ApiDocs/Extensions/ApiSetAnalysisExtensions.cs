using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApiTestGenerator.Models.ApiAnalyzer;
using ApiTestGenerator.Models.ApiDocs;
using Newtonsoft.Json;
using Serilog;

namespace Engines.ApiDocs.Extensions
{
    public static class ApiSetAnalysisExtensions
    {
        public static void SerializeAndSaveApiSetAnalysis(this ApiSetAnalysis source, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(JsonConvert.SerializeObject(source, Formatting.Indented));
                }
                Log.ForContext<ApiSetAnalysis>().Information("SerializeAndSaveApiSetAnalysis completed successfully");
            }
            catch (Exception ex)
            {
                Log.ForContext<ApiSetAnalysis>().Error(ex, "[EXCEPTION] {callingMethod} failed.", "SerializeAndSaveApiSetAnalysis");
            }
        }

        public static ApiSetAnalysis LoadApiSetAnalysisFromFile(this ApiSetAnalysis source, string fileName)
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

        public static Dictionary<string, EndpointSummary> CopyEndpointSummary(this ApiSetAnalysis source)
        {
            Dictionary<string, EndpointSummary> summaries = new Dictionary<string, EndpointSummary>();
            foreach (var item in source.endpointSummaries)
            {
                summaries.Add(item.Key, item.Value.ShallowCopy());
            }

            return summaries;
        }

        public static void SetEndpointSummaryValues(this ApiSetAnalysis source, Dictionary<string, EndpointSummary> summaries)
        {
            source.endpointSummaries = summaries;
        }
    }
}
