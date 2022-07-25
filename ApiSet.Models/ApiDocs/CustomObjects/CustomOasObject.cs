using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ApiSet.Models.ApiDocs
{
    /// <summary>
    /// This is the base class for creating custom objects.
    /// </summary>
    public class CustomOasObject
    {
        /// <summary>
        /// The name of the custom object.
        /// </summary>
        /// <remarks>
        /// The preferred convention (per the OAS standards) is to make the name of any custom entry 
        /// use "x-" at the beginning of the custom entry. The two samples included with the ApiDoc
        /// code have names of:
        /// <list type="bullet">
        /// <item>x-provides-values-for</item>
        /// <item>x-method-name</item>
        /// </list>
        /// </remarks>
        public string CustomObjectName { get; set; }
        
        /// <summary>
        /// The value of the custom item.
        /// </summary>
        /// <remarks>
        /// The ApiDoc parsing engine assumes that the value is stored in the OAS as a string.
        /// The custom methods you can provide may convert the string into a standard object,
        /// such as a List or Dictionary, but you will have to provide the parser to convert 
        /// the string into that object.
        /// </remarks>
        public object CustomObjectValue { get; set; }
    }
}
