using Engines.ApiDocs;
using ApiTestGenerator.Models;
using ApiTestGenerator.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using GTC.Extensions;

namespace SwaggerParsing
{
    public partial class SwaggerParser
    {
        public Settings settings { get; private set; }
        private string _sourceLocation = "";

        public OpenApiDocument apiDocument { get; private set; }
        
        //public ApiSet apiSet { get; private set; }

        public SwaggerParser()
        {
            settings = Settings.LoadSettings("settings.json");
            InitializeLogging();
        }

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
            if (settings.swaggerSettings.ReadSwaggerFromFile == true)
                PopulateApiDocumentFromFile();
            else
                PopulateApiDocumentFromStream();
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
        /// call this to convert the doc into an ApiSet object
        /// </summary>
        /// <returns></returns>
        public ApiSet BuildApiSetFromOpenApiDocument()
        {
            Log.ForContext<SwaggerParser>().Information("Building ApiSet");
            ApiSetEngine apiSetEngine = new ApiSetEngine(apiDocument, _sourceLocation, settings.swaggerSettings.apiRoot);
            //apiSet = apiSetengine.apiSet;
            //apiSet.settings = settings;

            apiSetEngine.apiSet.settings = settings;
            return apiSetEngine.apiSet;
        }
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
        #endregion

        public void CreateAndSaveDtoCode()
        {
            CreateAndSaveDtoCode(settings.codeGenerationSettings.DtoCodeFileName);
        }

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

        private void PopulateApiDocumentFromStream()
        {
            _sourceLocation = $"{settings.swaggerSettings.BaseUriAddress} + {settings.swaggerSettings.SwaggerStreamLocation}";
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(settings.swaggerSettings.BaseUriAddress)
            };

            Log.ForContext<SwaggerParser>().Information("Parsing doc at {endpoint}", _sourceLocation);
            var stream = httpClient.GetStreamAsync(settings.swaggerSettings.SwaggerStreamLocation).GetAwaiter().GetResult();
            OpenApiDiagnostic openApiDiagnostic;
            apiDocument = new OpenApiStreamReader().Read(stream, out openApiDiagnostic);
            Log.ForContext<SwaggerParser>().Debug("ApiDocument read. {@output}", openApiDiagnostic);
        }

        private void PopulateApiDocumentFromFile()
        {
            _sourceLocation = settings.swaggerSettings.SwaggerFileLocation;
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

    }
}
