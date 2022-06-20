using ApiTestGenerator.Models.Consts;
using ApiTestGenerator.Models.Enums;
using System.Collections.Generic;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// A <see cref="CustomOasObjectEngine"/> class designed to hold a
    /// list of class names that this method's response object can
    /// provide values to.
    /// </summary>
    /// <remarks>
    /// This allows the test generator to line up the endpoints that
    /// will get input from this endpoint's response object
    /// using the <see cref="MethodName"/> entries in
    /// other endpoints. 
    /// </remarks>
    public class ProvidesValuesFor : CustomOasObjectEngine
    {
        /// <summary>
        /// A list of class names that can get input values from this endpoint's 
        /// response object.
        /// </summary>
        public List<string> ProvidesValuesForTheseMethods { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="ProvidesValuesFor"/> object.
        /// </summary>
        public ProvidesValuesFor()
        {
            ProvidesValuesForTheseMethods = new List<string>();
            customEndPointObjectType = CustomEndPointObjectTypeEnum.ProvidesValuesFor;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="MethodName"/> object
        /// and adds the <see cref="ProvidesValuesForTheseMethods"/> values to the object.
        /// </summary>
        /// <param name="endPoints">the name of the source code method as described in the 
        /// <see cref="ParserTokens.TKN_ProvidesValuesFor"/> property of the Swagger Documentation.</param>
        public ProvidesValuesFor(List<string> endPoints)
        {
            ProvidesValuesForTheseMethods = endPoints;
            customEndPointObjectType = CustomEndPointObjectTypeEnum.ProvidesValuesFor;
        }
    }
}
