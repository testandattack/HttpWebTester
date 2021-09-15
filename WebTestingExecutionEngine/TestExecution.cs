using HttpWebTesting;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using Newtonsoft.Json;
using Serilog;
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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File(@"c:\temp\HttpWebTester_Log.txt")
                .Enrich.FromLogContext()
                .CreateLogger();
        }

        

        public HttpWebTestResults ExecuteTheTests()
        {
            // Need to make these staic, or add them in a way that we do not need to initialize.
            PreWebTestExecution preWebTestExecution = new PreWebTestExecution();
            Log.ForContext("SourceContext", "ExecutionEngine").Debug("Executing {objectItemType}", "ProcessPreWebTest");
            preWebTestExecution.ProcessPreWebTest(webTest);

            Log.ForContext("SourceContext", "ExecutionEngine").Debug("Executing {objectItemType}", "ExecuteWebTestItemCollection");
            testingResults.webTestResultsItems = WebTestItemCollectionExecution
                .ExecuteWebTestItemCollection(webTest, webTest.WebTestItems);

            PostWebTestExecution postWebTestExecution = new PostWebTestExecution();
            Log.ForContext("SourceContext", "ExecutionEngine").Debug("Executing {objectItemType}", "ProcessPostWebTest");
            postWebTestExecution.ProcessPostWebTest();

            testingResults.SaveTestResults("c:\\temp\\testresults.json");
            Log.ForContext("SourceContext", "ExecutionEngine").Debug("Finished Executing Test: {objectItemType}", webTest.Name);
            Log.CloseAndFlush();
            return testingResults;
            //Console.WriteLine("Finished Test");
        }
    }
}
