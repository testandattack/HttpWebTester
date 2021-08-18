using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTesting.Enums
{
    /// <summary>
    /// Lists the location where a given rule should be executed
    /// </summary>
    public enum RuleResult_Enums
    {
        /// <summary>
        /// Indicates that this rule's execution passed.
        /// </summary>
        Passed = 1,

        /// <summary>
        /// Indicates that this rule's execution failed.
        /// </summary>
        Failed = 2,

        /// <summary>
        /// Indicates that this rule's execution state was ignored.
        /// </summary>
        Ignored = 3,

        /// <summary>
        /// Indicates that the rule was aborted due to an exception.
        /// </summary>
        Aborted = 4
    };
}
