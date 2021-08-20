using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestItemManager
{
    [Flags]
    public enum WTItemType
    {
        None = 0,
        WebTestRequest = 1,
        TransactionTimer = 2,
        WebTestLoop = 4,
        WebTestCondition = 8,
        Comment = 16,
        IncludedWebTest = 32,
        SharePointInformation = 64,
        UnknownType = 128
    };
}
