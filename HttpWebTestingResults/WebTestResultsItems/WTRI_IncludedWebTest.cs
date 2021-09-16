using HttpWebTesting.WebTestItems;
using HttpWebTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;

namespace HttpWebTestingResults
{
    public class WTRI_IncludedWebTest : WebTestResultsItem
    {
        [JsonProperty(PropertyName = "IncludedWebtestResultsItems")]
        public Collection<WebTestResultsItem> webTestResultsItems { get; set; }

        public TimeSpan totalElapsedTime { get; set; }

        public TimeSpan totalIncludedWebTestTime { get; set; }

        public HttpWebTest httpWebTest { get; set; }

        public WTRI_IncludedWebTest(HttpWebTest originalIncludedWebTest)
        {
            objectItemType = WebTestResultItemType.Wtri_LoopControlItem;
            httpWebTest = (HttpWebTest)originalIncludedWebTest;
            webTestItemId = originalIncludedWebTest.Id;
        }
    }
}
