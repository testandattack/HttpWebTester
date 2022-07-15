using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using PostmanManager.Models;

namespace PostmanManager
{
    /// <summary>
    /// The root item for postman collections
    /// <remarks>
    /// FROM [geoffgr]. The summary documentation is directly from the postman 
    /// schema listed below:
    /// <code>
    /// "$schema": "http://json-schema.org/draft-04/schema#",
    /// "id": "https://schema.getpostman.com/json/collection/v2.1.0/",
    /// </code>
    /// <para>The C# objects created in this package are not guaranteed to be 
    /// identical to the objects in postman, but they should always serialize to 
    /// a json object that can be imported into Postman.</para>
    /// </remarks>
    /// </summary>
    public class PostmanCollection
    {
        /// <summary>
        /// Detailed description of the info block
        /// </summary>
        [JsonProperty("info")]
        public Info Info { get; set; }

        /// <summary>
        /// Items are the basic unit for a Postman collection. 
        /// You can think of them as corresponding to a single 
        /// API endpoint. Each Item has one request and may have 
        /// multiple API responses associated with it.
        /// </summary>
        [JsonProperty("item")]
        public List<ItemCollection> Items { get; set; }

        /// <summary>
        /// Postman allows you to configure scripts to run when specific events 
        /// occur. These scripts are stored here, and can be referenced in the 
        /// collection by their ID.
        /// </summary>
        [JsonProperty("event")]
        public List<Event> Events { get; set; }

        /// <summary>
        /// Collection variables allow you to define a set of variables, 
        /// that are a *part of the collection*, as opposed to environments, 
        /// which are separate entities.\n*Note: Collection variables must 
        /// not contain any sensitive information.*
        /// </summary>
        [JsonProperty("variable")]
        public List<Variable> Variables { get; set; }

        /// <summary>
        /// Represents authentication helpers provided by Postman
        /// </summary>
        [JsonProperty("auth", NullValueHandling = NullValueHandling.Ignore)]
        public Auth Auth { get; set; }

        /// <summary>
        /// Set of configurations used to alter the usual behavior of sending the request.
        /// </summary>
        [JsonProperty("protocolProfileBehavior")]
        public object ProtocolProfileBehavior { get; set; }
    }
}
