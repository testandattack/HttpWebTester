﻿using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTestingResults
{
    public class WTRI_SkippedItem : WebTestResultsItem
    {
        public WTRI_SkippedItem(WTI_SkippedItem skippedItem)
        {
            objectItemType = WebTestResultItemType.Wtri_SkippedItem;
            webTestItem = skippedItem as WTI_SkippedItem;
        }
    }
}