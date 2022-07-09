using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;

namespace PostmanManager
{
    public class StringOrNumberConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(StringOrNumber).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenType = reader.TokenType;
            try
            {
                StringOrNumber item = new StringOrNumber();
                if (reader.TokenType == JsonToken.String)
                {
                    item.StringValue = reader.Value.ToString();
                    item.NumberValue = null;
                }
                else if(reader.TokenType == JsonToken.Integer)
                {
                    item.NumberValue = Int32.Parse(reader.Value.ToString());
                    item.StringValue = null;
                }
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in StringOrNumberConverter with {tokenType}: {reader.Value.ToString()}");
            }
            return null;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(StringOrNumber))
            {
                if ((value as StringOrNumber).StringValue != null)
                {
                    writer.WritePropertyName(nameof(StringOrNumber));
                    writer.WriteValue((value as StringOrNumber).StringValue);
                }
                else if ((value as StringOrNumber).NumberValue != null)
                {
                    writer.WritePropertyName(nameof(StringOrNumber));
                    writer.WriteValue((value as StringOrNumber).NumberValue);
                }
            }
        }
    }
}
