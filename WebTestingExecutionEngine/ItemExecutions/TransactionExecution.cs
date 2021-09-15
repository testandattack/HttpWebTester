using HttpWebTesting;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using System;
using System.Collections.Generic;
using System.Text;

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

        public WebTestResultsItem ProcessTransaction()
        {
            if (transaction.Enabled == false)
            {
                WTI_SkippedItem skippedItem = new WTI_SkippedItem(transaction.Name, WebTestItemType.Wti_LoopControl);
                return new WTRI_SkippedItem(skippedItem);
            }

            WTRI_Transaction transactionResults = new WTRI_Transaction(transaction);
            transactionResults.webTestResultsItems = WebTestItemCollectionExecution.ExecuteWebTestItemCollection(httpWebTest, transaction.webTestItems);
            return transactionResults;
        }


    }
}
