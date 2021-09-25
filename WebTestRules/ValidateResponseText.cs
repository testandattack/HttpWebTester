using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using Serilog;
using System;
using System.ComponentModel;

namespace WebTestRules
{
    public class ValidateResponseText : ValidationRule
    {
        #region -- Properties -----
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

        /// <summary>
        /// If true, the rulw will ignore UPPER/lower case when searching for a match.
        /// </summary>
        [DisplayName("Ignore Case")]
        [Description("If true, the rulw will ignore UPPER/lower case when searching for a match.")]
        [DefaultValue(false)]
        public bool IgnoreCase { get; set; }
        #endregion

        #region -- Constructors -----
        public ValidateResponseText()
        {
            type = typeof(ValidateResponseText);
            Name = "Validate Response Text";
        }

        public ValidateResponseText(string textToFind)
        {
            type = typeof(ValidateResponseText);
            Name = "Validate Response Text";
            ValueToFind = textToFind;
        }

        public ValidateResponseText(string textToFind, bool ignoreCase)
        {
            type = typeof(ValidateResponseText);
            Name = "Validate Response Text";
            ValueToFind = textToFind;
            IgnoreCase = ignoreCase;
        }

        public ValidateResponseText(string textToFind, bool ignoreCase, bool passIfTextFound)
        {
            type = typeof(ValidateResponseText);
            Name = "Validate Response Text";
            ValueToFind = textToFind;
            IgnoreCase = ignoreCase;
            PassIfTextIsFound = passIfTextFound;
        }
        #endregion

        public override void Validate(object sender, RuleEventArgs e)
        {
            Log.ForContext("SourceContext", "Rules").Verbose("entering ValidateResponseContains-Validate for {request}", e.requestItem.guid);

            StringComparison comparison;
            if (IgnoreCase)
                comparison = StringComparison.CurrentCultureIgnoreCase;
            else
                comparison = StringComparison.CurrentCulture;

            string responseString = e.response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            bool responseContainsValue = responseString.Contains(ValueToFind, comparison);

            // Use XOR to look for the two possible combinations that would fail.
            // PassIfTextIsFound        responseContainsValue   (xor)Result
            // ---------------------------------------------------------
            //  true                |   true                  | (false)PASS
            //  true                |   false                 | (true)FAIL
            //  false               |   false                 | (false)PASS
            //  false               |   true                  | (true)FAIL

            if (PassIfTextIsFound ^ responseContainsValue)
            {
                RuleResult = RuleResult.Failed;
                Log.ForContext("SourceContext", "Rules").Error("FAIL: ValidateResponseContains for {request} Failed", e.requestItem.guid);
            }
            else
            {
                RuleResult = RuleResult.Passed;
                Log.ForContext("SourceContext", "Rules").Information("PASS: ValidateResponseContains for {request} passed.", e.requestItem.guid);
            }
        }
    }
}
