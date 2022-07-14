using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace GTC.HttpWebTester.Settings
{
    /// <summary>
    /// This class encapsulates the settings that define where and how to read 
    /// Open API Spec documentation (swagger) files.
    /// </summary>
    public class SwaggerSettings
    {
        /// <summary>
        /// The root portion of the API's UriStem.
        /// </summary>
        [DefaultValue("")]
        [JsonProperty("apiRoot", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string apiRoot { get; set; }

        /// <summary>
        /// The "server" portion of the URL that holds the Swagger generated
        /// document for the API. This is combined with the 
        /// <see cref="SwaggerStreamLocation"/> to read the document to parse.
        /// <strong>NOTE:</strong> This is only used if
        /// <see cref="ReadSwaggerFromFile"/> is set to "false"
        /// </summary>
        public string BaseUriAddress { get; set; }

        /// <summary>
        /// The UriStem portion of the URL that holds the Swagger generated
        /// document for the API. This is combined with the 
        /// <see cref="BaseUriAddress"/> to read the document to parse.
        /// <strong>NOTE:</strong> This is only used if
        /// <see cref="ReadSwaggerFromFile"/> is set to "false"
        /// </summary>
        public string SwaggerStreamLocation { get; set; }

        /// <summary>
        /// The file name of a pre-generated Swagger document to read
        /// and parse.
        /// <strong>NOTE:</strong> This is used if
        /// <see cref="ReadSwaggerFromFile"/> is set to "true". It is 
        /// also used as the location to save the Swagger Document if
        /// you are parsing from the swagger stream.
        /// </summary>
        public string SwaggerFileLocation { get; set; }

        /// <summary>
        /// When "true" the parser will get the Swagger Document
        /// from the <see cref="SwaggerFileLocation"/>. If "false"
        /// the parser will get the Swagger Document from the 
        /// <see cref="BaseUriAddress"/> and <see cref="SwaggerStreamLocation"/>
        /// </summary>
        [DefaultValue(true)]
        public bool ReadSwaggerFromFile { get; set; }

        /// <summary>
        /// If true, then the app will attempt to generate C# code from the 
        /// components section of the OAS
        /// </summary>
        [DefaultValue(false)]
        public bool GenerateDtoCode { get; set; }

        /// <summary>
        /// If true, the parser will continue working on the AOS parsing if
        /// the Code generation throws an error.
        /// </summary>
        [DefaultValue(true)]
        public bool IgnoreDtoCodeGenerationErrors { get; set; }
        
        /// <summary>
        /// The name of the file to use when saving the generated DTO code.
        /// </summary>
        public string DtoCodeFileName { get; set; }

        /// <summary>
        /// The namespace to use when generating DTO code.
        /// </summary>
        public string CodeNamespace { get; set; }

        /// <summary>
        /// The core name to use for classes when generating DTO code.
        /// </summary>
        public string CoreClassName { get; set; }

        /// <summary>
        /// Should exception classes be generated?
        /// </summary>
        [DefaultValue(false)]
        public bool GenerateExceptionClasses { get; set; }

        /// <summary>
        /// Should client classes be generated?
        /// </summary>
        [DefaultValue(false)]
        public bool GenerateClientClasses { get; set; }
    }
}
