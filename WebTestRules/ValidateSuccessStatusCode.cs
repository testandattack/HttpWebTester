using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using Serilog;
using System;

namespace WebTestRules
{
    public class ValidateSuccessStatusCode : ValidationRule
    {
        public ValidateSuccessStatusCode() 
        { 
            type = typeof(ValidateSuccessStatusCode);
            Name = "Validate IsSuccess Status Code";
        }

        public override void Validate(object sender, RuleEventArgs e)
        {
            Log.ForContext("SourceContext", "Rules").Verbose("entering ValidateStatusCode-Validate for {request}", e.requestItem.guid);
            if (e.response.IsSuccessStatusCode)
            {
                RuleResult = RuleResult.Passed;
                Log.ForContext("SourceContext", "Rules").Information("PASS: ValidateSuccessStatusCode for {request} passed.", e.requestItem.guid);
            }
            else
            {
                RuleResult = RuleResult.Failed;
                Log.ForContext("SourceContext", "Rules").Error("FAIL: ValidateSuccessStatusCode for {request} Failed", e.requestItem.guid);
            }
        }
    }
}
