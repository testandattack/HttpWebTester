using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;

namespace PostmanManager
{
    /// <summary>
    /// Custom Json Converter to handle <see cref="Description"/> objects from Postman
    /// </summary>
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
                    Console.WriteLine(" PostmanDescription_JsonConverter String token");
                    itemDescription.Content = reader.Value.ToString();
                    itemDescription.Type = "text";
                    itemDescription.Version = null;
                }
                else
                {
                    Console.WriteLine(" PostmanDescription_JsonConverter object token");
                    var result = (JToken)serializer.Deserialize(reader);

                    if (result["content"] != null)
                        itemDescription.Content = result["url"].ToString();

                    if (result["type"] != null)
                        itemDescription.Type = result["type"].ToString();

                    if (result["version"] != null)
                        itemDescription.Version = result["version"].ToObject<Models.Version>();

                    return itemDescription;                    
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
            var description = (value as Description);

            if(description.Content != null)
                obj.Add("content", description.Content);
            if(description.Type != null)
                obj.Add("type", description.Type);
            if (description.Version != null)
                obj.Add("version", JToken.FromObject(description.Version));

            obj.WriteTo(writer);
        }
    }
}
