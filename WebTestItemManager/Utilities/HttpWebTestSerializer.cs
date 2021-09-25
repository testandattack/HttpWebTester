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
                httpWebTest.WorkingDirectoryLocation = webTestFileName.Substring(0, webTestFileName.LastIndexOf("\\"));
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
                HttpWebTest webTest;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;
                settings.Converters.Add(new StringContentConverter());
                settings.Converters.Add(new HttpContentConverter());
                webTest = JsonConvert.DeserializeObject<HttpWebTest>(sr.ReadToEnd(), settings);
                webTest.WorkingDirectoryLocation = webTestFileName.Substring(0, webTestFileName.LastIndexOf("\\"));
                return webTest;
            }
        }

        public static HttpWebTest DeserializeTestFromString(string serializedTest)
        {
                HttpWebTest webTest;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;
                settings.Converters.Add(new StringContentConverter());
                settings.Converters.Add(new HttpContentConverter());
                webTest = JsonConvert.DeserializeObject<HttpWebTest>(serializedTest, settings);
                webTest.WorkingDirectoryLocation = serializedTest.Substring(0, serializedTest.LastIndexOf("\\"));
                return webTest;
        }
    }
}
