﻿using ApiTestGenerator.Models;
using ApiTestGenerator.Models.ApiDocs;
using GTC.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Microsoft.OpenApi.Writers;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using GTC.HttpWebTester.Settings;

/// <summary>
/// A simple utility to read/write Swagger Documentation from/to a URL or a static file and 
/// convert it into a Microsoft OpenApiDocument object.
/// </summary>
namespace GTC.SwaggerParsing
{
    /// <summary>
    /// This class contains all of the code to read from a serialized copy of an
    /// Open API Specification document (from a json file or from the OAS definition URL on an API website)
    /// and convert it into a <see href="https://github.com/Microsoft/OpenAPI.NET">
    /// Microsoft OpenApiDocument</see>. It can also serialize and save the document to a local file system.
    /// </summary>
    public class SwaggerParser
    {
        /// <summary>
        /// the local instance of the <see cref="Settings"/> class containing 
        /// </summary>
        public Settings settings { get; private set; }
        private string _sourceLocation = "";

        /// <summary>
        /// The object that holds the parsed OAS document
        /// </summary>
        public OpenApiDocument apiDocument { get; private set; }

        /// <summary>
        /// Creates a new instance of the parser using the <c>settings.json</c> file in the
        /// root directory of the application.
        /// </summary>
        public SwaggerParser()
        {
            settings = Settings.LoadSettings("settings.json");
            InitializeLogging();
        }

        /// <summary>
        /// Creates a new instance of the parser using the <see cref="Settings"/> object 
        /// that is passed in.
        /// </summary>
        /// <param name="Settings">the pre-loaded settings object to use with this instance.</param>
        public SwaggerParser(Settings Settings)
        {
            settings = Settings;
            InitializeLogging();
        }

        private void InitializeLogging()
        {
            // SERILOG Config: https://github.com/serilog/serilog/wiki/Configuration-Basics

            if (settings.logSettings.ClearLogFileOnStartup)
            {
                if (File.Exists(settings.logSettings.DefaultLogFileName))
                    File.Delete(settings.logSettings.DefaultLogFileName);
            }
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.File(
                    path: settings.logSettings.DefaultLogFileName,
                    restrictedToMinimumLevel: settings.logSettings.MinLogEventLevel,
                    formatter: new CompactJsonFormatter(),
                    rollingInterval: RollingInterval.Infinite)
                .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
                .CreateLogger();
        }

        #region -- Creation methods -----
        /// <summary>
        /// call this to load the Swagger Document into memory
        /// </summary>
        public void PopulateApiDocument()
        {
            PopulateApiDocument(settings.swaggerSettings.ReadSwaggerFromFile);
        }

        /// <summary>
        /// call this to load the Swagger Document into memory
        /// </summary>
        /// <param name="readFromFile">If true, the OAS is read from a file</param>
        public void PopulateApiDocument(bool readFromFile)
        {
            if (readFromFile == true)
                PopulateApiDocumentFromFile();
            else
                PopulateApiDocumentFromStream();
        }

        /// <summary>
        /// call this to load the Swagger Document into memory
        /// </summary>
        /// <param name="fileName">The name of the json file to read.</param>
        public void PopulateApiDocument(string fileName)
        {
            PopulateApiDocumentFromFile(fileName);
        }

        /// <summary>
        /// call this to load the Swagger Document into memory
        /// </summary>
        /// <param name="baseUriAddress">the base URI for the connection to the server hosting the OAS Document</param>
        /// <param name="swaggerStreamLocation">the URI-Stem for the OAS document.</param>
        public void PopulateApiDocument(string baseUriAddress, string swaggerStreamLocation)
        {
            PopulateApiDocumentFromStream(baseUriAddress, swaggerStreamLocation);
        }

        ///// <summary>
        ///// call this to convert the doc into an ApiSet object
        ///// </summary>
        ///// <returns></returns>
        //public ApiSet BuildApiSetFromOpenApiDocument()
        //{
        //    Log.ForContext<SwaggerParser>().Information("Building ApiSet");
        //    ApiSetEngine apiSetEngine = new ApiSetEngine(apiDocument, _sourceLocation, settings.swaggerSettings.apiRoot);
        //    //apiSet = apiSetengine.apiSet;
        //    //apiSet.settings = settings;

        //    apiSetEngine.apiSet.settings = settings;
        //    return apiSetEngine.apiSet;
        //}
        #endregion

        #region -- Write Results Methods -----
        /// <summary>
        /// call this to save a base list of all operations
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="apiSet"></param>
        public void SaveListOfURLs(string fileName, ApiSet apiSet)
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

