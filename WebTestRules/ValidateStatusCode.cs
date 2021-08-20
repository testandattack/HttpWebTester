using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using System;

namespace WebTestRules
{
    public class ValidateStatusCode : ValidationRule
    {
        public ValidateStatusCode() { }

        public override void PostRequest(object sender, PostRequestEventArgs e)
        {
            if (e.response.IsSuccessStatusCode)
            {
                RuleResult = RuleResult.Passed;
                Console.WriteLine("ValidateStatusCode rule passed.");
            }
            else
            {
                RuleResult = RuleResult.Failed;
            }
        }
    }
}
