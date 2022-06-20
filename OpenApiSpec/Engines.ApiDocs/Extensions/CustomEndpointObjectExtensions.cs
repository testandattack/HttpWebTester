using ApiTestGenerator.Models.ApiDocs;
using ApiTestGenerator.Models.Enums;
using System;
using System.Collections.Generic;

namespace Engines.ApiDocs.Extensions
{
    public static class CustomEndpointObjectExtensions
    {
        public static bool Contains(this IEnumerable<CustomOasObjectEngine> source, Type type)
        {
            foreach(var endpointObject in source)
            {
                if (endpointObject.CustomOasObjectEngineType == type)
                    return true;
            }
            return false;
        }

        public static CustomOasObjectEngine GetSpecificObject(this IEnumerable<CustomOasObjectEngine> source, Type type)
        {
            foreach (var endpointObject in source)
            {
                if (endpointObject.CustomOasObjectEngineType == type)
                    return endpointObject;
            }
            return null;
        }
    }
}
