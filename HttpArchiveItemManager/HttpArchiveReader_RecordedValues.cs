using Automatonic.HttpArchive;
using GTC.Utilities;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GTC.Utilities.WebTestProcessing;
using System.Text.RegularExpressions;

namespace GTC_HttpArchiveReader
{
    public partial class HttpArchiveReader
    {
        public void AddRecordedValues(string sFileName)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(sFileName))
            {
                while (sr.Peek() >= 0)
                {
                    string str = sr.ReadLine();
                    Regex regEx = new Regex(RecordedValueRegex);
                    if(regEx.IsMatch(str))
                    {
                        sb.AppendLine(str.Replace("RecordedValue=\"", GetRecordedValueString(str)));
                    }
                    else
                    {
                        sb.AppendLine(str);
                    }
                }
            }
            string sXml = sb.ToString();

            using (StreamWriter sw = new StreamWriter(sFileName, false))
            {
                sw.Write(sb.ToString());
            }
        }

        private string GetRecordedValueString(string stringLine)
        {
            int x = stringLine.IndexOf(" Value=\"") + 8;
            int y = stringLine.IndexOf("\"", x);
            string retVal = "RecordedValue=\"" + stringLine.Substring(x, y - x);
            return retVal;
        }
    }
}
