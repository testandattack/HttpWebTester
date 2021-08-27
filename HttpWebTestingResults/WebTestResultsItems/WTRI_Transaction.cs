using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_Transaction : WebTestResultsItem
    {
        public Collection<WebTestResultsItem> webTestResultsItems { get; set; }

        public TimeSpan totalElapsedTime { get; set; }

        public TimeSpan totalTransactionTime { get; set; }

        public WTRI_Transaction(WTI_Transaction originalComment)
        {
            objectItemType = WebTestResultItemType.Wtri_TransactionItem;
            webTestItem = (WTI_Transaction)originalComment;
        }
    }
}
