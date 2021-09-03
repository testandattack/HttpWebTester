using HttpWebTesting;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using System;
using System.Net.Http;
using WebTestExecutionEngine;
using WebTestRules;

namespace WebTestExecutionEngine
{
    public class ExecuteTests
    {
        public HttpWebTest webTest { get; set; }

        HttpWebTestResults testingResults { get; set; }

        public ExecuteTests() { }

        public ExecuteTests(HttpWebTest httpWebTest)
        {
            webTest = httpWebTest;
            testingResults = new HttpWebTestResults();
        }


        public void ExecuteTheTests()
        {
            // Need to make these staic, or add them in a way that we do not need to initialize.
            PreWebTestExecution preWebTestExecution = new PreWebTestExecution();
            preWebTestExecution.ProcessPreWebTest(webTest);

            testingResults.webTestResultsItems = WebTestItemCollectionExecution
                .ExecuteWebTestItemCollection(webTest, webTest.WebTestItems);

            PostWebTestExecution postWebTestExecution = new PostWebTestExecution();
            postWebTestExecution.ProcessPostWebTest();

            testingResults.SaveTestResults("c:\\HttpWebTest\\testresults.json");
            
            Console.WriteLine("Finished Test");
        }
    }
}
