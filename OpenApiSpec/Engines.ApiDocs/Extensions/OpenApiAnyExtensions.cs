using Microsoft.OpenApi.Any;
using Serilog;
using System;

namespace Engines.ApiDocs.Extensions
{
    public static class OpenApiAnyExtensions
    {

        /// <summary>
        /// Reads the passed in <see cref="IOpenApiAny"/> object and returns the value
        /// it contains in a predefined format
        /// </summary>
        /// <param name="value"></param>
        /// <returns>a string representation of the contained primitive value.</returns>
        public static string GetPrimitiveValue(this IOpenApiAny value)
        {
            Type exampleType = value.GetType();
            try
            {
                if (exampleType == typeof(OpenApiDateTime))
                {
                    return ((OpenApiDateTime)(value)).Value.ToString("yyyy-MM-dd hh:mm:ss");
                }
                else if (exampleType == typeof(OpenApiDate))
                {
                    return ((OpenApiDate)(value)).Value.ToString("yyyy-MM-dd");
                }
                else if (exampleType == typeof(OpenApiInteger))
                {
                    return ((OpenApiInteger)(value)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiString))
                {
                    return ((OpenApiString)(value)).Value;
                }
                else if (exampleType == typeof(OpenApiBoolean))
                {
                    return ((OpenApiBoolean)(value)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiDouble))
                {
                    return ((OpenApiDouble)(value)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiFloat))
                {
                    return ((OpenApiFloat)(value)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiLong))
                {
                    return ((OpenApiLong)(value)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiByte))
                {
                    return ((OpenApiByte)(value)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiBinary))
                {
                    return ((OpenApiBinary)(value)).Value.ToString();
                }
                Log.ForContext("SourceContext", "ParameterExtensions").Error("[{method}]: Failed to find a recognized type. {@value}", "GetPrimitiveValue", value);
            }
            catch (Exception ex)
            {
                Log.ForContext("SourceContext", "ParameterExtensions").Error(ex, "[{method}]: Exception parsing {@value}", "GetPrimitiveValue", value);
            }
            return "";
        }
    }
}
