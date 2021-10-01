using HttpWebTesting.CoreObjects;
using System.Collections.Generic;
using System.Linq;
using GTC.Extensions;
using System.Net.Http;
using HttpWebTesting.WebTestItems;
using System.Text;
using System;
using Serilog;

namespace HttpWebTesting.Collections
{
    public class QueryCollection
    {
        public Dictionary<string, string> queryParams { get; set; }

        public int Count
        {
            get
            {
                return queryParams.Count;
            }
        }

        public QueryCollection()
        {
            queryParams = new Dictionary<string, string>();
        }

        public string AddParametersFromUrl(string sUrl)
        {
            string newUrl = sUrl.UrlDecode();
            if(newUrl.Contains("?"))
            {
                newUrl = newUrl.Substring(newUrl.IndexOf("?") + 1);
            }
            foreach(string str in newUrl.Split(new string("&"), StringSplitOptions.RemoveEmptyEntries))
            {
                queryParams.Add(str.GetLeftPart("="), str.GetRightPart("="));
            }
            // Return this in case the consumer wants to reset the URL now that the
            // values are in the collection.
            return sUrl.GetUrlWithoutQuery();
        }
    }
}
