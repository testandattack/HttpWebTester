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
            RuleType = RuleType.RequestRule_Validation;
            type = typeof(ValidateStatusCodeValue);
            Name = "Validate Status Code Value";
            HttpStatusCode = statusCode;
        }

        public override void Validate(object sender, RuleEventArgs e)
        {
            Log.ForContext("SourceContext", "ValidateStatusCodeValue").Verbose("entering ValidateStatusCodeValue for {request}", e.requestItem.guid);
            if (e.response.StatusCode == HttpStatusCode)
            {
                RuleResult = RuleResult.Passed;
                Log.ForContext("SourceContext", "Rules").Information("PASS: ValidateStatusCodeValue for {request} passed.", e.requestItem.guid);
            }
            else
            {
                RuleResult = RuleResult.Failed;
                Log.ForContext("SourceContext", "Rules").Error("FAIL: ValidateStatusCodeValue for {request} Failed", e.requestItem.guid);
            }
        }
    }
}
