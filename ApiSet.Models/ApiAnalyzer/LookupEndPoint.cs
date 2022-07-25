using ApiSet.Models.ApiDocs;
using System.Collections.Generic;

namespace ApiSet.Models.ApiAnalyzer
{
    public class LookupEndPoint
    {
        #region -- Properties -----
        /// <summary>
        /// The name of the controller housing this endpoint.
        /// </summary>
        /// <remarks>
        /// For controllers that have lookup calls which share
        /// the same output DTO as a call in the "Lookups" controller,
        /// This field will track that and will be used to provide
        /// input to the other endpoints in the same controller.
        /// </remarks>
        public string ControllerName { get; set; }


        public Dictionary<string, ResponseObject> ResponseItems { get; set; }
        #endregion

        #region -- Constructors -----
        public LookupEndPoint() 
        {
            ResponseItems = new Dictionary<string, ResponseObject>();
        }

        public LookupEndPoint(string name, Dictionary<string, ResponseObject> responseItems)
        {
            ControllerName = name;
            ResponseItems = responseItems;
        }
        #endregion
    }
}
