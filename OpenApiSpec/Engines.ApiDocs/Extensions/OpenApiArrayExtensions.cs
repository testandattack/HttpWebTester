using Microsoft.OpenApi.Any;
using System.Text;

namespace OpenApiUtilities
{
    /// <summary>
    /// A set of extension methods to work on the Microsoft.OpenApi.Models.OpenApiArray class
    /// </summary>
    public static class OpenApiArrayExtensions
    {
        /// <summary>
        /// walks an array of items, retrieving the value from the <see cref="OpenApiAnyExtensions.GetPrimitiveValue(IOpenApiAny)"/> method
        /// </summary>
        /// <param name="source">The <c>IOpenApiArray</c> to which this method is exposed.</param>
        public static string ToString(this OpenApiArray source)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in source)
            {
                sb.Append(item.GetPrimitiveValue() + ",");
            }
            return sb.Remove(sb.Length - 1, 1).ToString();
        }
    }
}
