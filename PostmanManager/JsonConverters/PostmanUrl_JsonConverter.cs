using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;
using Version = PostmanManager.Models.Version;

namespace PostmanManager
{
    /// <summary>
    /// Custom Json Converter to handle <see cref="Url"/> objects from Postman
    /// </summary>
    public class PostmanUrl_JsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(System.String))
                return true;
            else
                return typeof(Url).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (reader.TokenType == JsonToken.String)
                {
                    Console.WriteLine(" PostmanUrl_JsonConverter string token");
                    Url url = new Url();
                    url.Raw = reader.Value.ToString();
                    return url;
                }
                else
                {
                    Console.WriteLine(" PostmanUrl_JsonConverter object token");
                    return new Url();
                    //return serializer.Deserialize<Url>(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = new JObject();
            var url = (value as Url);

            if (url.Raw != null)
                obj.Add("raw", url.Raw);

            if (url.Protocol != null)
                obj.Add("raw", url.Protocol);

            if (url.Host != null)
                obj.Add("host", JToken.FromObject(url.Path));

            if (url.Path != null)
                obj.Add("path", JToken.FromObject(url.Path));

            if (url.Port != null)
                obj.Add("port", url.Port);

            if (url.QueryParams != null)
                obj.Add("query", JToken.FromObject(url.QueryParams));

            if (url.Hash != null)
                obj.Add("hash", url.Hash);

            if (url.Variables != null)
                obj.Add("variable", JToken.FromObject(url.Variables));
            
            obj.WriteTo(writer);
        }
    }
}
