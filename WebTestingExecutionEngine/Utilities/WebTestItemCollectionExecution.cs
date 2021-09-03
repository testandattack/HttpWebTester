using HttpWebTesting;
using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WebTestExecutionEngine
{
    public static class WebTestItemCollectionExecution
    {
        public static Collection<WebTestResultsItem> ExecuteWebTestItemCollection(HttpWebTest webTest, WebTestItemCollection webTestItems)
        {
            Collection<WebTestResultsItem> results = new Collection<WebTestResultsItem>();
            foreach (WebTestItem item in webTestItems)
            {
                WebTestResultsItem resultsItem = null;
                if (item.objectItemType == WebTestItemType.Wti_Comment)
                {
                    var commentExecutor = new CommentExecution(item as WTI_Comment, webTest);
                    resultsItem = commentExecutor.ProcessComment();
                }
                else if (item.objectItemType == WebTestItemType.Wti_IncludedWebTestItem)
                {
                    var includedWebTestExecutor = new IncludedWebTestExecution(item as WTI_IncludedWebTest, webTest);
                    resultsItem = includedWebTestExecutor.ProcessIncludedWebTest();
                }
                else if (item.objectItemType == WebTestItemType.Wti_LoopControl)
                {
                    var loopControlExecutor = new LoopControlExecution(item as WTI_LoopControl, webTest);
                    resultsItem = loopControlExecutor.ProcessLoop();
                }
                else if (item.objectItemType == WebTestItemType.Wti_RequestObject)
                {
                    var requestExecutor = new RequestExecution(item as WTI_Request, webTest);
                    resultsItem = requestExecutor.ProcessRequest();
                }
                else if (item.objectItemType == WebTestItemType.Wti_Transactiontimer)
                {
                    var transactionExecutor = new TransactionExecution(item as WTI_Transaction, webTest);
                    resultsItem = transactionExecutor.ProcessTransaction();
                }
                results.Add(resultsItem);
            }
            return results;
        }
    }
}
