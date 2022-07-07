using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    /// <summary>
    /// Items are entities which contain an actual HTTP request, and sample responses attached to it.
    /// </summary>
    [JsonObject(Title = "item")]
    [JsonConverter(typeof(PostmanItem_JsonConverter))]
    public class ItemGroup : ItemCollection
    {
        /// <summary>
        /// A human readable identifier for the current item.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("description")]
        public Description Description { get; set; }

        /// <summary>
        /// Using variables in your Postman requests eliminates 
        /// the need to duplicate requests, which can save a 
        /// lot of time. Variables can be defined, and referenced 
        /// to from any part of a request.
        /// </summary>
        [JsonProperty("variable")]
        public List<Variable> Variables { get; set; }

        /// <summary>
        /// Defines a script associated with an associated event name
        /// </summary>
        [JsonProperty("event")]
        public List<Event> Event { get; set; }

        /// <summary>
        /// Set of configurations used to alter the usual behavior of sending the request.
        /// </summary>
        [JsonProperty("protocolProfileBehavior")]
        public object ProtocolProfileBehavior { get; set; }

        /// <summary>
        /// Items are entities which contain an actual HTTP request, 
        /// and sample responses attached to it.
        /// </summary>
        [JsonProperty("item")]
        public List<ItemCollection> Items { get; set; }

        /// <summary>
        /// Represents authentication helpers provided by Postman.
        /// </summary>
        [JsonProperty("auth", NullValueHandling = NullValueHandling.Ignore)]
        public Auth Auth { get; set; }
    }
}
