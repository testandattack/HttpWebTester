using HttpWebTesting;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebTestExecutionEngine
{
    public class TransactionExecution
    {
        public HttpWebTest httpWebTest { get; set; }

        public WTI_Transaction transaction { get; set; }

        #region -- Constructors -----
        public TransactionExecution(WTI_Transaction wTI_Transaction, HttpWebTest webTest)
        {
            httpWebTest = webTest;
            transaction = wTI_Transaction;
        }
        #endregion

        public async Task<WebTestResultsItem> ProcessTransaction()
        {
            if (transaction.Enabled == false)
            {
                WTI_SkippedItem skippedItem = new WTI_SkippedItem(transaction.Name, WebTestItemType.Wti_LoopControl);
                return new WTRI_SkippedItem(skippedItem);
            }

            WTRI_Transaction transactionResults = new WTRI_Transaction(transaction.guid);
            transactionResults.webTestResultsItems = await WebTestItemCollectionExecution.ExecuteWebTestItemCollectionAsync(httpWebTest, transaction.webTestItems);
            if (transactionResults.webTestResultsItems.ExecutionState == RuleResult.Failed)
            {
                transactionResults.ItemExecutionFailed = true;
            }
            return transactionResults;
        }


    }
}
