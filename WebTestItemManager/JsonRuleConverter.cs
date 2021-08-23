using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using HttpWebTesting.Rules;
using Newtonsoft.Json.Linq;
using WebTestRules;

namespace WebTestItemManager
{

    public class RuleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(BaseRule).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            string type = (string)obj["$type"];
            BaseRule baseRule;

            if (type.Contains(nameof(ExtractString)))
                baseRule = new ExtractString();
            else if (type.Contains(nameof(ValidateStatusCode)))
                baseRule = new ValidateStatusCode();
            else if (type.Contains(nameof(ValidateResponseText)))
                baseRule = new ValidateResponseText();
            else
                throw new WebTestDeserializerException($"The Deserializer found an unknown rule type in the RuleConverter class. The type found was {type}");

            serializer.Populate(obj.CreateReader(), baseRule);

            return baseRule;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
