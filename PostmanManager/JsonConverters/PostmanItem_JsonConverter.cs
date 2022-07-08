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
            //if (objectType == typeof(Item) || objectType == typeof(ItemGroup))
            //    return true;

            //return false;
            return objectType == typeof(ItemCollection);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            //Console.WriteLine($"Reading {(string)obj["itemCollection"]}");

            if(obj.ContainsKey("item"))
            {
                //return serializer.Deserialize<List<ItemGroup>>(reader);
                Console.WriteLine($"PostmanItem_JsonConverter: ItemGroup");
                var itemGroup = new ItemGroup();
                serializer.Populate(obj.CreateReader(), itemGroup as ItemGroup);
                return itemGroup;
            }
            else
            {
                //return serializer.Deserialize<Item>(reader);
                Console.WriteLine($"PostmanItem_JsonConverter: Item");
                var item = new Item();
                serializer.Populate(obj.CreateReader(), item as Item);
                return item;
            }
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
