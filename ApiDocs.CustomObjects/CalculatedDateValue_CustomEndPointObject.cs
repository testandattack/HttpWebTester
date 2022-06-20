using ApiTestGenerator.Models.Consts;
using ApiTestGenerator.Models.Enums;
using System;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// A <see cref="CustomOasObjectEngine"/> class designed to hold the
    /// class name of the API method in the Endpoint. 
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class CalculatedDateValue : CustomOasObjectEngine
    {

        /// <summary>
        /// The Date used as a starting point for the calculated date.
        /// </summary>
        public string BaseDate { get; set; }

        /// <summary>
        /// The standard C# Date Format string for representing the date
        /// </summary>
        public string DateFormatter { get; set; }

        /// <summary>
        /// The number of days to add to the BaseDate for the final value.
        /// Using a negative number will represent days in the past.
        /// </summary>
        public int DaysOffset { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="CalculatedDateValue"/> object.
        /// </summary>
        public CalculatedDateValue() 
        {
            BaseDate = string.Empty;
            DateFormatter = string.Empty;
            DaysOffset = 0;
            customEndPointObjectType = CustomEndPointObjectTypeEnum.CalculatedDateValue;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CalculatedDateValue"/> object
        /// and populates the values from the provided input string
        /// </summary>
        /// <param name="description">A string that contains a <see cref="ParserTokens.PARAM_StartDate"/> token
        /// and a set of <see cref="ParserTokens.TKN_CalculatedDateStringFormat"/> values.</param>
        public CalculatedDateValue(string description)
        {
            customEndPointObjectType = CustomEndPointObjectTypeEnum.CalculatedDateValue;
            ParseTheInputString(description);
        }

        private void ParseTheInputString(string description)
        {
            // @CurrentDate,"yyyy-MM-dd",-30
            string[] items = description.Split(',', StringSplitOptions.RemoveEmptyEntries);

            BaseDate = items[0];

            DateFormatter = items[1].Replace("\"", "");

            int offset;
            if(Int32.TryParse(items[2], out offset) == true)
            {
                DaysOffset = offset;
            }
            else
            {
                DaysOffset = 0;
            }
        }
    }
}
