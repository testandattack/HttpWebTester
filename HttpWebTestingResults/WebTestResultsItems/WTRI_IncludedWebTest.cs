using HttpWebTesting.WebTestItems;
using HttpWebTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_IncludedWebTest : WebTestResultsItem
    {
        public Collection<WebTestResultsItem> webTestResultsItems { get; set; }

        public TimeSpan totalElapsedTime { get; set; }

        public TimeSpan totalIncludedWebTestTime { get; set; }

        public HttpWebTest httpWebTest { get; set; }

        public WTRI_IncludedWebTest(HttpWebTest originalIncludedWebTest)
        {
            objectItemType = WebTestResultItemType.Wtri_LoopControlItem;
            httpWebTest = (HttpWebTest)originalIncludedWebTest;
            webTestItem = null;
        }
    }
}
