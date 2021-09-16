namespace HttpWebTesting.Enums
{
    /// <summary>
    /// This enum describes the type of comparisons available for the control.
    /// </summary>
    public enum ComparisonType
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

    public static class ComparisonTypeExtensions
    {
        public static string AsString(this ComparisonType source)
        {
            switch (source)
            {
                case ComparisonType.Contains:
                    return "contains";
                case ComparisonType.DoesNotContain:
                    return "doesn't contain";
                case ComparisonType.EndsWith:
                    return "ends with";
                case ComparisonType.IsEqual:
                    return "=";
                case ComparisonType.IsGreaterThan:
                    return ">";
                case ComparisonType.IsGreaterThanOrEqual:
                    return ">=";
                case ComparisonType.IsLessThan:
                    return "<";
                case ComparisonType.IsLessThanOrEqual:
                    return "<=";
                case ComparisonType.IsNotEqual:
                    return "!=";
                case ComparisonType.StartsWith:
                    return "starts with";
                default:
                    return "";
            }
        }
    }
}
