using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using HttpWebTesting;
using HttpWebTesting.Collections;
using HttpWebTesting.CoreObjects;
using HttpWebTesting.DataSources;
using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using WebTestRules;

namespace HttpWebTesting.SampleTest
{
    public class Sample
    {
        public HttpWebTest httpWebTest { get; set; }

        public Sample()
        {
            httpWebTest = new HttpWebTest("Sample Web Test");
            BuildWebtest();
        }

        private void BuildWebtest()
        {
            // Add a data source
            CsvDataSource cds = new CsvDataSource();
            cds.Name = "ExampleCsvDataSource";
            cds.dataSourceCursorType = DataSourceCursorType.Sequential;
            httpWebTest.DataSources.Add(cds);

            // Add a couple of context properties
            Property property = new Property("Context1", "Value1");
            httpWebTest.ContextProperties.Add(property);
            httpWebTest.ContextProperties.Add(new Property("Context2", "Value2"));
            
            // Add a comment
            httpWebTest.WebTestItems.Add(new WTI_Comment("Sample Comment"));

            // Add a transaction
            AddTransactionToSample("Sample Transaction");

            // Add a request
            AddRequest(httpWebTest.WebTestItems);

            // Add a test level rule
            var validateStatusCode = new ValidateStatusCode();
            httpWebTest.Rules.Add(validateStatusCode);
        }

        private void AddTransactionToSample(string tranName)
        {
            WTI_Transaction transaction = new WTI_Transaction();
            transaction.Name = tranName;
            transaction.webTestItems.Add(new WTI_Comment("Embedded Comment"));
            
            // This call adds a basic request, but no additional stuff
            transaction.webTestItems.Add(new WTI_Request(BuildFormPostRequest("http://www.bing.com")));

            // This call adds a request with additional settings and a rule
            AddRequest(transaction.webTestItems);

            httpWebTest.WebTestItems.Add(transaction);
        }

        private void AddRequest(WebTestItemCollection items)
        {
            // Build a request
            WTI_Request req = new WTI_Request(BuildFormPostRequest("http://www.contoso.com"));

            // Set some properties
            req.ThinkTime = 5;
            req.ReportingName = "Contoso Home Page Post.";

            // Add a rule to it
            var responseContainsValidationRule = new ValidateResponseText();
            responseContainsValidationRule.ValueToFind = "Phrase to look for in the response";
            req.Rules.Add(responseContainsValidationRule);

            //Add request to the collection
            items.Add(req);
        }

        private HttpRequestMessage BuildFormPostRequest(string sUrl)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, sUrl);
            message.Headers.Add("CustomHeader", "customeHeaderValue");
            
            //MultipartFormDataContent content = new MultipartFormDataContent();

            //content.Add(new StringContent(Guid.NewGuid().ToString()), "Id");
            //content.Add(new StringContent("Value 2"), "Key2");
            //message.Content = content;
            return message;
        }

        private HttpRequestMessage BuildJsonPostMessage(string sUrl)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, sUrl);
            message.Headers.Add("CustomHeader", "customeHeaderValue");

//            string jsonString = @"
//{
    
//}";

            //StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            //message.Content = content;
            return message;
        }

    }
}
