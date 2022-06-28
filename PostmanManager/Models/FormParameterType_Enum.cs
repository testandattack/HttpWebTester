using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FormParameterType_Enum
    {
        text,
        file
    }
}
