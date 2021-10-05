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
    /// A base class for creating custom extraction rules for the webtest.
    /// </summary>
    public class ExtractionRule : BaseRule
    {
        public override object Clone()
        {
            return base.MemberwiseClone();
        }

        /// <summary>
        /// The name of the Context Property that will hold the extracted value
        /// </summary>
        [DisplayName("Context Name")]
        [Description("The name of the context property to hold the extracted value.")]
        public string ContextName { get; set; }

        public ExtractionRule() 
        {
            RuleType = Enums.RuleType.RequestRule_Extraction;
            baseRuleType = BaseRuleType.Extraction;
        }

        public virtual void Extract(object sender, RuleEventArgs e) { }
    }
}
