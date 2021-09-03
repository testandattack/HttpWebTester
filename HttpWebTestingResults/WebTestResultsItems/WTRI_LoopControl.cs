using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_LoopControl : WebTestResultsItem
    {
        public Dictionary<string, Collection<WebTestResultsItem>> webTestResultsItems { get; set; }

        public TimeSpan totalElapsedTime { get; set; }

        public TimeSpan totalTransactionTime { get; set; }

        public WTRI_LoopControl(WTI_LoopControl originalLoop)
        {
            objectItemType = WebTestResultItemType.Wtri_LoopControlItem;
            webTestItem = (WTI_LoopControl)originalLoop;
            webTestResultsItems = new Dictionary<string, Collection<WebTestResultsItem>>();
        }
    }
}
