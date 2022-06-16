using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GTC.HttpWebTester.Settings;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiSet
    {
        #region -- Properties -----
        [JsonIgnore]
        public Settings settings { get; set; }

        /// <summary>
        /// The left part of the UriStem that comes before 'controller' names.
        /// </summary>
        public string apiRoot { get; set; }

        /// <summary>
        /// The Open API Specification version used for creating the document.
        /// </summary>
        public string OasVersion { get; set; }

        /// <summary>
        /// Contains the <see cref="OpenApiInfo"/> object from the Swagger Documentation
        /// </summary>
        [JsonProperty(PropertyName = "info", NullValueHandling = NullValueHandling.Ignore)]
        public OpenApiInfo Info { get; set; }

        /// <summary>
        /// A list of <see cref="OpenApiServer"/> objects
        /// </summary>
        [JsonProperty(PropertyName = "servers", NullValueHandling = NullValueHandling.Ignore)]
        public List<OpenApiServer> Servers { get; set; }

        /// <summary>
        /// A list of <see cref="Controller"/> objects
        /// </summary>
        public Dictionary<string, Controller> Controllers { get; private set; }

        /// <summary>
        /// A list of <see cref="Component"/> objects
        /// </summary>
        //public SortedDictionary<string,Component> Components { get; private set; }
        public Dictionary<string, Component> Components { get; private set; }

        /// <summary>
        /// The list of OpenApiSecuritySchemes associated with this OAS Document
        /// </summary>
        public List<OpenApiSecurityScheme> SecuritySchemes { get; private set; }

        /// <summary>
        /// The transfer protocos(s) used by the API. [OAS v2.x only]
        /// </summary>
        [JsonProperty(PropertyName = "Schemes", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Schemes { get; set; }
        #endregion

        #region -- Constructors -----
        /// <summary>
        /// Creates a new empty ApiSet instance.
        /// </summary>
        public ApiSet()
        {
            Initialize(string.Empty, null);
        }

        /// <summary>
        /// Creates a new empty ApiSet instance using the provided <paramref name="settings"/> object.
        /// </summary>
        /// <param name="settings"></param>
        public ApiSet(Settings settings)
        {
            Initialize(string.Empty, settings);
        }

        /// <summary>
        /// Creates a new ApiSet instance using the provided <paramref name="ApiRoot"/> and <paramref name="settings"/> objects.
        /// </summary>
        /// <param name="ApiRoot"></param>
        /// <param name="settings"></param>
        public ApiSet(string ApiRoot, Settings settings)
        {
            Initialize(ApiRoot, settings);
        }

        private void Initialize(string ApiRoot, Settings Settings)
        {
            settings = Settings;
            apiRoot = ApiRoot;
            Controllers = new Dictionary<string, Controller>();
            Components = new Dictionary<string, Component>();
            SecuritySchemes = new List<OpenApiSecurityScheme>();
        }
        #endregion

        #region -- Read and Write methods -----
        public static ApiSet LoadApiSetFromFile(string fileName)
        {
            ApiSet apiSet = null;
            using (StreamReader sr = new StreamReader(fileName))
            {
                apiSet = JsonConvert.DeserializeObject<ApiSet>(sr.ReadToEnd());
            }
            if(apiSet == null)
            {
                Log.ForContext<ApiSet>().Error("LoadApiSetFromFile failed to load the set from {fileName}", fileName);
                throw new NullReferenceException($"LoadApiSetFromFile failed to load the set from {fileName}");
            }
            return apiSet;
        }

        public void SerializeAndSaveApiSet(bool append = false)
        {
            SerializeAndSaveApiSet(settings.DefaultOutputLocation, append);
        }

        public void SerializeAndSaveApiSet(string fileName, bool append = false)
        {
            try
            {
                string filePath = fileName + "\\ApiSet.json";

                string str = JsonConvert.SerializeObject(this, Formatting.Indented);

                using (StreamWriter sw = new StreamWriter(filePath, false))
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

            foreach (Controller controller in Controllers.Values)
            {
                sb.Append($"----- {controller.Name} -----\r\n");
                foreach (EndPoint endPoint in controller.EndPoints.Values)
                {
                    sb.Append($"[{endPoint.Method}] {endPoint.UriPath}\r\n");
                }
                sb.Append("\r\n");
            }

            using (StreamWriter sw = new StreamWriter($"{settings.DefaultOutputLocation}\\{fileName}", false))
            {
                sw.Write(sb.ToString());
            }
        }

        #endregion
    }
}
