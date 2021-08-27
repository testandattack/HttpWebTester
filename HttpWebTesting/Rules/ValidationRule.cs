using HttpWebTesting.CoreObjects;
using HttpWebTesting.Enums;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HttpWebTesting.Rules
{
    /// <summary>
    /// A base class for creating custom Validation rules for the webtest.
    /// </summary>
    public class ValidationRule : BaseRule
    {
        public override object Clone()
        {
            return base.MemberwiseClone();
        }

        public RuleResult Outcome { get; set; }

        public ValidationRule() 
        {
            RuleType = Enums.RuleTypes_Enums.RequestRule_Validation;
            baseRuleType = BaseRuleType.Validation;
            Outcome = RuleResult.NotEvaluatedYet;
        }

        public virtual void Validate(object sender, RuleEventArgs e) { }
    }
}
