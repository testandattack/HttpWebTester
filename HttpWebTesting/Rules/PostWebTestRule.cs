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
    /// A base class for creating custom PostWebTest rules for the webtest.
    /// </summary>
    public class PostWebTestRule : BaseRule
    {
        public override object Clone()
        {
            return base.MemberwiseClone();
        }

        public PostWebTestRule() 
        {
            RuleType = Enums.RuleTypes_Enums.PostTest;
            baseRuleType = BaseRuleType.PostTest;
        }

        public virtual void PostWebTest(object sender, PostWebtestEventArgs e) { }
    }
}
