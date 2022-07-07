using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;

namespace PostmanManager
{
    public class PostmanDescription_JsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(System.String))
                return true;
            else
                return typeof(Description).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var itemDescription = new Description();
            try
            {
                if (reader.TokenType == JsonToken.String)
                {
                    itemDescription.Content = reader.Value.ToString();
                    itemDescription.Type = "text";
                    itemDescription.Version = null;
                }
                else
                {
                    itemDescription = reader.Value as Description;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine($"PostmanDescription_JsonConverter: Description = {itemDescription.Content}");

            return itemDescription;
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

            var obj = new JObject();

            obj.Add("content", (value as Description).Content);
            obj.Add("type", (value as Description).Type);
            obj.Add("varsion", (value as Description).Version.ToString());

            obj.WriteTo(writer);
        }
    }
}
