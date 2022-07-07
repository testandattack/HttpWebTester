using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;
using Version = PostmanManager.Models.Version;

namespace PostmanManager
{
    public class PostmanPath_JsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Path).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Path itemPath = new Path();
            try
            {
                if(reader.TokenType == JsonToken.String)
                {
                    itemPath.stringPath = reader.Value.ToString();
                    itemPath.objectPath = null;
                    itemPath.stringArrayPath = null;
                    itemPath.Type = PathObjectType_Enum.String;
                }
                else if(reader.TokenType == JsonToken.StartArray)
                {
                    var result = (JToken)serializer.Deserialize(reader);
                    if (result.First.Type == JTokenType.String)
                    {
                        itemPath.stringArrayPath = result.ToObject<string[]>();
                        itemPath.objectPath = null;
                        itemPath.stringPath = null;
                    itemPath.Type = PathObjectType_Enum.StringArray;
                    }
                    else
                    {
                        itemPath.objectPath = result.ToObject<object[]>();
                        itemPath.objectPath = null;
                        itemPath.stringPath = null;
                    itemPath.Type = PathObjectType_Enum.ObjectArray;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return itemPath;
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
            //var obj = new JObject();

            //obj.Add("major", (value as Version).Major);
            //obj.Add("minor", (value as Version).Minor);
            //obj.Add("patch", (value as Version).Patch);
            //obj.Add("identifier", (value as Version).Identifier);

            //obj.WriteTo(writer);
        }
    }
}
