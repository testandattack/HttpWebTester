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
    public class RequestValidationRule : BaseRule
    {

        /// <summary>
        /// Contains the value on the left side of the comparison statement
        /// </summary>
        [Category("Comparison")]
        public ComparisonOperand FirstOperand { get; set; }

        /// <summary>
        /// An enum that describes what type of comparison is used when 
        /// validting response.
        /// </summary>
        /// <remarks>
        /// The possible values can be seen in the <see cref="Enums.ComparisonType"/>
        /// enum. A value of <b><see cref="ComparisonType.IsLoop"/></b> indicates that the
        /// control will use the three optional loop values
        /// <list type="bullet">
        /// <item><see cref="LoopStartingValue"/></item>
        /// <item><see cref="LoopEndingValue"/></item>
        /// <item><see cref="LoopIncrementValue"/></item>
        /// </list>
        /// These three values will be ignored for all other <see cref="Enums.ComparisonType"/>
        /// values
        /// </remarks>
        [Category("General")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ComparisonType ValidationComparisonType { get; set; }

        /// <summary>
        /// Contains the value on the right side of the comparison statement
        /// </summary>
        [Category("Comparison")]
        public ComparisonOperand SecondOperand { get; set; }

        public override object Clone()
        {
            return base.MemberwiseClone();
        }

        public RequestValidationRule() 
        {
            RuleType = Enums.RuleTypes_Enums.RequestRule_Validation;
            FirstOperand = new ComparisonOperand();
            ValidationComparisonType = ComparisonType.IsEqual;
            SecondOperand = new ComparisonOperand();
        }

        public virtual void PostRequest(object sender, PostRequestEventArgs e) { }
    }
}
