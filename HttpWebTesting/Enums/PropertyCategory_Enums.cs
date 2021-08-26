using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTesting.Enums
{
    public enum PropertyCategory
    {
        General = 1,

        Behavior = 2,

        CoreSettings = 3,

        Advanced = 4
    }

    public static class PropertyCategories
    {
        public const string General = "General";
        public const string Behavior = "Behavior";
        public const string CoreSettings = "CoreSettings";
        public const string Advanced = "Advanced";
    }
}
