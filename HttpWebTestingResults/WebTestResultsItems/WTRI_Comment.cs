using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_Comment : WebTestResultsItem
    {
        public string CommentText { get; set; }

        public WTRI_Comment(Guid itemGuid)
        {
            objectItemType = WebTestResultItemType.Wtri_CommentItem;
            webTestItemId = itemGuid;
        }
        public WTRI_Comment(WTI_Comment comment)
        {
            objectItemType = WebTestResultItemType.Wtri_CommentItem;
            webTestItemId = comment.guid;
            CommentText = comment.CommentText;
        }
    }
}
