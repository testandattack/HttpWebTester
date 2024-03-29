﻿using NSwag.CodeGeneration.CSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NSwag;
using Serilog;
using ApiTestGenerator.Models;
using GTC.HttpWebTester.Settings;

namespace GTC.SwaggerParsing
{
    public static class NSwagDto
    {
        public static string GetDtoCodeFromFile(string FileLocation, Settings settings)
        {
            var document = NSwag.OpenApiDocument.FromFileAsync(FileLocation).GetAwaiter().GetResult();
            Log.ForContext("SourceContext", "NSwagDto").Information("[{method}]: Reading OpenApiDoc with NSwag - {Settings}", "GetDtoCodeFromFile", settings);
            return ProcessNSwagDoc(document, settings);
        }

        public static string GetDtoCodeFromStream(string SwaggerUri, Settings settings)
        {
            // -- From https://github.com/RicoSuter/NSwag/wiki/CSharpClientGenerator
            System.Net.WebClient wclient = new System.Net.WebClient();
            var document = NSwag.OpenApiDocument.FromJsonAsync(wclient.DownloadString(SwaggerUri)).GetAwaiter().GetResult();
            Log.ForContext("SourceContext", "NSwagDto").Information("[{method}]: Reading OpenApiDoc with NSwag - {Settings}", "GetDtoCodeFromStream", settings);
            wclient.Dispose();

            return ProcessNSwagDoc(document, settings);
        }

        public static string ProcessNSwagDoc(OpenApiDocument document, Settings localSettings)
        {
            var settings = new CSharpClientGeneratorSettings
            {
                // https://github.com/RicoSuter/NSwag/wiki/CSharpClientGeneratorSettings
                ClassName = localSettings.swaggerSettings.CoreClassName,
                CSharpGeneratorSettings =
                    {
                        // https://github.com/RicoSuter/NJsonSchema/wiki/CSharpGeneratorSettings
                        Namespace = localSettings.swaggerSettings.CodeNamespace,
                        GenerateDataAnnotations = true
                    },
                GenerateExceptionClasses = localSettings.swaggerSettings.GenerateExceptionClasses,
                GenerateClientClasses = localSettings.swaggerSettings.GenerateClientClasses
            };
            Log.ForContext("SourceContext","NSwagDto").Information("[{method}]: Generating DTO Code with NSwag - {CSharpClientGeneratorSettings}", "", settings.CodeGeneratorSettings);
            var generator = new CSharpClientGenerator(document, settings);
            return generator.GenerateFile();
        }
    }
}
