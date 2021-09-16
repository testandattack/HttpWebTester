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

            testingResults = new HttpWebTestResults();
            httpWebTest = webTest;
        }


        public HttpWebTestResults ExecuteTheTests()
        {
            // Need to make these staic, or add them in a way that we do not need to initialize.
            Log.ForContext("SourceContext", "ExecutionEngine").Information("Starting test execution for {webTest}", httpWebTest.Name);
            LoadDataSources();
            BindDataSources();

            Log.ForContext("SourceContext", "ExecutionEngine").Debug("Calling {method}", "ExecuteWebTestItemCollection");
            testingResults.webTestResultsItems = WebTestItemCollectionExecution
                .ExecuteWebTestItemCollection(httpWebTest, httpWebTest.WebTestItems);

            PostWebTestExecution postWebTestExecution = new PostWebTestExecution();
            Log.ForContext("SourceContext", "ExecutionEngine").Debug("Calling {method}", "ProcessPostWebTest");
            postWebTestExecution.ProcessPostWebTest();

            testingResults.SaveTestResults("c:\\temp\\testresults.json");
            Log.ForContext("SourceContext", "ExecutionEngine").Information("Finished Executing Test: {webTest}", httpWebTest.Name);
            Log.CloseAndFlush();
            return testingResults;
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
