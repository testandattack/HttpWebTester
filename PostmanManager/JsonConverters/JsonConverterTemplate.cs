using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;

namespace PostmanManager
{
    public class JsonConverterTemplate : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ItemCollection).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            string type = (string)obj["request"];
            ItemCollection baseEvent;
            if (type != null)
            {
                baseEvent = new Item();
                serializer.Populate(obj.CreateReader(), baseEvent as Item);
            }
            else
            {
                baseEvent = new ItemGroup();
                serializer.Populate(obj.CreateReader(), baseEvent as ItemGroup);
            }
            return baseEvent;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
