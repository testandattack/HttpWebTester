using System;
using System.Collections.Generic;
using System.Text;
using GTC.Extensions;

namespace HttpWebTesting.Rules
{
    /// <summary>
    /// Property used as input to a rule or a control loop.
    /// </summary>
    public class RuleProperty : IComparable
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

        public int CompareTo(object obj)
        {
            // String Comparer
            if(obj.GetType() == typeof(System.String)
                && this.GetType() == typeof(System.String))
            {
                return CompareString(this.Value, ((RuleProperty)obj).Value);
            }

            // Boolean Comparer
            else if (obj.GetType() == typeof(System.Boolean)
                && this.GetType() == typeof(System.Boolean))
            {
                return CompareString(this.Value.ToUpper(), ((RuleProperty)obj).Value.ToUpper());
            }

            // Int32 Comparer
            else if (obj.GetType() == typeof(System.Int32)
                && this.GetType() == typeof(System.Int32))
            {
                return CompareInt32(this.Value, ((RuleProperty)obj).Value);
            }

            // Double Comparer
            else if (obj.GetType() == typeof(System.Double)
                && this.GetType() == typeof(System.Double))
            {
                return CompareDouble(this.Value, ((RuleProperty)obj).Value);
            }

            // Comparer for items that are not the same type
            else
            {
                // Current version does not check too carefully, so this could give a false comparison
                return CompareString(this.Value.ToUpper(), ((RuleProperty)obj).Value.ToUpper());
            }
        }

        private int CompareInt32(string s1, string s2)
        {
            // I do not TryParse here because I already parsed the string to get
            // the initial data type.
            int value1 = Int32.Parse(s1);
            int value2 = Int32.Parse(s2);

            if (value1 < value2)
                return -1;
            if (value1 == value2)
                return 0;
            return 1;
        }

        private int CompareDouble(string s1, string s2)
        {
            // I do not TryParse here because I already parsed the string to get
            // the initial data type.
            double value1 = Double.Parse(s1);
            double value2 = Double.Parse(s2);

            if (value1 < value2)
                return -1;
            if (value1 == value2)
                return 0;
            return 1;
        }

        private int CompareString(string s1, string s2)
        {
            return String.Compare(s1, s2);
        }
    }
}
