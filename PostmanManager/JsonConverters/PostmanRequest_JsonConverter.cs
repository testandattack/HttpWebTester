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
    /// Custom Json Converter to handle <see cref="Request"/> objects from Postman
    /// </summary>
    public class PostmanRequest_JsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(System.String))
                return true;
            else
                return typeof(Request).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (reader.TokenType == JsonToken.String)
                {
                    Console.WriteLine(" PostmanRequest_JsonConverter String token");
                    Request request = new Request();
                    request.RawRequest = reader.Value.ToString();
                    return request;
                }
                else
                {
                    Console.WriteLine(" PostmanRequest_JsonConverter object token");
                    var result = (JToken)serializer.Deserialize(reader);
                    
                    Request request = new Request();

                    if (result["url"] != null)
                        request.Url = result["url"].ToObject<Url>();
                    
                    if (result["auth"] != null)
                        request.Auth = result["auth"].ToObject<Auth>();
                    
                    if (result["proxy"] != null)
                        request.Proxy = result["proxy"].ToObject<Proxy>();
                    
                    if (result["certificate"] != null)
                        request.Certificate = result["certificate"].ToObject<Certificate>();

                    if (result["method"] != null)
                        request.Method = result["method"].ToString();

                    if (result["description"] != null)
                        request.Description = result["description"].ToObject<Description>();

                    if (result["header"] != null)
                        request.Headers = result["header"].ToObject<List<Header>>();

                    if (result["body"] != null)
                        request.Body = result["body"].ToObject<Body>();

                    return request;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = new JObject();
            var request = (value as Request);

            if (request.Auth != null)
                obj.Add("auth", JToken.FromObject(request.Auth));

            if (request.Body != null)
                obj.Add("body", JToken.FromObject(request.Body));

            if (request.Certificate != null)
                obj.Add("certificate", JToken.FromObject(request.Certificate));

            if (request.Description != null)
                obj.Add("description", JToken.FromObject(request.Description));

            if (request.Headers != null)
                obj.Add("header", JToken.FromObject(request.Headers));

            if (request.Method != null)
                obj.Add("method", request.Method);

            if (request.Proxy != null)
                obj.Add("proxy", JToken.FromObject(request.Proxy));

            if (request.Url != null)
                obj.Add("url", JToken.FromObject(request.Url));

            obj.WriteTo(writer);
        }
    }


    public class WrapWithValueConverter<TValue> : JsonConverter
    {
        // Here we take advantage of the fact that a converter applied to a 
        // property has highest precedence to avoid an infinite recursion.
        class DTO
        {
            [JsonConverter(typeof(NoConverter))]
            public TValue value { get; set; }
            public object GetValue() => value;
        }

        public override bool CanConvert(Type objectType) => typeof(TValue).IsAssignableFrom(objectType);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => serializer.Serialize(writer, new DTO { value = (TValue)value });

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => serializer.Deserialize<DTO>(reader)?.GetValue();
    }

    public class NoConverter : JsonConverter
    {
        // NoConverter taken from this answer https://stackoverflow.com/a/39739105/3744182
        // By https://stackoverflow.com/users/3744182/dbc
        // To https://stackoverflow.com/questions/39738714/selectively-use-default-json-converter
        public override bool CanConvert(Type objectType) { throw new NotImplementedException(); /* This converter should only be applied via attributes */ }
        public override bool CanRead => false;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => throw new NotImplementedException();
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}
