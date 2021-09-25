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
        public WebTestResultsItemCollection webTestResultsItems { get; set; }

        public TimeSpan totalElapsedTime { get; set; }

        public TimeSpan totalIncludedWebTestTime { get; set; }

        public HttpWebTest httpWebTest { get; set; }

        public WTRI_IncludedWebTest(Guid itemGuid)
        {
            objectItemType = WebTestResultItemType.Wtri_IncludedWebTestItem;
            webTestItemId = itemGuid;
            httpWebTest = null;
            webTestResultsItems = new WebTestResultsItemCollection();
        }
    }
}
