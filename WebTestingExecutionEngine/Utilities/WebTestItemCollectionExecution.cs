using HttpWebTesting;
using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Serilog;
using System.Threading.Tasks;

namespace WebTestExecutionEngine
{
    public static class WebTestItemCollectionExecution
    {
        public static async Task<WebTestResultsItemCollection> ExecuteWebTestItemCollectionAsync(HttpWebTest webTest, WebTestItemCollection webTestItems)
        {
            WebTestResultsItemCollection results = new WebTestResultsItemCollection();
            results.ExecutionState = RuleResult.Passed;

            foreach (WebTestItem item in webTestItems)
            {
                WebTestResultsItem resultsItem = null;
                if (item.objectItemType == WebTestItemType.Wti_Comment)
                {
                    Log.ForContext("SourceContext", "WebTestItemCollectionExecution").Verbose("Processing {objectItemType}", "Wti_Comment");
                    if (webTest.SuppressAllCommentsInResults == false)
                    {
                        var commentExecutor = new CommentExecution(item as WTI_Comment, webTest);
                        resultsItem = commentExecutor.ProcessComment();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (item.objectItemType == WebTestItemType.Wti_IncludedWebTestItem)
                {
                    Log.ForContext("SourceContext", "WebTestItemCollectionExecution").Verbose("Processing {objectItemType}", "Wti_IncludedWebTestItem");
                    var includedWebTestExecutor = new IncludedWebTestExecution(item as WTI_IncludedWebTest, webTest);
                    resultsItem = await includedWebTestExecutor.ProcessIncludedWebTest();
                }
                else if (item.objectItemType == WebTestItemType.Wti_LoopControl)
                {
                    Log.ForContext("SourceContext", "WebTestItemCollectionExecution").Verbose("Processing {objectItemType}", "Wti_LoopControl");
                    var loopControlExecutor = new LoopControlExecution(item as WTI_LoopControl, webTest);
                    resultsItem = await loopControlExecutor.ProcessLoopAsync();
                }
                else if (item.objectItemType == WebTestItemType.Wti_RequestObject)
                {
                    Log.ForContext("SourceContext", "WebTestItemCollectionExecution").Verbose("Processing {objectItemType}", "Wti_RequestObject");
                    var requestExecutor = new RequestExecution(item as WTI_Request, webTest);
                    resultsItem = await requestExecutor.ProcessRequest();
                }
                else if (item.objectItemType == WebTestItemType.Wti_Transactiontimer)
                {
                    Log.ForContext("SourceContext", "WebTestItemCollectionExecution").Verbose("Processing {objectItemType}", "Wti_Transactiontimer");
                    var transactionExecutor = new TransactionExecution(item as WTI_Transaction, webTest);
                    resultsItem = await transactionExecutor.ProcessTransaction();
                }
                else
                {
                    throw new NotSupportedException($"found unknown object item type in item {item.guid}");
                }
                results.Add(resultsItem);

                if (resultsItem.ItemExecutionFailed == true)
                {
                    Log.ForContext("SourceContext", "WebTestItemCollectionExecution").Information("Execution Failed. Test Stopping. {resultsItem}", resultsItem.webTestItemId);
                    results.ExecutionState = RuleResult.Failed;
                    if (webTest.StopOnError == true)
                    {
                        return results;
                    }
                }
                Log.ForContext("SourceContext", "WebTestItemCollectionExecution").Verbose("Finished item execution.");
            }
            return results;
        }
    }
}
