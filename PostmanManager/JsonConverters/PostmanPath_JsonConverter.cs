using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;
using Version = PostmanManager.Models.Version;

namespace PostmanManager
{
    /// <summary>
    /// Custom Json Converter to handle <see cref="Path"/> objects from Postman
    /// </summary>
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
                    Console.WriteLine("PostmanPath_JsonConverter: found String");
                    itemPath.stringPath = reader.Value.ToString();
                    itemPath.objectPath = null;
                    itemPath.stringArrayPath = null;
                    itemPath.Type = PathObjectType_Enum.String;
                }
                else if(reader.TokenType == JsonToken.StartArray)
                {
                    Console.WriteLine("PostmanPath_JsonConverter: found StartArray");
                    var result = (JToken)serializer.Deserialize(reader);
                    if (result.First.Type == JTokenType.String)
                    {
                        Console.WriteLine("PostmanPath_JsonConverter: found String inside StartArray");
                        itemPath.stringArrayPath = result.ToObject<string[]>();
                        itemPath.objectPath = null;
                        itemPath.stringPath = null;
                        itemPath.Type = PathObjectType_Enum.StringArray;
                    }
                    else
                    {
                        Console.WriteLine("PostmanPath_JsonConverter: found Object inside StartArray");
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
            var obj = new JObject();

            if ((value as Path).stringPath != null)
            {
                obj.Add("path", (value as Path).stringPath);
                obj.WriteTo(writer);
            }
            else if ((value as Path).stringArrayPath != null)
            {
                obj.Add("path", JToken.FromObject((value as Path).stringArrayPath));
                obj.WriteTo(writer);
            }
            else if ((value as Path).objectPath != null)
            {
                obj.Add("path", JToken.FromObject((value as Path).objectPath));
                obj.WriteTo(writer);
            }
        }
    }
}
