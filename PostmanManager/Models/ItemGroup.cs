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
    public class ItemGroup
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
        public string Description { get; set; }

        /// <summary>
        /// Using variables in your Postman requests eliminates 
        /// the need to duplicate requests, which can save a 
        /// lot of time. Variables can be defined, and referenced 
        /// to from any part of a request.
        /// </summary>
        [JsonProperty("variable")]
        public List<Variable> Variables { get; set; }

        /// <summary>
        /// Items are entities which contain an actual HTTP request, 
        /// and sample responses attached to it.
        /// </summary>
        [JsonProperty("item")]
        public List<Item> Items { get; set; }

        /// <summary>
        /// Defines a script associated with an associated event name
        /// </summary>
        [JsonProperty("event")]
        public List<Event> Event { get; set; }

        /// <summary>
        /// Represents authentication helpers provided by Postman.
        /// </summary>
        [JsonProperty("auth")]
        public List<Auth> Auth { get; set; }

        /// <summary>
        /// Set of configurations used to alter the usual behavior of sending the request.
        /// </summary>
        [JsonProperty("protocolProfileBehavior")]
        public object ProtocolProfileBehavior { get; set; }
    }
}
