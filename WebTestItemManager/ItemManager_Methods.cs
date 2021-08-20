using HttpWebTesting;
using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;


namespace WebTestItemManager
{
    public partial class ItemManager
    {

        #region -- Get Actual Item methods ---------------------

        private WebTestItem GetActualItem(string sTreeLoc, WebTestItemCollection wtic)
        {
            IEnumerable<int> indexes = sTreeLoc.Replace("Root.", "").Split('.').Select(int.Parse);
            return GetActualItem(indexes, wtic);
        }

        private WebTestItem GetActualItem(IEnumerable<int> indexes, WebTestItemCollection wtic)
        {
            if (indexes.Count() == 1)
                return wtic[indexes.ElementAt(0)];

            return GetActualItem(indexes.Skip(1), GetChildItems(wtic[indexes.ElementAt(0)]));
        }

        public WebTestItemCollection GetChildItems(WebTestItem webTestItem)
        {
            if (webTestItem.objectItemType == WebTestItemType.Wti_IncludedWebTestItem)
            {
                return ((WTI_IncludedWebTest)webTestItem).HttpWebTest.WebTestItems;
            }
            else if (webTestItem.objectItemType == WebTestItemType.Wti_LoopControl)
            {
                return ((WTI_LoopControl)webTestItem).webTestItems;
            }
            else if (webTestItem.objectItemType == WebTestItemType.Wti_Transactiontimer)
            {
                return ((WTI_Transaction)webTestItem).webTestItems;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
