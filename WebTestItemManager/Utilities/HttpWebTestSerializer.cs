using HttpWebTesting;
using Newtonsoft.Json;
using System.IO;

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
                sw.Write(JsonConvert.SerializeObject(httpWebTest, Formatting.Indented, settings));
            }
        }

        public static HttpWebTest DeserializeTest(string webTestFileName)
        {
            using (StreamReader sr = new StreamReader(webTestFileName))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;
                return JsonConvert.DeserializeObject<HttpWebTest>(sr.ReadToEnd(), settings);
            }
        }
    }
}
