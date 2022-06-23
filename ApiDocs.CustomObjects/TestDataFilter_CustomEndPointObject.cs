using ApiTestGenerator.Models.Consts;
using ApiTestGenerator.Models.Enums;
using ApiDocs.CustomObjects.Extensions;
using ApiTestGenerator.Models.ApiDocs;

namespace ApiDocs.CustomObjects
{
    /// <summary>
    /// A <see cref="CustomOasObjectEngine"/> class designed to hold 
    /// information about filters that should be applied to result
    /// sets when extracting input data for the method this filter
    /// is associated with.
    /// </summary>
    /// <remarks>
    /// If you are providing data that needs to properly align, but 
    /// the constraint is provided by the front end (meaning that the 
    /// dependency cannot be determined by looking at the DBModel code in the API),
    /// this filter will describe the constraints. All values from the 
    /// DEPENDENT DTO must contain the same shared property as the values chosen 
    /// from the PRIMARY DTO.
    /// <br/>Sample
    /// <code>
    /// {{TestDataFilter}}("PRIMARY","App.Models.Model.NameOfDto1.propertyName","DEPENDENT","App.Models.Model.NameOfDto2.propertyName")
    /// </code>
    /// 
    /// </remarks>
    public class TestDataFilter : CustomOasObject
    {
        /// <summary>
        /// The name of the property that will be in both of the objects
        /// used to get input values. Whatever items you pull from the 
        /// <see cref="PrimaryDto"/>,
        /// use the value of this property in those items to filter the
        /// values you retrieve from the <see cref="DependentDto"/>
        /// </summary>
        public string SharedPropertyName { get; set; }

        /// <summary>
        /// The DTO to use FIRST when retrieving items to feed into 
        /// this endpoint.
        /// </summary>
        public string PrimaryDto { get; set; }

        /// <summary>
        /// The DTO to use SECOND when retrieving items to feed into 
        /// this endpoint.
        /// </summary>
        public string DependentDto { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="TestDataFilter"/> object.
        /// </summary>
        public TestDataFilter()
        {
            base.CustomObjectName = string.Empty;
            base.CustomObjectType = "TestDataFilter";
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TestDataFilter"/> object
        /// and populates the values from the provided input string
        /// </summary>
        /// <param name="description">A string that contains a <see cref="ParserTokens.TKN_TestDataFilter"/> token
        /// and a set of values in the form of <see cref="ParserTokens.TKN_TestDataFilterStringFormat"/>.</param>
        public TestDataFilter(string description)
        {
            base.CustomObjectName = string.Empty;
            base.CustomObjectType = "TestDataFilter";
            this.ParseDescription(description);
        }

        public TestDataFilter(string description, string name)
        {
            base.CustomObjectName = name;
            base.CustomObjectType = "TestDataFilter";
            this.ParseDescription(description);
        }
    }
}
