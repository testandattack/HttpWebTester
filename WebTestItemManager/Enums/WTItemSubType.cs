using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestItemManager
{
    [Flags]
    public enum WTItemSubType
    {
        None = 0,
        WebTestRequestwithString = 1,
        WebTestRequestPostWithNoBody = 2,
        WebTestRequestwithByteArrayBody = 4,
        WebTestRequestwithFormUrlEncodedContent = 8,
        WebTestRequestwithMultiPartContent = 16,
        WebTestRequestwithNoBody = 32,
        CommentBlank = 64,      // length < 2
        CommentUseCase = 128,    // "@@ "
        CommentHeader = 256,     // "// "
        CommentWarning = 512,    // "     !! "
        CommentDivider = 1024,    // "-----"
        CommentOther = 2048,      // everything else
        NoSubType = 4096,
        WebTestRequestwithQueryString = 8192, // used for searching
        WebTestRequestwithHeaders = 16384      // used for searching
    };
}
