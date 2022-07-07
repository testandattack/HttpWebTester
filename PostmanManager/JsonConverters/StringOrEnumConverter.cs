using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostmanManager.Models;

namespace PostmanManager
{
    //public class StringOrEnumConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        if (objectType == typeof(System.String))
    //            return true;
    //        else
    //            return typeof(string[]).IsAssignableFrom(objectType);
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        try
    //        {
    //            if (reader.TokenType == JsonToken.String)
    //            {
    //                string[] stringArray = new string[1];
    //                stringArray[0] = reader.Value.ToString();
    //                return stringArray;
    //            }
    //            else
    //            {
    //                var result = (JToken)serializer.Deserialize(reader);
    //                return result.ToObject<string[]>();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.ToString());
    //        }
    //        return null;
    //    }

    //    public override bool CanWrite => true;

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //        //var obj = new JObject();

    //        //if(value.GetType() == typeof(string[]))
    //        //{

    //        //}
    //        //else
    //        //{

    //        //}
    //        //obj.Add("content", (value as Description).Content);
    //        //obj.Add("type", (value as Description).Type);
    //        //obj.Add("varsion", (value as Description).Version.ToString());

    //        //obj.WriteTo(writer);
    //    }
    //}
}
