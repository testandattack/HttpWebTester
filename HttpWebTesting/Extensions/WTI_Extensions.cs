using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using HttpWebTesting.WebTestItems;

namespace HttpWebTesting.Extensions
{
    public static class WTI_Extensions
    {
        public static string GetRequestBody(this WTI_Request source)
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
    }
}
