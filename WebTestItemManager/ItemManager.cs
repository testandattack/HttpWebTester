using HttpWebTesting;
using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;

namespace WebTestItemManager
{
    public partial class ItemManager
    {
        #region -- Properties -----
        public HttpWebTest HttpWebTest { get; private set; }

        public Dictionary<int, WebTestItemMetaData> _webTestItemMetaData;
        private int _itemId = 0;
        #endregion

        #region -- Constructors -----
        public ItemManager() 
        {
            HttpWebTest = new HttpWebTest();
        }

        public ItemManager(HttpWebTest webTest)
        {
            HttpWebTest = webTest;
            _webTestItemMetaData = new Dictionary<int, WebTestItemMetaData>();
            BuildWebTestItemMetaData();
        }
        #endregion

        public void BuildWebTestItemMetaData()
        {
            _webTestItemMetaData.Clear();
            _itemId = 0;
            RecurseTheWebTestItemCollection(this.HttpWebTest.WebTestItems, "Root", 0);
        }

        #region -- BuildWebTestItemMetaData Methods -----
        private void RecurseTheWebTestItemCollection(WebTestItemCollection items, string sTreeLoc, int iDepth)
        {
            for (int nIndex = 0; nIndex < items.Count; nIndex++)
            {
                WebTestItemMetaData wtii = new WebTestItemMetaData();
                wtii.sTreeLoc = sTreeLoc + "." + nIndex.ToString(CultureInfo.InvariantCulture);
                wtii.iTreeDepth = iDepth;
                wtii.wtist = WTItemSubType.NoSubType;

                if (items[nIndex] is WTI_Request)
                {
                    ParseRequest(items, nIndex, wtii);
                }
                else if (items[nIndex] is WTI_Comment)
                {
                    ParseComment(items, nIndex, wtii);
                }
                else if (items[nIndex] is WTI_Transaction)
                {
                    ParseTransaction(items, sTreeLoc, iDepth, nIndex, wtii);
                }
                else if (items[nIndex] is WTI_LoopControl)
                {
                    ParseLoop(items, sTreeLoc, iDepth, nIndex, wtii);
                }
                else if (items[nIndex] is WTI_IncludedWebTest)
                {
                    ParseIncludedWebTest(items, nIndex, wtii);
                }
                else
                {
                    wtii.wtit = WebTestItemType.Wti_Unknown;
                    _webTestItemMetaData.Add(_itemId++, wtii);
                }
            }

            return;
        }

        private void ParseRequest(WebTestItemCollection items, int nIndex, WebTestItemMetaData wtii)
        {
            WTI_Request wtr = (WTI_Request)items[nIndex];
            wtii.wtit = WebTestItemType.Wti_RequestObject;
            wtii.Uri = wtr.RequestUri;

            //--- Get Rule Counts
            //wtii.extractionRuleCount = wtr.ExtractionRuleReferences.Count;
            //wtii.validationRuleCount = wtr.ValidationRuleReferences.Count;
            //wtii.requestPluginCount = wtr.WebTestRequestPluginReferences.Count;
            //wtii.queryStringCount = wtr.QueryStringParameters.Count;

            //GetHeaderHiddenReferences(wtr.Headers, ref wtii);
            //GetQueryStringHiddenReferences(wtr.QueryStringParameters, ref wtii);
            //GetHiddenExtractionReferencesInRequest(wtr, ref wtii);

            #region === Request Body dissection ==========
            if (wtr.Content == null)
            {
                wtii.wtist = WTItemSubType.WebTestRequestwithNoBody;
                _webTestItemMetaData.Add(_itemId++, wtii);
            }
            else if (wtr.Content is StringContent)
            {
                wtii.wtist = WTItemSubType.WebTestRequestwithString;
                _webTestItemMetaData.Add(_itemId++, wtii);
            }
            else if (wtr.Content is MultipartFormDataContent)
            {
                wtii.wtist = WTItemSubType.WebTestRequestwithMultiPartContent;
                _webTestItemMetaData.Add(_itemId++, wtii);
            }
            else if (wtr.Content is ByteArrayContent)
            {
                wtii.wtist = WTItemSubType.WebTestRequestwithByteArrayBody;
                _webTestItemMetaData.Add(_itemId++, wtii);
            }
            else
            {
                //Unknown type
                wtii.wtit = WebTestItemType.Wti_Unknown;
                _webTestItemMetaData.Add(_itemId++, wtii);
            }
            #endregion
        }

        private void ParseComment(WebTestItemCollection items, int nIndex, WebTestItemMetaData wtii)
        {
            wtii.wtit = WebTestItemType.Wti_Comment;

            WTI_Comment cmt = new WTI_Comment();
            cmt = items[nIndex] as WTI_Comment;
            if (cmt.CommentText.Length < 2)
                wtii.wtist = WTItemSubType.CommentBlank;
            //else if (cmt.CommentText.Length > 3 && cmt.CommentText.Substring(0, 3) == "@@ ")
            //    wtii.wtist = WTItemSubType.CommentUseCase;
            //else if (cmt.CommentText.Length > 3 && cmt.CommentText.Substring(0, 3) == "// ")
            //    wtii.wtist = WTItemSubType.CommentHeader;
            //else if (cmt.CommentText.Length > 8 && cmt.CommentText.Substring(0, 8) == "     !! ")
            //    wtii.wtist = WTItemSubType.CommentWarning;
            //else if (cmt.CommentText.Length > 4 && cmt.CommentText.Substring(0, 4) == "----")
            //    wtii.wtist = WTItemSubType.CommentDivider;
            else wtii.wtist = WTItemSubType.CommentOther;

            _webTestItemMetaData.Add(_itemId++, wtii);
        }

        private void ParseTransaction(WebTestItemCollection items, string sTreeLoc, int iDepth, int nIndex, WebTestItemMetaData wtii)
        {
            wtii.wtit = WebTestItemType.Wti_Transactiontimer;
            _webTestItemMetaData.Add(_itemId++, wtii);
            WTI_Transaction transaction = items[nIndex] as WTI_Transaction;
            RecurseTheWebTestItemCollection(transaction.webTestItems, sTreeLoc + "." + nIndex.ToString(CultureInfo.InvariantCulture), iDepth + 1);
        }

        private void ParseLoop(WebTestItemCollection items, string sTreeLoc, int iDepth, int nIndex, WebTestItemMetaData wtii)
        {
            wtii.wtit = WebTestItemType.Wti_LoopControl;
            _webTestItemMetaData.Add(_itemId++, wtii);
            WTI_LoopControl loop = items[nIndex] as WTI_LoopControl;
            RecurseTheWebTestItemCollection(loop.webTestItems, sTreeLoc + "." + nIndex.ToString(CultureInfo.InvariantCulture), iDepth + 1);
        }

        private void ParseIncludedWebTest(WebTestItemCollection items, int nIndex, WebTestItemMetaData wtii)
        {
            wtii.wtit = WebTestItemType.Wti_IncludedWebTestItem;
            WTI_IncludedWebTest includedWebTest = items[nIndex] as WTI_IncludedWebTest;
            //TODO: Consider adding recursion for the included web test here.
            _webTestItemMetaData.Add(_itemId++, wtii);
        }
        #endregion
    }
}
