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
    /// This class defines a Model used for translating various different web based API 
    /// calls between the different formats. It is based on the Open API Specification.
    /// The idea is to allow an engine to populate this model with information from
    /// sources like:
    /// <list type="bullet">
    /// <item>An OAS document</item>
    /// <item>An Http Archive (HAR) file.</item>
    /// <item>A Postman request collection.</item>
    /// </list>
    /// and turn the results into a test harness that can be executed.
    /// </summary>
    public class ApiSet
    {
        #region -- Properties -----
        /// <summary>
        /// The <see cref="Settings"/> to use with this ApiSet.
        /// </summary>
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

        ///// <summary>
        ///// A list containing any custom endpoint objects and their handlers
        ///// </summary>
        //[JsonIgnore]
        //public CustomOasObjectCollection CustomObjects { get; set; }
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
            //CustomObjects = new CustomOasObjectCollection();
        }
        #endregion

    }
}
