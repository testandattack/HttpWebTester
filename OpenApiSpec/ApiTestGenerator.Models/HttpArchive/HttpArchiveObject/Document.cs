using System;
using System.IO;
using Newtonsoft.Json;

namespace Automatonic.HttpArchive
{
    /// <summary>
    /// This object represents the document wrapper needed to load the log file.
    /// </summary>
    [JsonObject]
    public class Document
    {
        /// <summary>
        /// Version number of the format. If empty, string "1.1" is assumed by default.
        /// </summary>
        [JsonProperty(PropertyName = "log")]
        public Log Log { get; set; }
    }

    public class LoadArchive
    {
        public LoadArchive() { }

        public void LoadLog()
        {
            string logFileToLoad = "GTC_Basic.har";
            StreamReader re = new StreamReader(logFileToLoad);
            JsonTextReader reader = new JsonTextReader(re);

            JsonSerializer se = new JsonSerializer();
            object parsedData = se.Deserialize(reader);
       }

    }
}
