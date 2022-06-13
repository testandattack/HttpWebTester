using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GTC.Extensions;

namespace HttpWebExtensions
{
    public static class HttpRequestMessageExtensions
    {
        public static string GetRequestBody(this HttpRequestMessage source)
        {
            if (source.Content == null)
                return "No request content found";
            else
                return source.Content.GetRequestBody();
        }

        public static List<string> GetRequestHeaders(this HttpRequestMessage source)
        {
            List<string> headers = new List<string>();
            foreach(var header in source.Headers.AsEnumerable())
            {
                headers.Add($"{header.Key} = {header.Value.AsEnumerable().ToString(";")}");
            }
            return headers;
        }

        public static string GetRequestBody(this HttpContent source)
        {
            if (source is StringContent)
            {
                return source.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            else if (source is MultipartFormDataContent)
            {
                throw new NotImplementedException();
            }
            else if (source is ByteArrayContent)
            {
                byte[] content = source.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x < content.Length; x++)
                {
                    sb.Append(Convert.ToChar(content[x]));
                }
                return sb.ToString();
            }
            else if (source is FormUrlEncodedContent)
            {
                string content = source.ReadAsStringAsync().GetAwaiter().GetResult();
                return content;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static int GetContentLength(this HttpRequestMessage source)
        {
            string contentStr = source.GetRequestBody();
            if (contentStr == "No request content found")
                return 0;
            else
                return contentStr.Length;
        }

        public static List<string> GetContentHeaders(this HttpRequestMessage source)
        {
            return GetContentHeaders(source.Content);
        }

        public static List<string> GetContentHeaders(this HttpContent source)
        {
            List<string> headers = new List<string>();
            headers.Add(source.Headers.ContentType.CharSet);
            headers.Add(source.Headers.ContentType.MediaType);
            return headers;
        }

        private static string ResponseStringDivider = "--------------------------------------------------------\r\n";
        //public static string GetResponseAsString(this HttpResponseMessage source)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"{ResponseStringDivider}REQUEST: {source.RequestMessage.Method.Method} - {source.RequestMessage.RequestUri.AbsolutePath}");
        //    sb.AppendLine("Request Headers:");
        //    foreach (var header in source.RequestMessage.Headers)
        //    {
        //        sb.
        //    }

        //    return "";
        //}

        public static Dictionary<string, string> GetFormPostParamsFromContent(this FormUrlEncodedContent source)
        {
            string content = source.ReadAsStringAsync().GetAwaiter().GetResult();
            Dictionary<string, string> parms = new Dictionary<string, string>();
            foreach (string str in content.UrlDecode().Split("&", StringSplitOptions.RemoveEmptyEntries))
            {
                int x = str.IndexOf("=");
                if ((x + 1) >= str.Length)
                    parms.Add(str.Substring(0, x), "");
                else
                    parms.Add(str.Substring(0, x), str.Substring(x + 1));
            }
            return parms;

        }
    }
}
