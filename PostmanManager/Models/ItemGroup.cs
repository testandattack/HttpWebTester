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
    public class ItemGroup : ItemCollection
    {
        /// <summary>
        /// Items are entities which contain an actual HTTP request, 
        /// and sample responses attached to it.
        /// </summary>
        [JsonProperty("item")]
        public List<ItemCollection> Items { get; set; }

        /// <summary>
        /// Represents authentication helpers provided by Postman.
        /// </summary>
        [JsonProperty("auth")]
        public List<Auth> Auth { get; set; }
    }
}
