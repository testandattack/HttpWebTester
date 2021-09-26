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
    public class ContextCollection : BaseCollection<Property>
    {
        public void Add(string propertyName, string propertyValue)
        {
            foreach (Property contextProperty in this)
            {
                if (contextProperty.Name == propertyName)
                {
                    contextProperty.Value = propertyValue;
                    return;
                }
            }
            base.Add(new Property(propertyName, propertyValue));
        }

        public string this[string propertyName]
        {
            get
            {
                foreach (Property contextProperty in this)
                {
                    if (contextProperty.Name == propertyName)
                    {
                        return contextProperty.Value;
                    }
                }
                return null;
            }
            set
            {
                foreach (Property contextProperty in this)
                {
                    if (contextProperty.Name == propertyName)
                    {
                        contextProperty.Value = value;
                        return;
                    }
                }
                base.Add(new Property(propertyName, value));
            }
        }

        /// <summary>
        /// This method is used to add or update context values that
        /// are derived from data sources.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="DataSourceName"></param>
        public void AddDataSourceRow(Dictionary<string, string> values, string DataSourceName)
        {
            foreach(var kvp in values)
            {
                string contextName = $"{DataSourceName}.{kvp.Key}";
                var prop = this.Where(p => p.Name == contextName).FirstOrDefault();
                if (prop == null)
                    base.Add(new Property(contextName, kvp.Value));
                else
                    prop.Value = kvp.Value;
            }
        }

        public string GetValue(string contextName)
        {
            foreach(Property property in base.Items)
            {
                if (property.Name == contextName)
                    return property.Value;
            }
            return string.Empty;
        }

        public void BuildRequestWithContextValues(WTI_Request request)
        {
            Log.ForContext("SourceContext", "RequestExecution").Debug("entering ApplyContexts for {request}", request.guid);

            string sUrl = ContextReplacement(request.RequestUri.AbsoluteUri);
            request.requestItem = new HttpRequestMessage(request.Method, sUrl);
            request.requestItem.Headers.Clear();

            foreach (var header in request.Headers)
            {
                request.requestItem.Headers.Add(header.Key, ContextReplacement(header.Value.ToString(";")));
            }

            request.requestItem.Content = ApplyContextsToContent(request.Content);
            request.ReportingName = ContextReplacement(request.ReportingName);

        }

        private string ContextReplacement(string inputString)
        {
            string outputString = inputString.UrlDecode();
            List<string> contextNames = outputString.FindSubStrings("{{", "}}");
            foreach (string name in contextNames)
            {
                string value = this.GetValue(name);
                if (value != string.Empty)
                {
                    outputString = outputString.Replace(name.AddBraces(), value);
                }
            }
            return outputString;
        }

        private HttpContent ApplyContextsToContent(HttpContent content)
        {
            #region === Request Body dissection ==========
            if (content == null)
            {
                return null;
            }
            else if (content is StringContent)
            {
                string strContent = content.ReadAsStringAsync().GetAwaiter().GetResult();

                return new StringContent(ContextReplacement(strContent)
                    , GetEncoding(content.Headers.ContentType.CharSet)
                    , content.Headers.ContentType.MediaType);
            }
            else if (content is MultipartFormDataContent)
            {
                throw new NotImplementedException();
            }
            else if (content is ByteArrayContent)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
            #endregion
        }

        private Encoding GetEncoding(string encodingValue)
        {
            switch (encodingValue)
            {
                case "UTF8":
                    return Encoding.UTF8;
                case "ASCII":
                    return Encoding.ASCII;
                case "Unicode":
                    return Encoding.Unicode;
                case "UTF7":
                    return Encoding.UTF7;
                case "BigEndianUnicode":
                    return Encoding.BigEndianUnicode;
                case "UTF32":
                    return Encoding.UTF32;
                default:
                    return Encoding.Default;
            }
        }
    }
}
