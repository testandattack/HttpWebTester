using HttpWebTesting.WebTestItems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_LoopControl : WebTestResultsItem
    {
        [JsonProperty(PropertyName = "LoopResultsItems")]
        public Dictionary<string, Collection<WebTestResultsItem>> webTestResultsItems { get; set; }

        public TimeSpan totalElapsedTime { get; set; }

        public TimeSpan totalLoopTime { get; set; }

        public WTRI_LoopControl(WTI_LoopControl originalLoop)
        {
            objectItemType = WebTestResultItemType.Wtri_LoopControlItem;
            webTestItemId = originalLoop.guid;
            webTestResultsItems = new Dictionary<string, Collection<WebTestResultsItem>>();
        }
    }
}
