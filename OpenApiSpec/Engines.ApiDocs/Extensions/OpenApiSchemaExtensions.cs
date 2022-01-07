using ApiTestGenerator.Models.Consts;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Engines.ApiDocs.Extensions
{
    public static class OpenApiSchemaExtensions
    {
        public static string GetSchemaItemType(this OpenApiSchema value, string depthPrecursor = "", int currentDepth = 0)
        {
            if (currentDepth > 2)
            {
                return "parsed too depp";
            }

            if (value.Type != null)
            {
                string itemType = value.Type;

                if (itemType == "array")
                {
                    // Recursive call
                    string newDepthPrecursor = $"List_{depthPrecursor}";
                    if (value.Items != null)
                    {
                        return $"{GetSchemaItemType(value.Items, newDepthPrecursor, currentDepth + 1)}";
                    }
                    else
                    {
                        Log.ForContext("SourceContext", "SchemaExtensions").Error("[{method}]: Failed to find items in an array. {@value}", "GetSchemaItemType", value);
                        return $"{newDepthPrecursor}{ParseTokens.PARAM_MissingInfo}";
                    }
                }
                else
                {
                    return $"{depthPrecursor}{itemType}";
                }
            }
            else
            {
                Log.ForContext("SourceContext", "SchemaExtensions").Error("[{method}]: Failed to find Item Type. {@value}", "GetSchemaItemType", value);
                return $"{depthPrecursor}{ParseTokens.PARAM_MissingInfo}";
            }
        }
    }
}
