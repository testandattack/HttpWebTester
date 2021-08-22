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
    public class PostRequestRule : BaseRule
    {
        public override object Clone()
        {
            return base.MemberwiseClone();
        }

        public PostRequestRule() 
        {
            RuleType = Enums.RuleTypes_Enums.RequestRule_PostRequest;
        }

        public virtual void PostRequest(object sender, PostRequestEventArgs e) { }
    }
}
