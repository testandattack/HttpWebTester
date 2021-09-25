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
        [JsonProperty(PropertyName = "Loop Results Items")]
        public LoopControlResultsItemCollection loopResultsItems { get; set; }

        public List<string> loopIterations { get; set; }

        public TimeSpan totalElapsedTime { get; set; }

        public TimeSpan totalLoopTime { get; set; }

        public WTRI_LoopControl(Guid itemGuid)
        {
            objectItemType = WebTestResultItemType.Wtri_LoopControlItem;
            webTestItemId = itemGuid;
            loopResultsItems = new LoopControlResultsItemCollection();
            loopIterations = new List<string>();
        }
    }
}
