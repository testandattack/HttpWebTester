using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_SkippedItem : WebTestResultsItem
    {
        public WTRI_SkippedItem()
        {
            objectItemType = WebTestResultItemType.Wtri_SkippedItem;
            webTestItemId = new Guid();
            ItemExecutionSkipped = true;
        }

        public WTRI_SkippedItem(WTI_SkippedItem skippedItem)
        {
            objectItemType = WebTestResultItemType.Wtri_SkippedItem;
            webTestItemId = skippedItem.guid;
            ItemExecutionSkipped = true;
        }
    }
}
