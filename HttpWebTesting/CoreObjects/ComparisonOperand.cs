using System;
using System.Collections.Generic;
using System.Text;
using GTC.Extensions;

namespace HttpWebTesting.CoreObjects
{
    public class ComparisonOperand
    {
        public string Operand { get; set; }

        public Type Type { get; private set; }

        /// <summary>
        /// The constructor takes a string value and determines if it is 
        /// a boolean, a numeric value or a string and assigns the type.
        /// </summary>
        /// <param name="operandValue"></param>
        public ComparisonOperand(string operandValue)
        {
            if (operandValue.IsBoolean())
                Type = typeof(System.Boolean);

            else Type = operandValue.IsNumeric();

            Operand = operandValue;
        }

        public ComparisonOperand()
        {
            Operand = string.Empty;
            Type = typeof(System.String);
        }
    }
}
