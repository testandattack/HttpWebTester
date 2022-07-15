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
    /// Custom Json Converter to handle <see cref="Auth"/> objects from Postman
    /// </summary>
    public class PostmanAuth_JsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Auth).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Auth auth = new Auth();
            serializer.Populate(obj.CreateReader(), auth);
            return auth;
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = new JObject();
            var auth = (value as Auth);
            obj.Add("type", auth.Type.ToString());

            switch (auth.Type)
            {
                case AuthType_Enum.apikey:
                    obj.Add("apikey", JToken.FromObject(auth.ApiKey));
                    break;

                case AuthType_Enum.awsv4:
                    obj.Add("awsv4", JToken.FromObject(auth.AwsV4));
                    break;

                case AuthType_Enum.basic:
                    obj.Add("basic", JToken.FromObject(auth.Basic));
                    break;

                case AuthType_Enum.bearer:
                    obj.Add("bearer", JToken.FromObject(auth.Bearer));
                    break;

                case AuthType_Enum.digest:
                    obj.Add("digest", JToken.FromObject(auth.Digest));
                    break;

                case AuthType_Enum.edgegrid:
                    obj.Add("edgegrid", JToken.FromObject(auth.EdgeGrid));
                    break;

                case AuthType_Enum.hawk:
                    obj.Add("hawk", JToken.FromObject(auth.Hawk));
                    break;

                case AuthType_Enum.noauth:
                    obj.Add("noauth", JToken.FromObject(auth.NoAuth));
                    break;

                case AuthType_Enum.ntlm:
                    obj.Add("ntlm", JToken.FromObject(auth.Ntlm));
                    break;

                case AuthType_Enum.oauth1:
                    obj.Add("oauth1", JToken.FromObject(auth.OAuth1));
                    break;

                case AuthType_Enum.oauth2:
                    obj.Add("oauth2", JToken.FromObject(auth.OAuth2));
                    break;

                default:
                    break;
            }

            obj.WriteTo(writer);
        }
    }
}
