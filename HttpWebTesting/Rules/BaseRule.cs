using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;

namespace HttpWebTesting.Rules
{
    [JsonConverter(typeof(JsonSubtypes), "baseRuleType")]
    [JsonSubtypes.KnownSubType(typeof(PreWebTestRule), BaseRuleType.PreTest)]
    [JsonSubtypes.KnownSubType(typeof(PreRequestRule), BaseRuleType.PreRequest)]
    [JsonSubtypes.KnownSubType(typeof(ValidationRule), BaseRuleType.Validation)]
    [JsonSubtypes.KnownSubType(typeof(ExtractionRule), BaseRuleType.Extraction)]
    [JsonSubtypes.KnownSubType(typeof(PostRequestRule), BaseRuleType.PostRequest)]
    [JsonSubtypes.KnownSubType(typeof(PostWebTestRule), BaseRuleType.PostTest)]
    public abstract class BaseRule : ICloneable
    {
        /// <summary>
        /// The name of the rule
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A brief description of the rule
        /// </summary>
        public string Description { get; set; }
        
        //[JsonProperty(PropertyName = "$type")]
        protected Type type { get; set; }

        /// <summary>
        /// the <see cref="Enums.RuleType">RuleType</see> of this rule
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public RuleType RuleType { get; set; }

        /// <summary>
        /// A collection of properties for this rule
        /// </summary>
        public PropertyCollection Properties { get; set; }

        /// <summary>
        /// The <see cref="RuleResult">result</see> of the execution of the rule
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public RuleResult RuleResult { get; set; }

        /// <summary>
        /// If this is set to false, this item is ignored during playback. Default is TRUE
        /// </summary>
        public bool Enabled = true;

        protected BaseRuleType baseRuleType { get; set; }

        #region -- Constructors -----
        protected BaseRule()
        {
            Name = string.Empty;
            Description = string.Empty;
            Properties = new PropertyCollection();
            RuleResult = RuleResult.NotEvaluatedYet;
        }

        protected BaseRule(BaseRule copy)
        {
            if(copy.Properties != null)
            {
                this.Properties = (PropertyCollection)copy.Properties.Clone();
            }

            this.Name = copy.Name;
            this.Description = copy.Description;
            this.type = copy.type;
            this.RuleResult = copy.RuleResult;
            this.Enabled = copy.Enabled;
        }

        protected BaseRule(Type type) : this()
        {
            this.type = type;
        }
        #endregion

        public abstract object Clone();
    }
}
