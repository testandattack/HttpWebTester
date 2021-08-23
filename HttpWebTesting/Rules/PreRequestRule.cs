using HttpWebTesting.CoreObjects;
using HttpWebTesting.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HttpWebTesting.Rules
{
    /// <summary>
    /// A base class for creating custom PreRequest rules for the webtest.
    /// </summary>
    public class PreRequestRule : BaseRule
    {
        public override object Clone()
        {
            return base.MemberwiseClone();
        }

        public PreRequestRule() 
        {
            RuleType = Enums.RuleTypes_Enums.RequestRule_PreRequest;
            baseRuleType = BaseRuleTypes.PreRequest;
        }

        public virtual void PreRequest(object sender, PreRequestEventArgs e) { }
    }
}
