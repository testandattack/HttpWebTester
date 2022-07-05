using ApiTestGenerator.Models.ApiDocs;
using Engines.ApiDocs;
using GTC.HttpWebTester.Settings;
using GTC.SwaggerParsing;
using Serilog;
using Serilog.Formatting.Compact;
using System.IO;
using Engines.ApiDocs.Extensions;
using PostmanManager;
using RestSharp;
using System;
using Newtonsoft.Json;
using ServiceStack.Api.Postman;
using System.Collections.Generic;

namespace HttpWebTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Settings settings = CreateLogger();

            //// Step 1 - Read the OAS and create an ApiSet from the data
            //ApiSet apiSet = GetApiSet(settings);

            //// Step 2 - Analyze the ApiSet
            //ApiSetAnalysisEngine analyzer = new ApiSetAnalysisEngine(apiSet, settings);
            //analyzer.PerformAnalysis();
            //analyzer.SerializeAndSaveApiSetAnalysis();
            //JsonToCsharp mgr = new JsonToCsharp();
            //mgr.CreateClasses(@"C:\Temp\Postman\PostmanCollectionSchema.json", @"C:\Temp\Postman\PostmanCollectionSchema.cs");
            //Properties postman = new Properties();
            PostmanCollection pc = new PostmanCollection();
            using (StreamReader sr = new StreamReader(@"dataCatalogPostman.json"))
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    Converters = new List<JsonConverter> { new PostmanItem_JsonConverter() }
                };
                pc = JsonConvert.DeserializeObject<PostmanCollection>(sr.ReadToEnd(), settings);
            }
            Console.WriteLine("");
        }

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
                    outputTemplate: "[{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(
                    formatter: new CompactJsonFormatter(),
                    restrictedToMinimumLevel: settings.logSettings.MinLogEventLevel,
                    path: settings.logSettings.DefaultLogFileName,
                    rollingInterval: RollingInterval.Infinite)
                .Enrich.FromLogContext()
                .CreateLogger();

            return settings;
        }

        static ApiSet GetApiSet(Settings settings)
        {
            var parser = new SwaggerFileParser(settings);
            parser.PopulateApiDocument();
            //parser.CreateAndSaveDtoCode(@"c:\Temp\DtoCode.cs");

            ApiSetEngine apiSetEngine = new ApiSetEngine(settings);
            apiSetEngine.BuildApiSet(parser.apiDocument, parser.settings.swaggerSettings.apiRoot);
            apiSetEngine.SetOasVersion(parser.extraInfo);
            apiSetEngine.SetSchemes(parser.extraInfo);
            apiSetEngine.SerializeAndSaveApiSet();

            return apiSetEngine.apiSet;
        }
    }
}