            using (StreamWriter sw = new StreamWriter($"{settings.DefaultOutputLocation}\\{fileName}", false))
            {
                sw.Write(sb.ToString());
            }
        }

        /// <summary>
        /// call this to save the original swagger file (if read from a stream)
        /// </summary>
        public void SaveOriginalSwaggerDocument()
        {
            if (apiDocument != null)
            {
                DateTime dt = DateTime.UtcNow;
                var stringWriter = new StringWriter();
                OpenApiJsonWriter openApiJsonWriter = new OpenApiJsonWriter(stringWriter);
                Log.ForContext<SwaggerParser>().Information("Serializing OpenApiDoc {docName}", apiDocument.Info.Title);
                apiDocument.SerializeAsV3(openApiJsonWriter);

                string fileName = $"{settings.DefaultOutputLocation}\\{apiDocument.Info.Title}.json";
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    Log.ForContext<SwaggerParser>().Information("Writing OpenApiDoc to {fileName}", fileName);
                    sw.Write(stringWriter.ToString());
                }
                Log.ForContext<SwaggerParser>().Information("Writing OpenApiDoc completed in {elapsed} seconds", dt.GetElapsedSeconds());
            }
        }

        /// <summary>
        /// This method uses the <see href="https://github.com/RicoSuter/NSwag">NSwag</see> Nuget package to generate
        /// C# source code for the OAS documented items. If no fileName is provided, the file is saved to the location
        /// specified in the settings file.
        /// </summary>
        public void CreateAndSaveDtoCode()
        {
            CreateAndSaveDtoCode(settings.codeGenerationSettings.DtoCodeFileName);
        }

        /// <summary>
        /// This method uses the <see href="https://github.com/RicoSuter/NSwag">NSwag</see> Nuget package to generate
        /// C# source code for the OAS documented items. If no fileName is provided, the file is saved to the location
        /// specified in the settings file.
        /// </summary>
        /// <param name="fileName">the fully qualified name of the code file to save.</param>
        public void CreateAndSaveDtoCode(string fileName)
        {
            string sCode;
            if (settings.swaggerSettings.ReadSwaggerFromFile == true)
            {
                sCode = NSwagDto.GetDtoCodeFromFile(_sourceLocation, settings);
            }
            else
            {
                sCode = NSwagDto.GetDtoCodeFromStream(_sourceLocation, settings);
            }

            string codeFileName = $"{settings.DefaultOutputLocation}\\{fileName}";
            Log.ForContext<SwaggerParser>().Information("[{method}]: Saving generated DTO code to file {fileName}", "CreateAndSaveDtoCode", codeFileName);
            using (StreamWriter sw = new StreamWriter(codeFileName, false))
            {
                sw.Write(sCode);
            }
        }
        #endregion

        #region -- private methods -----
        private void PopulateApiDocumentFromStream()
        {
            PopulateApiDocumentFromStream(settings.swaggerSettings.BaseUriAddress, settings.swaggerSettings.SwaggerStreamLocation);
        }

        private void PopulateApiDocumentFromStream(string baseUriAddress, string swaggerStreamLocation)
        {
            _sourceLocation = $"{baseUriAddress} + {swaggerStreamLocation}";
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUriAddress)
            };

            Log.ForContext<SwaggerParser>().Information("Parsing doc at {endpoint}", _sourceLocation);
            var stream = httpClient.GetStreamAsync(swaggerStreamLocation).GetAwaiter().GetResult();
            OpenApiDiagnostic openApiDiagnostic;
            apiDocument = new OpenApiStreamReader().Read(stream, out openApiDiagnostic);
            Log.ForContext<SwaggerParser>().Debug("ApiDocument read. {@output}", openApiDiagnostic);
        }

        private void PopulateApiDocumentFromFile()
        {
            PopulateApiDocumentFromFile(settings.swaggerSettings.SwaggerFileLocation);
        }

        private void PopulateApiDocumentFromFile(string fileName)
        {
            _sourceLocation = fileName;
            string serializedDocument;

            Log.ForContext<SwaggerParser>().Information("Reading input file from {endpoint}", _sourceLocation);
            using (StreamReader sr = new StreamReader(_sourceLocation))
            {
                serializedDocument = sr.ReadToEnd();
            }

            Log.ForContext<SwaggerParser>().Information("Parsing file from {endpoint}", _sourceLocation);
            var openApiStringReader = new OpenApiStringReader();
            apiDocument = openApiStringReader.Read(serializedDocument, out OpenApiDiagnostic openApiDiagnostic);

        }
        #endregion
    }
}
