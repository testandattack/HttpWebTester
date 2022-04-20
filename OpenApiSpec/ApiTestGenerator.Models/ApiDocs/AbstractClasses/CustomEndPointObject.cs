using ApiTestGenerator.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// Base Abstract class for describing custom objects that can be added
    /// to Swagger Documentation.
    /// </summary>
    public abstract class CustomEndPointObject
    {
        internal CustomEndPointObject() { }

        /// <summary>
        /// Enum describing the type of custom object 
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomEndPointObjectTypeEnum customEndPointObjectType { get; set; }

        public static string GetCustomEndPointObjectTypesAsString(List<CustomEndPointObject> objects)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in objects)
            {
                sb.Append(item.customEndPointObjectType + ";");
            }

            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
    }
}
