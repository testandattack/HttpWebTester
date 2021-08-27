using System;
using System.Collections.Generic;
using System.Text;
using GTC.Extensions;

namespace HttpWebTesting.Rules
{
    /// <summary>
    /// Property used as input to a rule or a control loop.
    /// </summary>
    public class RuleProperty
    {
        public string Value { get; set; }

        public Type Type { get; private set; }

        /// <summary>
        /// The constructor takes a string value and determines if it is 
        /// a boolean, a numeric value or a string and assigns the type.
        /// </summary>
        /// <param name="propertyValue"></param>
        public RuleProperty(string propertyValue)
        {
            if (propertyValue.IsBoolean())
                Type = typeof(System.Boolean);

            else Type = propertyValue.IsNumeric();

            Value = propertyValue;
        }

        public RuleProperty()
        {
            Value = string.Empty;
            Type = typeof(System.String);
        }
    }
}
