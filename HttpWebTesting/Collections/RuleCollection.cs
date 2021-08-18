using HttpWebTesting.Rules;

namespace HttpWebTesting.Collections
{
    public class RuleCollection : BaseCollection<BaseRule>
    {
        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }
}
