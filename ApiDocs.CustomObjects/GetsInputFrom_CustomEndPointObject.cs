using ApiTestGenerator.Models.Enums;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// A <see cref="CustomOasObjectEngine"/> class designed to hold the
    /// class name of the API method in the Endpoint. 
    /// </summary>
    /// <remarks>
    /// This allows the test generator to line up the endpoints with the 
    /// <see cref="ProvidesValuesFor"/> entries in
    /// other endpoints. 
    /// </remarks>
    public class GetsInputFrom : CustomOasObjectEngine
    {
        /// <summary>
        /// The class name of the method housing this endpoint.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="GetsInputFrom"/> object.
        /// </summary>
        public GetsInputFrom() { }

        /// <summary>
        /// Creates a new instance of the <see cref="GetsInputFrom"/> object
        /// and adds the <see cref="PropertyName"/> value to the object.
        /// </summary>
        /// <param name="name">the name of the object that contains the input values</param>
        public GetsInputFrom(string name)
        {
            PropertyName = name;
            customEndPointObjectType = CustomEndPointObjectTypeEnum.GetsInputFrom;
        }
    }
}
