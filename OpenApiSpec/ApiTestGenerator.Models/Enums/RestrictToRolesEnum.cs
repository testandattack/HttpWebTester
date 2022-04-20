using ApiTestGenerator.Models.Consts;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiTestGenerator.Models.Enums
{
    /// <summary>
    /// Enumerates the types of roles that can be seen in a 
    /// <see cref="RestrictTo"/> object.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RestrictToRolesEnum
    {
        NO_RESTRICTION = 0,
        ADMIN = 1,
        AIRLINE_ADMIN = 2,
        AIRLINE_USER = 3,
        ENGINEER = 4,
        USER_MANAGER = 5,
        TESTER = 6,
        ACMF_USER = 7,
        EXPORTER = 8,
        PWC_USER = 9,
        ACMF_ANALYTICS_AUTHORIZED = 10,
        ANALYTIC_ADMIN = 11,
        ISSUE_INVESTIGATOR = 12,
        DOCUMENT_MANAGER = 13
    }
}
