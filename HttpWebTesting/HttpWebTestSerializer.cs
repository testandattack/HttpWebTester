using HttpWebTesting.WebTestItems;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JsonSubTypes;
using HttpWebTesting.Enums;

namespace HttpWebTesting
{
    public static class HttpWebTestSerializer
    {
        public static void SerializeTest(HttpWebTest httpWebTest, string webTestFileName)
        {
            using (StreamWriter sw = new StreamWriter(webTestFileName, false))
            {
                sw.Write(JsonConvert.SerializeObject(httpWebTest, Formatting.Indented));
                //sw.Write(JsonConvert.SerializeObject(httpWebTest, Formatting.Indented, GetSerializerSettings()));
            }
        }

        public static HttpWebTest DeserializeTest(string webTestFileName)
        {
            using (StreamReader sr = new StreamReader(webTestFileName))
            {
                return JsonConvert.DeserializeObject<HttpWebTest>(sr.ReadToEnd());
            }
        }

        //private static JsonSerializerSettings GetSerializerSettings()
        //{
        //    var settings = new JsonSerializerSettings();
        //    settings.Converters.Add(JsonSubtypesConverterBuilder
        //        .Of(typeof(WebTestItem), "objectItemType")
        //        .RegisterSubtype<WTI_Comment>(WebTestItemType.Wti_Comment)
        //        .RegisterSubtype<WTI_IncludedWebTest>(WebTestItemType.Wti_IncludedWebTestItem)
        //        .RegisterSubtype<WTI_LoopControl>(WebTestItemType.Wti_LoopControl)
        //        .RegisterSubtype<WTI_Request>(WebTestItemType.Wti_RequestObject)
        //        .RegisterSubtype<WTI_Transaction>(WebTestItemType.Wti_Transactiontimer)
        //        .Build());
        //    return settings;
        //}
    }

    //public class WebTestItemConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        return typeof(WebTestItem).IsAssignableFrom(objectType);
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        JObject jo = JObject.Load(reader);

    //        string itemType = (string)jo["objectItemType"];

    //        WebTestItem item;
    //        switch (itemType)
    //        {
    //            case "Wti_Comment":
    //                item = new WTI_Comment();
    //                break;
    //            case "Wti_IncludedWebTestItem":
    //                item = new WTI_IncludedWebTest();
    //                break;
    //            case "Wti_LoopControl":
    //                item = new WTI_LoopControl();
    //                break;
    //            case "Wti_RequestObject":
    //                item = new WTI_Request();
    //                break;
    //            case "Wti_Transactiontimer":
    //                item = new WTI_Transaction();
    //                break;
    //            default:
    //                item = new WTI_Comment();
    //                break;
    //        }

    //        serializer.Populate(jo.CreateReader(), item);
    //        return item;
    //    }

    //    public override bool CanWrite
    //    {
    //        get { return false; }
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {

    //    }
    //}
}
