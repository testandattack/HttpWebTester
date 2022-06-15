using ApiTestGenerator.Models.ApiDocs;
using Engines.ApiDocs;
using GTC.SwaggerParsing;
using Serilog;
using Serilog.Formatting.Compact;

namespace HttpWebTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(
                    outputTemplate: "[{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(
                    formatter: new CompactJsonFormatter(),
                    path: @"c:\Temp\WorkflowPageTester_log.json")
                .Enrich.FromLogContext()
                .CreateLogger();


            // Step 1 - Read the OAS and create an ApiSet from the data
            ApiSet apiSet = GetApiSet();

        }

        //
        static ApiSet GetApiSet()
        {
            var parser = new SwaggerFileParser();
            parser.PopulateApiDocument();
            parser.CreateAndSaveDtoCode(@"c:\Temp\DtoCode.cs");

            ApiSetEngine apiSetEngine = new ApiSetEngine();
            ApiSet apiSet = apiSetEngine.BuildApiSet(parser.apiDocument, parser.settings.swaggerSettings.apiRoot);
            apiSet.SerializeAndSaveApiSet(@"c:\temp");

            return apiSet;
        }
    }
}
