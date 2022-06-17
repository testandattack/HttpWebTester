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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">The <c>ApiSetAnalysis</c> to which this method is exposed.</param>
        /// <returns></returns>
        public static Dictionary<string, EndpointSummary> CopyEndpointSummary(this ApiSetAnalysis source)
        {
            Dictionary<string, EndpointSummary> summaries = new Dictionary<string, EndpointSummary>();
            foreach (var item in source.endpointSummaries)
            {
                summaries.Add(item.Key, item.Value.ShallowCopy());
            }

            return summaries;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">The <c>ApiSetAnalysis</c> to which this method is exposed.</param>
        /// <param name="summaries"></param>
        public static void SetEndpointSummaryValues(this ApiSetAnalysis source, Dictionary<string, EndpointSummary> summaries)
        {
            source.endpointSummaries = summaries;
        }
    }
}
