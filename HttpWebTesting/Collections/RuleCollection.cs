using HttpWebTesting.Enums;
using HttpWebTesting.Rules;

namespace HttpWebTesting.Collections
{
    public class RuleCollection : BaseCollection<BaseRule>
    {
        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public RuleCollection GetRulesOfType(RuleTypes_Enums ruleType)
        {
            RuleCollection rules = new RuleCollection();
            foreach(var rule in this.Items)
            {
                if (rule.RuleType == ruleType)
                {
                    rules.Add(rule);
                }
            }
            return rules;
        }

        public bool ContainsFailedRuleResult(bool includeAborted = false)
        {
            foreach (var rule in this.Items)
            {
                if (rule.RuleResult == RuleResult.Failed)
                    return true;
                if(includeAborted == true && rule.RuleResult == RuleResult.Aborted)
                    return true;
            }
            return false;
        }
    }
}
