using ApiTestGenerator.Models.ApiDocs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;

namespace Engines.ApiDocs.Extensions
{
    public static class ApiSetEngineExtensions
    {
        /// <summary>
        /// call this to save a base list of all operations
        /// </summary>
        /// <param name="source">The <c>ApiSetEngine</c> to which this method is exposed.</param>
        /// <param name="fileName"></param>
        public static void SaveListOfURLs(this ApiSetEngine source, string fileName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Controller controller in source.apiSet.Controllers.Values)
            {
                sb.Append($"----- {controller.Name} -----\r\n");
                foreach (EndPoint endPoint in controller.EndPoints.Values)
                {
                    sb.Append($"[{endPoint.Method}] {endPoint.UriPath}\r\n");
                }
                sb.Append("\r\n");
            }

            using (StreamWriter sw = new StreamWriter($"{source.apiSet.settings.DefaultOutputLocation}\\{fileName}", false))
            {
                sw.Write(sb.ToString());
            }
        }

        /// <summary>
        /// call this to retrieve a list of all operations in string format
        /// </summary>
        /// <param name="source">The <c>ApiSetEngine</c> to which this method is exposed.</param>
        public static string GetListOfURLs(this ApiSetEngine source)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Controller controller in source.apiSet.Controllers.Values)
            {
                sb.Append($"----- {controller.Name} -----\r\n");
                foreach (EndPoint endPoint in controller.EndPoints.Values)
                {
                    sb.Append($"[{endPoint.Method}] {endPoint.UriPath}\r\n");
                }
                sb.Append("\r\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Calls all the individual extraInfo extension methods
        /// </summary>
        /// <param name="source">The <c>ApiSetEngine</c> to which this method is exposed.</param>
        /// <param name="extraInfo"></param>
        public static void AddCoreInfo(this ApiSetEngine source, Dictionary<string, string> extraInfo)
        {
            source.SetOasVersion(extraInfo);
            source.SetSchemes(extraInfo);
        }

        /// <summary>
        /// Sets the Open API Scec version used for the document
        /// </summary>
        /// <param name="source">The <c>ApiSetEngine</c> to which this method is exposed.</param>
        /// <param name="extraInfo"></param>
        public static void SetOasVersion(this ApiSetEngine source, Dictionary<string, string> extraInfo)
        {
            if(extraInfo.ContainsKey("OAS Version"))
            {
                source.apiSet.OasVersion = extraInfo["OAS Version"];
            }
        }

        /// <summary>
        /// Gets any schemes that were defined in the OAS document [OAS v2.x only]
        /// </summary>
        /// <param name="source">The <c>ApiSetEngine</c> to which this method is exposed.</param>
        /// <param name="extraInfo">A dictionary of extra data retrieved during the initial reading of the serialized OAS document.</param>
        public static void SetSchemes(this ApiSetEngine source, Dictionary<string, string> extraInfo)
        {
            if (extraInfo.ContainsKey("Schemes"))
            {
                source.apiSet.Schemes = new List<string>();

                foreach(string str in extraInfo["Schemes"].Split(","))
                {
                    source.apiSet.Schemes.Add(str.Trim().Replace("\"", ""));
                }
            }
        }

        public static void GetSecuritySchemeInfo(this ApiSetEngine source, OpenApiSecurityScheme scheme)
        {
            if(scheme != null)
            {
                source.apiSet.SecuritySchemes.Add(scheme);
            }
        }

        public static void GetSecurityRequirementInfo(this ApiSetEngine source, List<OpenApiSecurityRequirement> requirements)
        {
            if (requirements != null)
            {
                foreach(var requirement in requirements)
                {
                    foreach (var key in requirement.Keys)
                    {
                        source.GetSecuritySchemeInfo(key);
                    }
                }
            }
        }
    }
}
