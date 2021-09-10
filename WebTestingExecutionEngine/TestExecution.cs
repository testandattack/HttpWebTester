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
    public class ExecutionEngine
    {
        public HttpWebTest webTest { get; set; }

        private HttpWebTestResults testingResults;

        public ExecutionEngine() { }

        public ExecutionEngine(HttpWebTest httpWebTest)
        {
            webTest = httpWebTest;
            testingResults = new HttpWebTestResults();
        }


        public HttpWebTestResults ExecuteTheTests()
        {
            // Need to make these staic, or add them in a way that we do not need to initialize.
            PreWebTestExecution preWebTestExecution = new PreWebTestExecution();
            preWebTestExecution.ProcessPreWebTest(webTest);

            testingResults.webTestResultsItems = WebTestItemCollectionExecution
                .ExecuteWebTestItemCollection(webTest, webTest.WebTestItems);

            PostWebTestExecution postWebTestExecution = new PostWebTestExecution();
            postWebTestExecution.ProcessPostWebTest();

            //testingResults.SaveTestResults("c:\\HttpWebTest\\testresults.json");
            return testingResults;
            //Console.WriteLine("Finished Test");
        }
    }
}
