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
    /// Custom Json Converter to handle <see cref="Version"/> objects from Postman
    /// </summary>
    public class PostmanVersion_JsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(System.String))
                return true;
            else
                return typeof(Version).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Version itemVersion = null;
            try
            {
                if(reader.TokenType == JsonToken.String)
                {
                    Console.WriteLine(" PostmanVersion_JsonConverter string token");
                    itemVersion = new Version();
                    itemVersion.Major = 0;
                    itemVersion.Minor = 0;
                    itemVersion.Patch = 0;
                    itemVersion.Identifier = string.Empty;
                    itemVersion.VersionAsString = reader.Value.ToString();
                }
                else
                {
                    Console.WriteLine(" PostmanVersion_JsonConverter object token");
                    //itemVersion = serializer.Deserialize<Version>(reader);
                    itemVersion.VersionAsString = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return itemVersion;
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Version version = (value as Version);

            if (version.IsString())
            {
                writer.WritePropertyName("version");
                writer.WriteValue(version.VersionAsString);
            }
            else
            {
                var obj = new JObject();

                obj.Add("major", (value as Version).Major);
                obj.Add("minor", (value as Version).Minor);
                obj.Add("patch", (value as Version).Patch);
                obj.Add("identifier", (value as Version).Identifier);

                obj.WriteTo(writer);
            }
        }
    }
}
