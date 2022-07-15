using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BodyType_Enum
    {
        raw,
        urlencoded,
        formdata,
        file,
        graphql

    }
}
