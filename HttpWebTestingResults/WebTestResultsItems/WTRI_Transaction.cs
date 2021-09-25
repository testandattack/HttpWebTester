﻿using HttpWebTesting.WebTestItems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_Transaction : WebTestResultsItem
    {

        [JsonProperty(PropertyName = "Transaction Results Items")]
        public WebTestResultsItemCollection webTestResultsItems { get; set; }

        public TimeSpan totalElapsedTime { get; set; }

        public TimeSpan totalTransactionTime { get; set; }

        public WTRI_Transaction(Guid itemGuid)
        {
            objectItemType = WebTestResultItemType.Wtri_TransactionItem;
            webTestItemId = itemGuid;
            webTestResultsItems = new WebTestResultsItemCollection();
        }
    }
}
