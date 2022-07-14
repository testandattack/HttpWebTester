using GTC.HttpWebTester.Settings;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace SharedResources
{
    public interface ISwaggerParser
    {
        Settings settings { get; }
        OpenApiDocument apiDocument { get; }
        Dictionary<string, string> extraInfo { get; set; }


        public void PopulateApiDocument();
        public void PopulateApiDocument(string location);

        public void SaveOriginalSwaggerDocument();
        public void CreateAndSaveDtoCode();
        public void CreateAndSaveDtoCode(string fileName);
    }
}
