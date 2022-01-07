using System.Collections.Generic;

namespace ApiTestGenerator.Models.ApiAnalyzer
{
    public class RequestBodySummary
    {
        #region -- Properties -----
        public int numPostRequests { get; set; }
        public int numPutRequests { get; set; }
        public int numPatchRequests { get; set; }
        public int numOtherRequestTypesWithBody { get; set; }

        public int numOAS_JsonContentType { get; set; }
        public int numOAS_FormDataContentType { get; set; }
        public int numOAS_NoContentFound { get; set; }
        public int numOAS_Other { get; set; }

        public List<string> endPointsWithInvalidRequestBody { get; set; }
        #endregion

        #region -- Constructors -----
        public RequestBodySummary()
        {
            numPostRequests = 0;
            numPutRequests = 0;
            numPatchRequests = 0;
            numOtherRequestTypesWithBody = 0;
            numOAS_JsonContentType = 0;
            numOAS_FormDataContentType = 0;
            numOAS_NoContentFound = 0;
            numOAS_Other = 0;
            endPointsWithInvalidRequestBody = new List<string>();
        }
        #endregion
    }
}
