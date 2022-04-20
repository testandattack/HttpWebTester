using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HttpWebTestingEditor
{
    public static class IntegerExtensions
    {
        public static float? DivideBy(this int dividend, int divisor)
        {
            try
            {
                float quotient = dividend / divisor;
                return quotient;
            }
            catch(DivideByZeroException ex)
            {
                Debug.Write("Divide by zero error");
            }
            return null;
        }
    }
}
