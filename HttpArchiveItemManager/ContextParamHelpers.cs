using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;
using System.Globalization;

namespace GTC.Utilities
{
    public static class ContextParamHelpers
    {
        public static string GetParameterizedValue(string InputString, WebTestContext context)
        {
            // Do we have anything to locate and replace?
            int iStart = InputString.IndexOf("{{");
            if (iStart == -1) return InputString;

            // Did we find the closing part properly?
            int iEnd = InputString.IndexOf("}}", iStart);
            if (iEnd == -1) throw new ArgumentException(String.Format("No closing context delimiter was found in the string: {0}", InputString));
            else if (iEnd <= iStart) throw new ArgumentException(String.Format("Closing context delimiter was found BEFORE the opening delimiter: {0}", InputString));

            // Get the context
            string contextName = InputString.Substring(iStart + 2, iEnd - (iStart + 2));
            if(!context.ContainsKey(contextName)) throw new ArgumentException(String.Format("Context does not contain the key being used: {0}", contextName));

            // Quick send. Assumes that the entire string was the context
            if (iStart == 0 && iEnd == InputString.Length - 2)
                return context[contextName].ToString();

            // Build and return the final string. Assumes the context was embedded inside the string.
            return String.Format("{0}{1}{2}",
                iStart == 0 ? "" : InputString.Substring(0, iStart)
                , context[contextName].ToString()
                , iEnd == InputString.Length - 2 ? "" : InputString.Substring(iEnd + 2));
        }
    }
}
