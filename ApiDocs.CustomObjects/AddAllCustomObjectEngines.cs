using ApiSet.Models.ApiDocs;
using ApiSet.Models.Consts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDocs.CustomObjects
{
    /// <summary>
    /// This class houses the method to add all custom objects to the parser
    /// </summary>
    public static class AddAllCustomObjectEngines
    {
        /// <summary>
        /// As you create custom objects, Add them to the engine by updating this method's code.
        /// </summary>
        /// <returns></returns>
        public static List<CustomOasObjectEngine> BuildCustomObjects()
        {
            List<CustomOasObjectEngine> collection = new List<CustomOasObjectEngine>();
            collection.Add(new ProvidesValuesFor_CustomOasObjectEngine());
            collection.Add(new MethodName_CustomOasObjectEngine());
            return collection;
        }
    }
}
