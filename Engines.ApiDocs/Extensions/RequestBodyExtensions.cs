using ApiSet.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Collections.Generic;

namespace Engines.ApiDocs.Extensions
{
    public static class RequestBodyExtensions
    {
        public static void AddProperties(this RequestBody source, OpenApiSchema openApiSchema, string endpointName)
        {
            source.properties = new Dictionary<string, Property>();
            foreach (var property in openApiSchema.Properties)
            {
                source.properties.Add(property.Key, property.Value.GetPropertyItem(property.Key, endpointName));
                if (property.Value.Type.ToLower() == "string" 
                        && (property.Value.Format == null || property.Value.Format.ToLower() == "binary"))
                {
                    source.FormPostFileUploadPropertyName = property.Key;
                }
            }
        }

    }
}
