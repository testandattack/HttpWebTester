using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using GTC.Extensions;
using HttpWebTesting;

namespace HttpWebTestingResults.Utilities
{
    class HttpContentConverter : JsonConverter<HttpContent>
    {
        public override HttpContent ReadJson(JsonReader reader, Type objectType, HttpContent existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jo = JObject.Load(reader);

            string contentMethodType = (string)jo["ContentMethodType"];

            if (contentMethodType == "StringContent")
            {
                StringContentConverter converter = new StringContentConverter();
                return (converter.ReadJson(jo, objectType, existingValue as StringContent, hasExistingValue, serializer));
            }
            else
                return null;
        }

        public override void WriteJson(JsonWriter writer, HttpContent value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    class StringContentConverter : JsonConverter<StringContent>
    {
        public override StringContent ReadJson(JsonReader reader, Type objectType, StringContent existingValue, bool bValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            return ReadJson(jo, objectType, existingValue, bValue, serializer);
        }

        public StringContent ReadJson(JObject jo, Type objectType, StringContent existingValue, bool bValue, JsonSerializer serializer)
        {
            string content = (string)jo["Content"];
            string contentType = (string)jo["Content-Type"];

            string mediaType = contentType.Substring(0, contentType.IndexOf(";"));
            string encodingValue = contentType.FindSubString("charset=", "XXX", true);

            Encoding encoding;
            switch (encodingValue)
            {
                case "UTF8":
                    encoding = Encoding.UTF8;
                    break;
                case "ASCII":
                    encoding = Encoding.ASCII;
                    break;
                case "Unicode":
                    encoding = Encoding.Unicode;
                    break;
                case "UTF7":
                    encoding = Encoding.UTF7;
                    break;
                case "BigEndianUnicode":
                    encoding = Encoding.BigEndianUnicode;
                    break;
                case "UTF32":
                    encoding = Encoding.UTF32;
                    break;
                default:
                    encoding = Encoding.Default;
                    break;
            }

            return new StringContent(content, encoding, mediaType);
        }

        public override void WriteJson(JsonWriter writer, StringContent value, JsonSerializer serializer)
        {
            var obj = new JObject();
            obj.Add("ContentMethodType", "StringContent");

            foreach(var header in (value as StringContent).Headers)
            {
                obj.Add(header.Key, header.Value.ToString(";"));
            }
            obj.Add("Content", (value as StringContent).ReadAsStringAsync().GetAwaiter().GetResult());

            obj.WriteTo(writer);
            //writer.WriteValue(new JObject { new JProperty("Content", obj) });
        }
    }
}
