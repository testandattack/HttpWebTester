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
    /// A base class for creating custom PreWebTest rules for the webtest.
    /// </summary>
    public class PreWebTestRule : BaseRule
    {
        public override object Clone()
        {
            return base.MemberwiseClone();
        }

        public PreWebTestRule() 
        {
            RuleType = Enums.RuleType.PreTest;
            baseRuleType = BaseRuleType.PreTest;
        }

        public virtual void PreWebTest(object sender, PreWebtestEventArgs e) { }
    }
}
