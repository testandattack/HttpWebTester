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
    /// A base class for creating custom PostRequest rules for the webtest.
    /// </summary>
    public class PostRequestRule : BaseRule
    {
        public override object Clone()
        {
            return base.MemberwiseClone();
        }

        public PostRequestRule() 
        {
            RuleType = Enums.RuleType.RequestRule_PostRequest;
            baseRuleType = BaseRuleType.PostRequest;
        }

        public virtual void PostRequest(object sender, PostRequestEventArgs e) { }
    }
}
