using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager
{
    /// <summary>
    /// Custom Json Converter to handle <see cref="Header"/> objects from Postman
    /// </summary>
    public class PostmanHeader_JsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(System.String))
                return true;
            else
                return typeof(Header).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (reader.TokenType == JsonToken.String)
                {
                    Console.WriteLine(" PostmanHeader_JsonConverter String token");
                    Header header = new Header();
                    header.Value = reader.Value.ToString();
                    return header;
                }
                else
                {
                    Console.WriteLine(" PostmanHeader_JsonConverter object token");
                    Header header = new Header();

                    var result = (JToken)serializer.Deserialize(reader);

                    if (result["key"] != null)
                        header.Key = result["key"].ToString();

                    if (result["value"] != null)
                        header.Value = result["value"].ToString();

                    if (result["disabled"] != null)
                        header.Disabled = result["disabled"].ToObject<Boolean>();

                    if (result["description"] != null)
                        header.Description = result["description"].ToObject<Description>();

                    return header;
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
            var header = (value as Header);

            if (header.Key != null)
                obj.Add("key", header.Key);

            if (header.Value != null)
                obj.Add("value", header.Value);

            obj.Add("disabled", header.Disabled);

            if (header.Description != null)
                obj.Add("description", JToken.FromObject(header.Description));

            obj.WriteTo(writer);
        }
    }
}
