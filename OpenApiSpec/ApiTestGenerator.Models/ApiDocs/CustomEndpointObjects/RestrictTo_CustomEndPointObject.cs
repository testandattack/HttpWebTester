using ApiTestGenerator.Models.Consts;
using ApiTestGenerator.Models.Enums;
using System.Collections.Generic;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// Looks for [RestrictToRoles] entries in the endppoint and stores a
    /// list of those entries.
    /// </summary>
    /// <remarks>
    /// This allows the test generator to line up the roles with roles
    /// assigned to test users and then formulate whether the user should
    /// be denied access to the endpoint.
    /// </remarks>
    public class RestrictTo : CustomEndPointObject
    {
        /// <summary>
        /// A list of the roles that are ALLOWED to access this endpoint.
        /// </summary>
        public List<string> RestrictToRoles { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="RestrictTo"/> object.
        /// </summary>
        public RestrictTo()
        {
            RestrictToRoles = new List<string>();
            customEndPointObjectType = CustomEndPointObjectTypeEnum.RestrictTo;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RestrictTo"/> object
        /// and adds the <see cref="RestrictToRoles"/> values to the object.
        /// </summary>
        /// <param name="roles">the name of the source code method as described in the 
        /// <see cref="ParserTokens.TKN_RestrictTo"/> property of the Swagger Documentation.</param>
        public RestrictTo(List<string> roles)
        {
            RestrictToRoles = roles;
            customEndPointObjectType = CustomEndPointObjectTypeEnum.RestrictTo;
        }
    }
}
