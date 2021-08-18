using System;
using HttpWebTesting.Enums;
using HttpWebTesting.Collections;

namespace HttpWebTesting.Rules
{
    public abstract class BaseRule : ICloneable
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public Type type { get; set; }

        public RuleTypes_Enums RuleType { get; set; }
        public bool ExecutionBeforeDependentRequests { get; set; }
        public PropertyCollection Properties { get; set; }

        protected BaseRule()
        {
            Name = string.Empty;
            Description = string.Empty;
            ExecutionBeforeDependentRequests = true;
            Properties = new PropertyCollection();
        }

        protected BaseRule(BaseRule copy)
        {
            if(copy.Properties != null)
            {
                this.Properties = (PropertyCollection)copy.Properties.Clone();
            }

            this.Name = copy.Name;
            this.Description = copy.Description;
            this.ExecutionBeforeDependentRequests = copy.ExecutionBeforeDependentRequests;
            this.type = copy.type;
        }

        protected BaseRule(Type type) : this()
        {
            this.type = type;
        }

        public abstract object Clone();
    }
}
