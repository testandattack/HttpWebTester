using ApiTestGenerator.Models.ApiDocs;
using ApiTestGenerator.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDocs.CustomObjects
{
    /// <summary>
    /// Base Abstract class for describing custom objects that can be added
    /// to Swagger Documentation.
    /// </summary>
    public class CustomOasObjectEngine : ICustomOasObjectEngine<CustomOasObjectEngine>
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomOasObjectCollection customObjects { get; internal set; }

        /// <summary>
        /// A string representing the type of custom object
        /// </summary>
        public Type CustomOasObjectEngineType { get; }

        /// <summary>
        /// Creates a new instance of the engine.
        /// </summary>
        public CustomOasObjectEngine() 
        {
            customObjects = new CustomOasObjectCollection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public string GetCustomEndPointObjectTypesAsString(CustomOasObjectCollection collection)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in collection.collection)
            {
                sb.Append(item.Value.GetType() + ";");
            }

            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }

    }
}
