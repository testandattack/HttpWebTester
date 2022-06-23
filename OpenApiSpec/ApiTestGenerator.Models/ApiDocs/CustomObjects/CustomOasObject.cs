using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// This is the base class for creating custom objects and object parsers.
    /// </summary>
    public abstract class CustomOasObject
    {
        public string CustomObjectName { get; set; }
        
        public string CustomObjectType { get; set; }

        public object CustomObjectValue { get; set; }


    }
}
