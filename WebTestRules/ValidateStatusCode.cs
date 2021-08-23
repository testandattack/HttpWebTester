using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using Serilog;
using System;

namespace WebTestRules
{
    public class ValidateStatusCode : ValidationRule
    {
        public ValidateStatusCode() 
        { 
            type = typeof(ValidateStatusCode);
            TypeAsString = "ValidateStatusCode";
        }

        public override void Validate(object sender, RuleEventArgs e)
        {
            Log.ForContext("SourceContext", "Rules").Debug("entering ValidateStatusCode-Validate for {request}", e.requestItem.guid);
            if (e.response.IsSuccessStatusCode)
            {
                RuleResult = RuleResult.Passed;
            }
            else
            {
                RuleResult = RuleResult.Failed;
            }
        }
    }
}
