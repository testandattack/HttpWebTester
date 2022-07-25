using ApiSet.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSet.Engines.Interfaces
{
    public interface IApiSet
    {
        void BuildApiSet(OpenApiDocument openApiDocument, string ApiRoot, Dictionary<string, string> extraInfo);

        void LoadApiDocFromFile(string fileName);

        void SerializeAndSaveApiDoc();
        
        void SerializeAndSaveApiDoc(string fileName);

        void SaveListOfURLs(string fileName);
    }
}
