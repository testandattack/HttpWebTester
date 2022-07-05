using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    /// <summary>
    /// One of the primary goals of Postman is to organize the development of APIs. 
    /// To this end, it is necessary to be able to group requests together. This 
    /// can be achived using 'Folders'. A folder just is an ordered set of requests.
    /// </summary>
    [JsonObject(Title = "item")]
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("variable")]
        public List<Variable> Variables { get; set; }

        [JsonProperty("event")]
        public List<Event> Events { get; set; }

        [JsonProperty("request"), JsonRequired]
        public Request Request { get; set; }

        [JsonProperty("response")]
        public List<Response> Responses { get; set; }

        [JsonProperty("protocolProfileBehavior")]
        public object ProtocolProfileBehavior { get; set; }


    }
}
