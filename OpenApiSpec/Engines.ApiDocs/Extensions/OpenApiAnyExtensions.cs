using Microsoft.OpenApi.Any;
using Serilog;
using System;
using System.Text;

namespace OpenApiUtilities
{
    /// <summary>
    /// A set of extension methods to work on the Microsoft.OpenApi.Models.OpenApiAny class
    /// </summary>
    public static class OpenApiAnyExtensions
    {
        public static string GetValueAsString(this IOpenApiAny source)
        {
            Type exampleType = source.GetType();
            if(exampleType == typeof(OpenApiArray))
            {
                return (source as OpenApiArray).ToString();
            }
            else if (exampleType == typeof(OpenApiNull))
            {
                return "null";
            }
            else if (exampleType == typeof(OpenApiObject))
            {
                return "custom object";
            }
            else
            {
                return source.GetPrimitiveValue();
            }
        }

        /// <summary>
        /// Reads the passed in <see cref="IOpenApiAny"/> object and returns the value
        /// it contains in a predefined format
        /// </summary>
        /// <param name="source">The <c>IOpenApiAny</c> to which this method is exposed.</param>
        /// <returns>a string representation of the contained primitive value.</returns>
        public static string GetPrimitiveValue(this IOpenApiAny source)
        {
            Type exampleType = source.GetType();
            try
            {
                if (exampleType == typeof(OpenApiBinary))
                {
                    return ByteArrayToString(((OpenApiBinary)(source)).Value);
                }
                else if (exampleType == typeof(OpenApiBoolean))
                {
                    return ((OpenApiBoolean)(source)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiByte))
                {
                    return ((OpenApiByte)(source)).Value[0].ToString();
                }
                else if (exampleType == typeof(OpenApiDate))
                {
                    return ((OpenApiDate)(source)).Value.ToString("yyyy-MM-dd");
                }
                else if (exampleType == typeof(OpenApiDateTime))
                {
                    return ((OpenApiDateTime)(source)).Value.ToString("yyyy-MM-dd h:mm:ss tt");
                }
                else if (exampleType == typeof(OpenApiDouble))
                {
                    return ((OpenApiDouble)(source)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiFloat))
                {
                    return ((OpenApiFloat)(source)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiInteger))
                {
                    return ((OpenApiInteger)(source)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiLong))
                {
                    return ((OpenApiLong)(source)).Value.ToString();
                }
                else if (exampleType == typeof(OpenApiPassword))
                {
                    return "*****";
                }
                else if (exampleType == typeof(OpenApiString))
                {
                    return ((OpenApiString)(source)).Value;
                }
                Log.ForContext("SourceContext", "ParameterExtensions").Error("[{method}]: Failed to find a recognized type. {@value}", "GetPrimitiveValue", source);
            }
            catch (Exception ex)
            {
                Log.ForContext("SourceContext", "ParameterExtensions").Error(ex, "[{method}]: Exception parsing {@value}", "GetPrimitiveValue", source);
            }
            return "";
        }

        /// <summary>
        /// Converts an array of bytes (representing characters) into a string.
        /// </summary>
        /// <param name="source">The <c>byte array</c> to which this method is exposed.</param>
        private static string ByteArrayToString(byte[] source)
        {
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < source.Length; x++)
            {
                sb.Append(source[x].ToString());
            }
            return sb.ToString();
        }
    }
}
