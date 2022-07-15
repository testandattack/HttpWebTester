using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PostmanManager.Models
{
    public enum ItemType_Enum
    {
        [JsonProperty("string")]
        String = 1,

        [JsonProperty("boolean")]
        Boolean = 2,
        
        [JsonProperty("any")]
        Any = 3,
        
        [JsonProperty("number")]
        Number = 4

    }
}
