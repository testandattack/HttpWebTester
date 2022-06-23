using ApiTestGenerator.Models;
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
using SharedResources;

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
    public class SwaggerUrlParser : ISwaggerParser
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
        public SwaggerUrlParser()
        {
            settings = new Settings("settings.json");
        }

        /// <summary>
        /// Creates a new instance of the parser using the <see cref="Settings"/> object 
        /// that is passed in.
        /// </summary>
        /// <param name="Settings">the pre-loaded settings object to use with this instance.</param>
        public SwaggerUrlParser(Settings Settings)
        {
            settings = Settings;
        }

        #region -- Creation methods -----
        /// <summary>
        /// 
        /// </summary>
        public void PopulateApiDocument()
        {
            PopulateApiDocument($"{settings.swaggerSettings.BaseUriAddress}{settings.swaggerSettings.SwaggerStreamLocation}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uriAddress"></param>
        public void PopulateApiDocument(string uriAddress)
        {
            _sourceLocation = uriAddress;
            var httpClient = new HttpClient();

            Log.ForContext<SwaggerUrlParser>().Information("Parsing doc at {endpoint}", _sourceLocation);
            var stream = httpClient.GetStreamAsync(uriAddress).GetAwaiter().GetResult();
            OpenApiDiagnostic openApiDiagnostic;
            apiDocument = new OpenApiStreamReader().Read(stream, out openApiDiagnostic);
            Log.ForContext<SwaggerUrlParser>().Debug("ApiDocument read. {@output}", openApiDiagnostic);
        }
        #endregion

        #region -- Write Results Methods -----
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
                Log.ForContext<SwaggerUrlParser>().Information("Serializing OpenApiDoc {docName}", apiDocument.Info.Title);
                apiDocument.SerializeAsV3(openApiJsonWriter);

                string fileName = $"{settings.DefaultOutputLocation}\\{apiDocument.Info.Title}.json";
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    Log.ForContext<SwaggerUrlParser>().Information("Writing OpenApiDoc to {fileName}", fileName);
                    sw.Write(stringWriter.ToString());
                }
                Log.ForContext<SwaggerUrlParser>().Information("Writing OpenApiDoc completed in {elapsed} seconds", dt.GetElapsedSeconds());
            }
        }

        /// <summary>
        /// This method uses the <see href="https://github.com/RicoSuter/NSwag">NSwag</see> Nuget package to generate
        /// C# source code for the OAS documented items. If no fileName is provided, the file is saved to the location
        /// specified in the settings file.
        /// </summary>
        public void CreateAndSaveDtoCode()
        {
            CreateAndSaveDtoCode(settings.swaggerSettings.DtoCodeFileName);
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
            Log.ForContext<SwaggerUrlParser>().Information("[{method}]: Saving generated DTO code to file {fileName}", "CreateAndSaveDtoCode", codeFileName);
            using (StreamWriter sw = new StreamWriter(codeFileName, false))
            {
                sw.Write(sCode);
            }
        }
        #endregion
    }
}
