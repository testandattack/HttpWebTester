using HttpWebTesting.WebTestItems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_LoopControlIteration : WebTestResultsItem
    {
        [JsonProperty(PropertyName = "Loop Results Items")]
        public WebTestResultsItemCollection loopIterationResultsItems { get; set; }

        public string LoopIterationName { get; set; }

        public TimeSpan totalElapsedTime { get; set; }

        public WTRI_LoopControlIteration(Guid itemGuid)
        {
            objectItemType = WebTestResultItemType.Wtri_LoopControlIteration;
            webTestItemId = itemGuid;
            loopIterationResultsItems = new WebTestResultsItemCollection();
        }
    }
}
