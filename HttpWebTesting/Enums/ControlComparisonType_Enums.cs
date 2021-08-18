﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTesting.Enums
{
    /// <summary>
    /// This enum describes the type of comparisons available for the control.
    /// </summary>
    public enum ControlComparisonType
    {
        IsLoop = 0,
        IsEqual = 1,
        IsLessThan = 2,
        IsLessThanOrEqual = 3,
        IsGreaterThan = 4,
        IsGreaterThanOrEqual = 5,
        IsNotEqual = 6,
        Contains = 7,
        StartsWith = 8,
        DoesNotContain = 9,
        EndsWith = 10
    };

}
