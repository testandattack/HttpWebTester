using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_Comment : WebTestResultsItem
    {
        public WTRI_Comment(Guid itemGuid)
        {
            objectItemType = WebTestResultItemType.Wtri_CommentItem;
            webTestItemId = itemGuid;
        }
    }
}
