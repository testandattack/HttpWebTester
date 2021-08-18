using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using HttpWebTesting.CoreObjects;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HttpWebTesting.WebTestItems
{
    public class WTI_LoopControl : WebTestItem
    {
        /// <summary>
        /// The friendly name of the loop. This is what 
        /// will be displayed in the webtest viewer
        /// </summary>
        [Category("General")]
        public string Name { get; set; }

        /// <summary>
        /// A description that summarizes the purpose of the loop.
        /// </summary>
        [Category("General")]
        public string Description { get; set; }

        /// <summary>
        /// A flag that tells the test execution engine whether to 
        /// execute the items in the loop or ignore them.
        /// </summary>
        [Category("General")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// An enum that describes what type of comparison is used when 
        /// evaluating the control for continued execution.
        /// </summary>
        /// <remarks>
        /// The possible values can be seen in the <see cref="Enums.ControlComparisonType"/>
        /// enum. A value of <b><see cref="ControlComparisonType.IsLoop"/></b> indicates that the
        /// control will use the three optional loop values
        /// <list type="bullet">
        /// <item><see cref="LoopStartingValue"/></item>
        /// <item><see cref="LoopEndingValue"/></item>
        /// <item><see cref="LoopIncrementValue"/></item>
        /// </list>
        /// These three values will be ignored for all other <see cref="Enums.ControlComparisonType"/>
        /// values
        /// </remarks>
        [Category("General")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ControlComparisonType ControlComparisonType { get; set; }

        /// <summary>
        /// An enum that describes what scope applies to the <see cref="WTI_LoopControl.ControlComparisonType"/>
        /// when evaluating the control for continued execution.
        /// </summary>
        /// <remarks>
        /// The possible values can be seen in the <see cref="Enums.ControlComparisonType"/>
        /// enum. 
        /// </remarks>
        [Category("Comparison")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ControlComparisonScope ControlComparisonScope { get; set; }

        /// <summary>
        /// Contains the value on the left side of the comparison statement
        /// </summary>
        [Category("Comparison")]
        public ComparisonOperand FirstOperand { get; set; }


        /// <summary>
        /// Contains the value on the right side of the comparison statement
        /// </summary>
        [Category("Comparison")]
        public ComparisonOperand SecondOperand { get; set; }

        /// <summary>
        /// [OPTIONAL] The starting value for the control when run as a loop
        /// </summary>
        [Category("Loop")]
        public int? LoopStartingValue { get; set; }

        /// <summary>
        /// [OPTIONAL] The ending value for the control when run as a loop
        /// </summary>
        [Category("Loop")]
        public int? LoopEndingValue { get; set; }

        /// <summary>
        /// [OPTIONAL] The amount to increment the counter for the control when run as a loop
        /// </summary>
        [Category("Loop")]
        public int? LoopIncrementValue { get; set; }

        /// <summary>
        /// This flag indicates whether the data sources associated with the test 
        /// should advance their cursor each time an iteration of this loop completes execution.
        /// </summary>
        [Category("General")]
        public bool AdvanceDataSourceOnEachIteration { get; set; }

        /// <summary>
        /// This is a collection of the <see cref="WebTestItem"/> items that will be executed
        /// for each iteration of this loop control.
        /// </summary>
        [Category("General")]
        public WebTestItemCollection webTestItems { get; set; }
     }
}
