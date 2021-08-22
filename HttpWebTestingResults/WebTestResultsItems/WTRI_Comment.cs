using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_Comment : WebTestResultsItem
    {
        public WTRI_Comment(WTI_Comment originalComment)
        {
            objectItemType = WebTestResultItemType.Wtri_CommentItem;
            webTestItem = (WTI_Comment)originalComment;
        }
    }
}
