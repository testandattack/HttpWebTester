using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    [JsonObject(Title = "item")]
    [JsonConverter(typeof(PostmanItem_JsonConverter))]
    public abstract class ItemCollection
    {
    }
}
