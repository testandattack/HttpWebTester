using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PostmanManager
{
    public class JsonToCsharp
    {
        public void CreateClasses(string inputFile, string outputFile)
        {
            string json = File.ReadAllText(inputFile);
            var schemaFromFile = JsonSchema.FromSampleJson(json);
            var classGenerator = new CSharpGenerator(schemaFromFile, new CSharpGeneratorSettings
            {
                ClassStyle = CSharpClassStyle.Poco,
                GenerateDataAnnotations = false,
                HandleReferences = true
            }) ;
            var codeFile = classGenerator.GenerateFile();
            File.WriteAllText(outputFile, codeFile);
        }
    }
}
