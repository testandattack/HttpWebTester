using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;
using Serilog;

namespace PostmanManager
{
    /// <summary>
    /// Custom Json Converter to handle <see cref="ItemCollection"/> objects from Postman
    /// </summary>
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
                Log.Debug($"PostmanItem_JsonConverter: ItemGroup");
                var itemGroup = new ItemGroup();
                serializer.Populate(obj.CreateReader(), itemGroup as ItemGroup);
                return itemGroup;
            }
            else
            {
                Log.Debug($"PostmanItem_JsonConverter: Item");
                var item = new Item();
                serializer.Populate(obj.CreateReader(), item as Item);
                return item;
            }
        }

        public override bool CanWrite => false;

        /// <summary>
        /// This overridden method never gets called since the base item is 
        /// an abstract class and the concrete instances do not need custom
        /// serializers.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
