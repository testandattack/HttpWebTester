using HttpWebTesting;
using HttpWebTesting.DataSources;
using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using Newtonsoft.Json;
using Serilog;
using System;
using System.IO;
using System.Net.Http;
using WebTestExecutionEngine;
using WebTestRules;
using WebTestItemManager;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WebTestExecutionEngine
{
    public class ExecutionEngine
    {
        public HttpWebTest httpWebTest { get; set; }

        private HttpWebTestResults testingResults;

        public ExecutionEngine() { }

        public ExecutionEngine(HttpWebTest webTest)
        {
            string logFileName = @"c:\temp\HttpWebTester_Log.txt";
            if (File.Exists(logFileName)) File.Delete(logFileName);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(
                    outputTemplate: "{Timestamp:HH:mm} [{Level:u3}] ({ThreadId}) {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(logFileName)
                .Enrich.FromLogContext()
                .CreateLogger();

            httpWebTest = webTest;
            CreateTestResults();
        }

        private void CreateTestResults()
        {
            testingResults = new HttpWebTestResults();
            string CurrentTime = DateTime.Now.ToString("yyyyMMdd_hh-mm-ss");
            testingResults.Name = $"{httpWebTest.Name} {CurrentTime}";
            testingResults.Description = $"Results for the execution of the webtest {httpWebTest.Name} on {DateTime.Now}";
            string webTestCopy = HttpWebTestSerializer.SerializeTest(httpWebTest);
            testingResults.originalWebTest = HttpWebTestSerializer.DeserializeTestFromString(webTestCopy);
            testingResults.TestAgent = Environment.MachineName;
        }

        public HttpWebTestResults ExecuteTheTests()
        {
            // Need to make these staic, or add them in a way that we do not need to initialize.
            Log.ForContext("SourceContext", "ExecutionEngine").Information("Starting test execution for {webTest}", httpWebTest.Name);
            LoadDataSources();
            BindDataSources();

            Log.ForContext("SourceContext", "ExecutionEngine").Debug("Calling {method}", "ExecuteItemCollectionAsync");
            Task.Run(() => ExecuteItemCollectionAsync()).Wait();

            PostWebTestExecution postWebTestExecution = new PostWebTestExecution();
            Log.ForContext("SourceContext", "ExecutionEngine").Debug("Calling {method}", "ProcessPostWebTest");
            postWebTestExecution.ProcessPostWebTest();

            testingResults.SaveTestResults("c:\\temp\\testresults.json");
            Log.ForContext("SourceContext", "ExecutionEngine").Information("Finished Executing Test: {webTest}", httpWebTest.Name);
            Log.CloseAndFlush();
            return testingResults;
        }

        private async Task ExecuteItemCollectionAsync()
        {
            testingResults.webTestResultsItems = await WebTestItemCollectionExecution.ExecuteWebTestItemCollectionAsync(httpWebTest, httpWebTest.WebTestItems);
            if (testingResults.webTestResultsItems.ExecutionState == RuleResult.Failed)
                testingResults.ContainsFailedExecutionItem = true;
        }

        private void LoadDataSources()
        {
            Log.ForContext("SourceContext", "ExecutionEngine").Debug("Executing {objectItemType}", "LoadDataSources");
            foreach (var dataSource in httpWebTest.DataSources)
            {
                if (dataSource.dataSourceType == DataSourceType.CSV)
                {
                    string fileLocation = string.Empty;
                    if (((CsvDataSource)dataSource).csvDataSourceFile.Contains("\\") == false)
                        fileLocation = httpWebTest.WorkingDirectoryLocation + "\\" + ((CsvDataSource)dataSource).csvDataSourceFile;
                    else
                        fileLocation = ((CsvDataSource)dataSource).csvDataSourceFile;

                    dataSource.dataTable = CsvDataSourceLoader.LoadDataSource(fileLocation);
                }
                Log.ForContext("SourceContext", "ExecutionEngine").Verbose("Loaded {objectItemType}", dataSource);
            }
        }

        private void BindDataSources()
        {
            Log.ForContext("SourceContext", "ExecutionEngine").Debug("Executing {objectItemType}", "BindDataSources");
            foreach (var dataSource in httpWebTest.DataSources)
            {
                dataSource.GetNextRow(httpWebTest.ContextProperties);
            }
            Log.ForContext("SourceContext", "ExecutionEngine").Verbose("Bound all data sources.");
        }
    }
}
