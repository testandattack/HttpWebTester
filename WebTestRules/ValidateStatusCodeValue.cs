using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using Serilog;
using System;
using System.Net;

namespace WebTestRules
{
    public class ValidateStatusCodeValue : ValidationRule
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public ValidateStatusCodeValue(HttpStatusCode statusCode) 
        {
            RuleType = RuleTypes_Enums.TestRule_Validation;
            type = typeof(ValidateStatusCodeValue);
            Name = "Validate Status Code Value";
            HttpStatusCode = statusCode;
        }

        public override void Validate(object sender, RuleEventArgs e)
        {
            Log.ForContext("SourceContext", "ValidateStatusCodeValue").Debug("entering Validate for {request}", e.requestItem.guid);
            if (e.response.StatusCode == HttpStatusCode)
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
