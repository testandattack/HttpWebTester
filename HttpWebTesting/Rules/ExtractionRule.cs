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
    public class ExtractionRule : BaseRule
    {
        public override object Clone()
        {
            return base.MemberwiseClone();
        }

        public ExtractionRule() 
        {
            RuleType = Enums.RuleTypes_Enums.RequestRule_Extraction;
        }

        public virtual void Extract(object sender, RuleEventArgs e) { }
    }
}
