using ApiSet.Models.ApiDocs;
using Engines.ApiDocs;
using GTC.HttpWebTester.Settings;
using GTC.SwaggerParsing;
using GTC.Extensions;
using Serilog;
using Serilog.Formatting.Compact;
using System.IO;
using Engines.ApiDocs.Extensions;
using PostmanItemManagement;
using RestSharp;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;
using SharedResources;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Schema;

namespace HttpWebTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings appSettings = CreateLogger();

            ApiDoc apiSet = new ApiDoc(appSettings);
            //CreateSchema(apiSet, "c:\\temp\\ApiSet_Schema.json");

            #region -- ApiSet Stuff -----
            //if (args.Length == 0)
            //    //CreateAndAnalyzeApiSet(appSettings, "SwaggerPetstore_OAS.json", "SwaggerPetstore_OAS.cs");
            //    CreateAndAnalyzeApiSet(appSettings);
            //else if(args.Length == 2)
            //    CreateAndAnalyzeApiSet(appSettings, args[0], args[1]);
            #endregion
        }

        #region -- Utilities -----
        static Settings CreateLogger()
        {
            Settings settings = new Settings("settings.json");

            if (settings.logSettings.ClearLogFileOnStartup)
            {
                if (File.Exists(settings.logSettings.DefaultLogFileName))
                    File.Delete(settings.logSettings.DefaultLogFileName);
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(
                    theme: Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Code
                )
                .WriteTo.File(
                    //formatter: new CompactJsonFormatter(),
                    outputTemplate: "[{Timestamp:mm:ss} {Level:u3}] {Message:j}{NewLine}\t{Exception}",
                    restrictedToMinimumLevel: settings.logSettings.MinLogEventLevel,
                    path: settings.logSettings.DefaultLogFileName,
                    rollingInterval: RollingInterval.Infinite
                )
                .Enrich.FromLogContext()
                .CreateLogger();

            return settings;
        }

        static void CreateSchema(string fileName)
        {
            JSchemaGenerator generator = new JSchemaGenerator();
            generator.SchemaLocationHandling = SchemaLocationHandling.Inline;
            generator.SchemaPropertyOrderHandling = SchemaPropertyOrderHandling.Default;
            generator.SchemaReferenceHandling = SchemaReferenceHandling.All;
            generator.DefaultRequired = Required.Default;
            JSchema schema = generator.Generate(typeof(ApiDoc));

            using( StreamWriter sw = new StreamWriter(fileName, false))
            {
                sw.Write(JsonConvert.SerializeObject(schema, Formatting.Indented));
            }
        }
        #endregion

        #region -- ApiSet Stuff -----
        static void CreateAndAnalyzeApiSet(Settings appSettings)
        {
            if(appSettings.swaggerSettings.SwaggerFileLocation.Contains("\\"))
            {
                CreateApiSet(appSettings, 
                    appSettings.swaggerSettings.SwaggerFileLocation, 
                    appSettings.swaggerSettings.DtoCodeFileName);
            }
            else
            {
                CreateApiSet(appSettings, 
                    $"{appSettings.DefaultInputLocation}\\{appSettings.swaggerSettings.SwaggerFileLocation}", 
                    $"{appSettings.DefaultInputLocation}\\{appSettings.swaggerSettings.DtoCodeFileName}");
            }
        }

        static void CreateAndAnalyzeApiSet(Settings appSettings, string oasName, string dtoName)
        {
            if (oasName.Contains("\\") && dtoName.Contains("\\"))
            {
                CreateApiSet(appSettings,oasName,dtoName);
            }
            else
            {
                CreateApiSet(appSettings,
                    $"{appSettings.DefaultInputLocation}\\{oasName}",
                    $"{appSettings.DefaultInputLocation}\\{dtoName}");
            }
        }

        static void CreateApiSet(Settings appSettings, string oasName, string dtoName)
        {
            ISwaggerParser parser;
            // Step 1 - Read the OAS and create an ApiDoc from the data
            if (appSettings.swaggerSettings.ReadSwaggerFromFile == true)
                parser = new SwaggerFileParser(appSettings);
            else
                parser = new SwaggerUrlParser(appSettings);
            parser.PopulateApiDocument(oasName);

            // Step 2 - Generate DTO Code
            GenerateDtoCode(appSettings, dtoName, parser);

            ApiSetEngine apiSetEngine = new ApiSetEngine(appSettings);
            apiSetEngine.BuildApiSet(parser.apiDocument, parser.settings.swaggerSettings.apiRoot, parser.extraInfo);
            apiSetEngine.AddCoreInfo(parser.extraInfo);
            apiSetEngine.SerializeAndSaveApiSet();

            // Step 2 - Analyze the ApiDoc
            ApiSetAnalysisEngine analyzer = new ApiSetAnalysisEngine(apiSetEngine.apiSet, appSettings);
            analyzer.PerformAnalysis();
            analyzer.SerializeAndSaveApiSetAnalysis();
        }

        private static void GenerateDtoCode(Settings appSettings, string dtoName, ISwaggerParser parser)
        {
            if (appSettings.swaggerSettings.GenerateDtoCode == true)
            {
                try
                {
                    if (dtoName == string.Empty)
                        parser.CreateAndSaveDtoCode();
                    else
                        parser.CreateAndSaveDtoCode(dtoName);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error in code generation");
                    if (appSettings.swaggerSettings.IgnoreDtoCodeGenerationErrors == false)
                        throw (ex);
                }
            }
        }
        #endregion

        #region -- Postman Stuff -----
        static void ReadAndProcessPostmanCollection(Settings appSettings)
        {
            PostmanItemManager manager = new PostmanItemManager("Swagger Petstore.postman_collection.json");
            manager.postmanCollection.Info.Name = "Modified Petstore Collection";
            manager.postmanCollection.Info.PostmanId = Guid.NewGuid().ToString();
            manager.SaveCollection("Swagger Modified Petstore.postman_collection.json");
        }
        #endregion
    }
}
