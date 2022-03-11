using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using GTC.Extensions;

namespace HttpWebExtensions
{
    public static class HttpRequestMessageExtensions
    {
        public static string GetRequestBody(this HttpRequestMessage source)
        {
            if (source.Content == null)
                return "No request content found";

            else if (source.Content is StringContent)
            {
                return source.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            else if (source.Content is MultipartFormDataContent)
            {
                throw new NotImplementedException();
            }
            else if (source.Content is ByteArrayContent)
            {
                byte[] content = source.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x < content.Length; x++)
                {
                    sb.Append(Convert.ToChar(content[x]));
                }
                return sb.ToString();
            }
            else if (source.Content is FormUrlEncodedContent)
            {
                string content = source.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return content;
            }
            else
            {
                throw new NotImplementedException();
            }
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
