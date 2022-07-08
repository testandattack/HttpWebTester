using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager
{
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
                    Header header = new Header();
                    header.Value = reader.Value.ToString();
                    return header;
                }
                else
                {
                    return serializer.Deserialize<List<Header>>(reader);
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
            throw new NotImplementedException();
        }
    }
}
