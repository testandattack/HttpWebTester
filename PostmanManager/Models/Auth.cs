using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    public class Auth
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AuthType_Enum Type { get; set; }
        
        [JsonProperty("noauth")]
        public object NoAuth { get; set; }

        /// <summary>
        /// The attributes for API Key Authentication.
        /// </summary>
        [JsonProperty("apikey")]
        public List<AuthAttribute> ApiKey { get; set; }

        /// <summary>
        /// The attributes for [AWS Auth](http://docs.aws.amazon.com/AmazonS3/latest/dev/RESTAuthentication.html).
        /// </summary>
        [JsonProperty("awsv4")]
        public List<AuthAttribute> AwsV4 { get; set; }

        /// <summary>
        /// The attributes for [Basic Authentication](https://en.wikipedia.org/wiki/Basic_access_authentication).
        /// </summary>
        [JsonProperty("basic")]
        public List<AuthAttribute> Basic { get; set; }

        /// <summary>
        /// The helper attributes for [Bearer Token Authentication](https://tools.ietf.org/html/rfc6750)
        /// </summary>
        [JsonProperty("bearer")]
        public List<AuthAttribute> Bearer { get; set; }

        /// <summary>
        /// The attributes for [Digest Authentication](https://en.wikipedia.org/wiki/Digest_access_authentication).
        /// </summary>
        [JsonProperty("digest")]
        public List<AuthAttribute> Digest { get; set; }

        /// <summary>
        /// The attributes for [Akamai EdgeGrid Authentication](https://developer.akamai.com/legacy/introduction/Client_Auth.html).
        /// </summary>
        [JsonProperty("edgegrid")]
        public List<AuthAttribute> EdgeGrid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("")]
        public List<AuthAttribute> Hawk { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("")]
        public List<AuthAttribute> Ntlm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("")]
        public List<AuthAttribute> OAuth1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("")]
        public List<AuthAttribute> OAuth2 { get; set; }
    }

    public class AuthAttribute
    {

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
