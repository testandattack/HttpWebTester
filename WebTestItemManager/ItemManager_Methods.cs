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
        public WebTestItem GetActualItem(string sTreeLoc, WebTestItemCollection wtic)
        {
            IEnumerable<int> indexes = sTreeLoc.Replace("Root.", "").Split('.').Select(int.Parse);
            return GetActualItem(indexes, wtic);
        }

        public WebTestItem GetActualItem(IEnumerable<int> indexes, WebTestItemCollection wtic)
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

        #region -- Retrieve item info------------------------------------------
        /// <summary>
        /// returns the location in the tree structure of the requested element.   The format is Root.X.Y.Z...
        /// </summary>
        /// <param name="itemId">The unique Id of the item in the collection</param>
        /// <returns>string - the location of the tree heirarchy for the item</returns>
        public string GetItemTreeLocation(int itemId)
        {
            return _webTestItemMetaData[itemId].sTreeLoc;
        }

        /// <summary>
        /// returns the location in the tree structure of the requested element.   The format is Root.X.Y.Z...
        /// </summary>
        /// <param name="sTreeLoc">The string containing the tree location heirarchy of the item</param>
        /// <returns></returns>
        public int GetItemTreeLocation(string sLoc)
        {
            for (int x = 1; x <= _webTestItemMetaData.Count; x++)
            {
                if (_webTestItemMetaData[x].sTreeLoc == sLoc)
                    return x;
            }
            return 0;
        }

        /// <summary>
        /// returns the WebTestItemCollection class type of the item
        /// </summary>
        /// <param name="itemId">The unique Id of the item in the collection</param>
        /// <returns>string</returns>
        public WebTestItemType GetItemTreeType(int itemId)
        {
            return _webTestItemMetaData[itemId].wtit;
        }
        public WebTestItemType GetItemTreeType(string sLoc)
        {
            return _webTestItemMetaData[GetItemTreeLocation(sLoc)].wtit;
        }

        public WTItemSubType GetItemTreeSubType(int itemId)
        {
            return _webTestItemMetaData[itemId].wtist;
        }
        public WTItemSubType GetItemTreeSubType(string sLoc)
        {
            return _webTestItemMetaData[GetItemTreeLocation(sLoc)].wtist;
        }
        #endregion
    }
}
