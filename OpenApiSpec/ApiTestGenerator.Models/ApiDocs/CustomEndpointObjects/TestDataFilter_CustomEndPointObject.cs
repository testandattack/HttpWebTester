using ApiTestGenerator.Models.Consts;
using ApiTestGenerator.Models.Enums;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// A <see cref="CustomEndPointObject"/> class designed to hold 
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
    public class TestDataFilter : CustomEndPointObject
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
            customEndPointObjectType = CustomEndPointObjectTypeEnum.TestDataFilter;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TestDataFilter"/> object
        /// and populates the values from the provided input string
        /// </summary>
        /// <param name="description">A string that contains a <see cref="ParseTokens.TKN_TestDataFilter"/> token
        /// and a set of values in the form of <see cref="ParseTokens.TKN_TestDataFilterStringFormat"/>.</param>
        public TestDataFilter(string description)
        {
            customEndPointObjectType = CustomEndPointObjectTypeEnum.TestDataFilter;
            ParseDescription(description);
        }

        private void ParseDescription(string description)
        {
            /*
             * This is the full entry as added to the API Code
            {{TestDataFilter}}("PRIMARY","App.Models.Model.NameOfDto1.propertyName","DEPENDENT","App.Models.Model.NameOfDto2.propertyName")

            This is the string that get's passed in to this method:
            "PRIMARY","App.Models.Model.NameOfDto1.propertyName","DEPENDENT","App.Models.Model.NameOfDto2.propertyName"

            This is the array of strings after massaging it.

            [0] PRIMARY
            [1] App.Models.Model.NameOfDto1.propertyName
            [2] DEPENDENT
            [3] App.Models.Model.NameOfDto2.propertyName
            */

            PrimaryDto = string.Empty;
            DependentDto = string.Empty;

            string[] items = description
                .Replace("\"", "")
                .Split(',');

            if (items != null && items.Length == 4)
            {
                if (items[0].ToUpper() == "PRIMARY")
                {
                    PrimaryDto = items[1].Substring(0, items[1].LastIndexOf("."));
                }
                if (items[2].ToUpper() == "DEPENDENT")
                {
                    DependentDto = items[3].Substring(0, items[3].LastIndexOf("."));
                }
                SharedPropertyName = items[1].Substring(items[1].LastIndexOf(".") + 1);
            }
        }
    }
}
