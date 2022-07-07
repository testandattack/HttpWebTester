using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    /// <summary>
    /// A request represents an HTTP request. If a string, the string is assumed to be the 
    /// request URL and the method is assumed to be 'GET'.
    /// </summary>
    [JsonObject(Title = "request")]
    [JsonConverter(typeof(PostmanRequest_JsonConverter))]
    public class Request
    {
        /// <summary>
        /// This string holds the value of a Postman Request object that was stored as a string value.
        /// If the Request is an object, then this string will be empty.
        /// </summary>
        [JsonIgnore]
        public string RawRequest { get; set; }

        /// <summary>
        /// If object, contains the complete broken-down URL for this request. If 
        /// string, contains the literal request URL.
        /// </summary>
        [JsonProperty("url")]
        public Url Url { get; set; }

        /// <summary>
        /// Represents authentication helpers provided by Postman
        /// </summary>
        [JsonProperty("auth")]
        public Auth Auth { get; set; }

        /// <summary>
        /// Using the Proxy, you can configure your custom proxy into the postman for 
        /// particular url match
        /// </summary>
        [JsonProperty("proxy")]
        public Proxy Proxy { get; set; }

        /// <summary>
        /// A representation of an ssl certificate
        /// </summary>
        [JsonProperty("certificate")]
        public Certificate Certificate { get; set; }

        /// <summary>
        /// The Standard HTTP method associated with this request.
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// The description of this request.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A representation for a list of headers.
        /// </summary>
        [JsonProperty("header")]
        public List<Header> Headers { get; set; }

        /// <summary>
        /// This field contains the data usually contained in the request body.
        /// </summary>
        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public Body Body { get; set; }

        public void SetMethod(string method)
        {
            Method = method;
        }

        public void SetMethod(RequestMethod_Enum strEnum)
        {
            Method = strEnum.ToString();
        }
    }
}
