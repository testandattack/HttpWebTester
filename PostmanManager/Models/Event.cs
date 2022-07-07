using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    [JsonObject(Title = "description", ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Event
    {

        /// <summary>
        /// A unique identifier for the enclosing event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Can be set to `test` or `prerequest` for test scripts or pre-request scripts respectively.
        /// </summary>
        [JsonProperty("listen"), JsonRequired]
        public string Listen { get; set; }

        /// <summary>
        /// "A script is a snippet of Javascript code that can be used to to perform setup or teardown operations on a particular response.
        /// </summary>
        [JsonProperty("script")]
        public Script Script { get; set; }

        /// <summary>
        /// Indicates whether the event is disabled. If absent, the event is assumed to be enabled.
        /// </summary>
        [JsonProperty("disabled")]
        public string Disabled { get; set; }
    }
}
