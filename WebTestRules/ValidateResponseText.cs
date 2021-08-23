using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using Serilog;
using System.ComponentModel;

namespace WebTestRules
{
    public class ValidateResponseText : ValidationRule
    {
        /// <summary>
        /// The string that the rule will look for in the response.
        /// </summary>
        [DisplayName("Value to Find")]
        [Description("The string that the rule will look for in the response.")]
        public string ValueToFind { get; set; }

        /// <summary>
        /// If true, the rule will pass if the text is found and fail if the text is not found.
        /// If false, the rule will fail if the text is found.
        /// </summary>
        [DisplayName("Pass If Text Is Found")]
        [Description("If true, the rule will pass if the text is found and fail if the text is not found.")]
        [DefaultValue(true)]
        public bool PassIfTextIsFound { get; set; }

        public ValidateResponseText()
        {
            type = typeof(ValidateResponseText);
            TypeAsString = "ValidateResponseContains";
        }


        public override void Validate(object sender, RuleEventArgs e)
        {
            Log.ForContext("SourceContext", "Rules").Debug("entering ValidateResponseContains-Validate for {request}", e.requestItem.guid);

            string responseString = e.response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            bool responseContainsValue = responseString.Contains(ValueToFind);
            
            // Use XOR to look for the two possible combinations that would fail.
            if (PassIfTextIsFound ^ responseContainsValue)
            {
                RuleResult = RuleResult.Failed;
            }
            else
            {
                RuleResult = RuleResult.Passed;
            }
        }
    }
}
