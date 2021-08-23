using HttpWebTesting.WebTestItems;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JsonSubTypes;
using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using HttpWebTesting;

namespace WebTestItemManager
{
    public static class HttpWebTestSerializer
    {
        public static void SerializeTest(HttpWebTest httpWebTest, string webTestFileName)
        {
            using (StreamWriter sw = new StreamWriter(webTestFileName, false))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;
                //settings.TypeNameHandling = TypeNameHandling.Objects & TypeNameHandling.Arrays;
                sw.Write(JsonConvert.SerializeObject(httpWebTest, Formatting.Indented, settings));
            }
        }

        public static HttpWebTest DeserializeTest(string webTestFileName)
        {
            using (StreamReader sr = new StreamReader(webTestFileName))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Converters = new List<JsonConverter> { new RuleConverter() };
                return JsonConvert.DeserializeObject<HttpWebTest>(sr.ReadToEnd(), settings);
            }
        }
    }
}
