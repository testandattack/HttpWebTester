using HttpWebTesting;
using Newtonsoft.Json;
using System.IO;
using WebTestItemManager.Utilities;

namespace WebTestItemManager
{
    public static class HttpWebTestSerializer
    {
        public static void SerializeAndSaveTest(HttpWebTest httpWebTest, string webTestFileName)
        {
            using (StreamWriter sw = new StreamWriter(webTestFileName, false))
            {
                
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;
                settings.Converters.Add(new StringContentConverter());
                sw.Write(JsonConvert.SerializeObject(httpWebTest, Formatting.Indented, settings));
            }
        }

        public static string SerializeTest(HttpWebTest httpWebTest)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            settings.Converters.Add(new StringContentConverter());
            return JsonConvert.SerializeObject(httpWebTest, Formatting.Indented, settings);
        }

        public static HttpWebTest DeserializeTest(string webTestFileName)
        {
            using (StreamReader sr = new StreamReader(webTestFileName))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;
                settings.Converters.Add(new StringContentConverter());
                settings.Converters.Add(new HttpContentConverter());
                return JsonConvert.DeserializeObject<HttpWebTest>(sr.ReadToEnd(), settings);
            }
        }
    }
}
