using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTestingResults
{
    public class WebTestResultsItemManager
    {
        public HttpWebTestResults httpWebTestResults { get; set; }
        
        public WebTestResultsItemManager()
        {
            httpWebTestResults = new HttpWebTestResults();
        }

        public static WTRI_Request CreateNewRequestResult(WTI_Request originalRequest)
        {
            WTRI_Request result = new WTRI_Request(new Guid());
            result.RequestAsSavedInTest = originalRequest;
            return result;
        }

        public static WTRI_Transaction CreateNewTransactionResults(string Name)
        {
            return CreateNewTransactionResults(Name, new WebTestResultsItemCollection());
        }
        
        public static WTRI_Transaction CreateNewTransactionResults(string Name, WebTestResultsItemCollection items)
        {
            WTRI_Transaction transaction = new WTRI_Transaction();
            transaction.Name = Name;
            transaction.webTestResultsItems = items;
            return transaction;
        }
    }
}
