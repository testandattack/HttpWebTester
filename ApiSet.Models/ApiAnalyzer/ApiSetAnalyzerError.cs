using ApiSet.Models.Enums;
using ApiSet.Models.ApiDocs;

namespace ApiSet.Models.ApiAnalyzer
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
