using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;
using Serilog;

namespace PostmanManager
{
    public class PostmanItem_JsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ItemCollection).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenType = reader.TokenType;
            try
            {
                JObject obj = JObject.Load(reader);
                Console.WriteLine($"Reading {(string)obj["request"]}");

                string type = (string)obj["request"];
                if (type != null)
                {
                    var item = new Item();
                    serializer.Populate(obj.CreateReader(), item as Item);
                    Console.WriteLine($"PostmanItem_JsonConverter: ItemName = {item.Name}");
                    return item;
                }
                else
                {
                    var itemGroup = new ItemGroup();
                    serializer.Populate(obj.CreateReader(), itemGroup as ItemGroup);
                    Console.WriteLine($"PostmanItem_JsonConverter: ItemName = {itemGroup.Name}");
                    return itemGroup;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in PostmanItem_JsonConverter with {tokenType}: {reader.Value.ToString()}");
            }
            return null;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
