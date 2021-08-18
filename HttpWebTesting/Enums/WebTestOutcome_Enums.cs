using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTesting.Enums
{
    public enum WebTestOutcome
    {
        Passed = 1,
        Failed = 2,
        StoppedOnError = 3,
        Aborted = 4
    }
}
