using ApiTestGenerator.Models.Enums;
using System.Collections.Generic;

namespace ApiTestGenerator.Models.ApiDocs
{
    public static class CustomEndpointObjectExtensions
    {
        public static bool Contains(this IEnumerable<CustomEndPointObject> source, CustomEndPointObjectTypeEnum type)
        {
            foreach(var endpointObject in source)
            {
                if (endpointObject.customEndPointObjectType == type)
                    return true;
            }
            return false;
        }

        public static CustomEndPointObject GetSpecificObject(this IEnumerable<CustomEndPointObject> source, CustomEndPointObjectTypeEnum type)
        {
            foreach (var endpointObject in source)
            {
                if (endpointObject.customEndPointObjectType == type)
                    return endpointObject;
            }
            return null;
        }

        public static List<string> GetRestrictsToList(this IEnumerable<CustomEndPointObject> source)
        {
            foreach (var endpointObject in source)
            {
                if (endpointObject.customEndPointObjectType == CustomEndPointObjectTypeEnum.RestrictTo)
                    return ((RestrictTo)endpointObject).RestrictToRoles;
            }
            return null;
        }
    }
}
