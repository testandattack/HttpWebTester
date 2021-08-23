using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using JsonSubTypes;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace HttpWebTesting.Rules
{
    [JsonConverter(typeof(JsonSubtypes), "baseRuleType")]
    [JsonSubtypes.KnownSubType(typeof(PreWebTestRule), BaseRuleTypes.PreTest)]
    [JsonSubtypes.KnownSubType(typeof(PreRequestRule), BaseRuleTypes.PreRequest)]
    [JsonSubtypes.KnownSubType(typeof(ValidationRule), BaseRuleTypes.Validation)]
    [JsonSubtypes.KnownSubType(typeof(ExtractionRule), BaseRuleTypes.Extraction)]
    [JsonSubtypes.KnownSubType(typeof(PostRequestRule), BaseRuleTypes.PostRequest)]
    [JsonSubtypes.KnownSubType(typeof(PostWebTestRule), BaseRuleTypes.PostTest)]
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
        /// the <see cref="RuleTypes_Enums">RuleType</see> of this rule
        /// </summary>
        public RuleTypes_Enums RuleType { get; set; }

        /// <summary>
        /// A collection of properties for this rule
        /// </summary>
        public PropertyCollection Properties { get; set; }

        /// <summary>
        /// The <see cref="RuleResult">result</see> of the execution of the rule
        /// </summary>
        public RuleResult RuleResult { get; set; }

        /// <summary>
        /// If this is set to false, this item is ignored during playback. Default is TRUE
        /// </summary>
        public bool Enabled = true;


        protected BaseRuleTypes baseRuleType { get; set; }

        public string TypeAsString { get; set; }

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
        }

        protected BaseRule(Type type) : this()
        {
            this.type = type;
        }
        #endregion

        public abstract object Clone();
    }
}
