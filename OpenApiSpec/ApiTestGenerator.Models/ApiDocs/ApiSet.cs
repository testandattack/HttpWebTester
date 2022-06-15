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
    public class ApiSet
    {
        #region -- Properties -----
        [JsonIgnore]
        public Settings settings { get; set; }

        [JsonIgnore]
        public string apiRoot { get; set; }

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
        #endregion

        #region -- Constructors -----
        public ApiSet()
        {
            Controllers = new Dictionary<string, Controller>();
            Components = new Dictionary<string, Component>();
            apiRoot = string.Empty;
        }

        public ApiSet(string ApiRoot)
        {
            apiRoot = ApiRoot;
            Controllers = new Dictionary<string, Controller>();
            Components = new Dictionary<string, Component>();
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
