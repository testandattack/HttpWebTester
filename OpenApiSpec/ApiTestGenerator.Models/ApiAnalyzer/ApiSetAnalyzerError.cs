using ApiTestGenerator.Models.Enums;
using ApiTestGenerator.Models.ApiDocs;

namespace ApiTestGenerator.Models.ApiAnalyzer
{
    public class ApiSetAnalyzerError : Error
    {
        public ApiSetAnalyzerError(string msg, object objectWithError)
        {
            ErrorMessage = msg;
            ObjectWithError = objectWithError;
        }

    }
}
