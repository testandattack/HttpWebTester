using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using PostmanManager.Models;

namespace PostmanManager
{

    [JsonObject(Title = "properties")]
    public class PostmanCollection
    {
        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("item")]
        public List<ItemCollection> Items { get; set; }

        [JsonProperty("event")]
        public List<Event> Events { get; set; }

        [JsonProperty("variable")]
        public List<Variable> Variables { get; set; }

        [JsonProperty("auth", NullValueHandling = NullValueHandling.Ignore)]
        public Auth Auth { get; set; }

        [JsonProperty("protocolProfileBehavior")]
        public object ProtocolProfileBehavior { get; set; }
    }
}
