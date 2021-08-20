using HttpWebTesting.CoreObjects;
using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using System;

namespace WebTestRules
{
    public class ValidateResponseContains : ValidationRule
    {
        public ComparisonOperand SecondOperand { get; set; }

        public ValidateResponseContains(string ResponseShouldContain)
        {
            SecondOperand.Operand = ResponseShouldContain;
        }

        public override void PostRequest(object sender, PostRequestEventArgs e)
        {
            string responseString = e.response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //base.PostRequest(sender, e);
            if (responseString.Contains(SecondOperand.Operand))
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
