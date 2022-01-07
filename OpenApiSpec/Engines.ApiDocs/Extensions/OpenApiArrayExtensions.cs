using Microsoft.OpenApi.Any;
using Serilog;
using System;
using System.Text;

namespace Engines.ApiDocs.Extensions
{
    public static class OpenApiArrayExtensions
    {

        public static string ToString(this OpenApiArray array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in array)
            {
                sb.Append(item.GetPrimitiveValue() + ",");
            }
            return sb.Remove(sb.Length - 1, 1).ToString();
        }

    }
}
