using ApiTestGenerator.Models.Consts;
using ApiTestGenerator.Models.Enums;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// A <see cref="CustomEndPointObject"/> class designed to hold the
    /// class name of the API method in the Endpoint. 
    /// </summary>
    /// <remarks>
    /// This allows the test generator to line up the endpoints with the 
    /// <see cref="ProvidesValuesFor"/> entries in
    /// other endpoints. 
    /// </remarks>
    public class MethodName : CustomEndPointObject
    {
        /// <summary>
        /// The class name of the method housing this endpoint.
        /// </summary>
        public string methodName { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="MethodName"/> object.
        /// </summary>
        public MethodName() { }

        /// <summary>
        /// Creates a new instance of the <see cref="MethodName"/> object
        /// and adds the <see cref="methodName"/> value to the object.
        /// </summary>
        /// <param name="name">the name of the source code method as described in the 
        /// <see cref="ParserTokens.TKN_MethodName"/> property of the Swagger Documentation.</param>
        public MethodName(string name)
        {
            methodName = name;
            customEndPointObjectType = CustomEndPointObjectTypeEnum.MethodName;
        }
    }
}
