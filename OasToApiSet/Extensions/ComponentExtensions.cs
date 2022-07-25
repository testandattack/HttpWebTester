using ApiSet.Models.ApiDocs;
using ApiSet.Models.Consts;
using GTC.Extensions;
using Microsoft.OpenApi.Models;
using System;

namespace OasToApiSet.Extensions
{
    public static class ComponentExtensions
    {
        public static void AddClassName(this Component component, OpenApiSchema openApiSchema)
        {
            if (openApiSchema.Description != null)
            {
                if (openApiSchema.Description.Contains(ParserTokens.TKN_ClassName))
                {
                    component.ClassName = openApiSchema.Description.FindSubString(ParserTokens.TKN_ClassName, ")");
                }
                else
                {
                    component.ClassName = "Description didn't contain name";
                }
            }
            else if (openApiSchema.Type != null && openApiSchema.Type.ToLower() != "object" && openApiSchema.Enum != null)
            {
                component.ClassName = typeof(Enum).ToString();
            }
            else
            {
                component.ClassName = "Description Not Found";
            }
        }

        public static void AddProperties(this Component component, OpenApiSchema openApiSchema, string componentName)
        {
            foreach (var property in openApiSchema.Properties)
            {
                component.properties.Add(property.Key, property.Value.GetPropertyItem(property.Key, componentName));
            }
        }
    }
}
