using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using HttpWebTesting.SampleTest;
using HttpWebTesting;
using WebTestItemManager;
using WebTestExecutionEngine;
using AzureDevOps_API;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using Serilog;
using Serilog.Formatting.Compact;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using GTC_HttpArchiveReader;

namespace HttpWebTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(
                    outputTemplate: "[{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(
                    formatter: new CompactJsonFormatter(),
                    path: @"c:\Temp\HttpWebTester_log.json")
                .Enrich.FromLogContext()
                .CreateLogger();

            #region -- HttpWebTester -----
            //Build and Serialize a webtest
            //Sample sample = new Sample(@"c:\temp\sampleContosoTestFromUI.csv");
            //HttpWebTestSerializer.SerializeAndSaveTest(sample.httpWebTest, @"c:\temp\sampleContosoTestFromUI.json");

            // Make sure the test will deserialize
            //HttpWebTest newWebTest = HttpWebTestSerializer.DeserializeTest(@"c:\temp\sampleContosoTestFromUI.json");

            //ExecutionEngine execute = new ExecutionEngine(newWebTest);
            //execute.ExecuteTheTests();
            #endregion

            #region -- ADO API Client -----
            //ADO_API_Client client = LoadAdoApiStuff();
            ////GetAdoApiStuff("SP");
            //SetAdoApiStuff("SP", client);
            ////LoadAdoApiStuff();
            //return;
            #endregion

            #region -- Http Archive Rerader Stuff -----
            HttpArchiveReader harReader = new HttpArchiveReader();
            harReader.LoadArchive(@"c:\temp\workflow\geoffgr-first-workflow.har");
            harReader.BuildSortedListOfRequests();
            harReader.BuildVsWebtest();
            harReader.SaveLogFile(@"c:\temp\workflow\geoffgr-first-workflow.log");
            harReader.SaveNewVsWebtest(@"c:\temp\workflow\geoffgr-first-workflow.webtest");
            #endregion
        }

        static ADO_API_Client LoadAdoApiStuff()
        {
            ADO_API_Client client = new ADO_API_Client();

            //Step 1 - Get Test Configurations
            client.testConfigurations = (Dictionary<int, TestConfiguration>)DeserializeItem(@"C:\temp\sp_testconfigurations.json", client.testConfigurations);

            // Step 2 - Get Test Plans
            client.testPlans = (Dictionary<int, TestPlan>)DeserializeItem(@"C:\temp\sp_testplans.json", client.testPlans);

            // Step 3 - Get Test Suites (also gets test points)
            client.testSuiteSets = (List<Dictionary<int, TestSuite>>)DeserializeItem(@"C:\temp\sp_testsuites.json", client.testSuiteSets);

            // Step 4 - Get Case and Point Ids
            client.testCaseIds = (List<string>)DeserializeItem(@"C:\temp\sp_testCaseIds.json", client.testCaseIds);

            // Step 5 - Get Test Cases
            client.testCases = (Dictionary<int, WorkItem>)DeserializeItem(@"C:\temp\sp_testcases.json", client.testCases);

            // Step 6 - Get Test Points
            client.testPoints = (Dictionary<int, TestPoint>)DeserializeItem(@"C:\temp\sp_testcases.json", client.testPoints);
            return client;
        }

        static ADO_API_Client GetAdoApiStuff(string projectToUse)
        {
            ADO_API_Client client = new ADO_API_Client();

            //Step 1 - Get Test Configurations
            client.GetTestConfigurations(projectToUse);
            //SerializeAndSave(@"C:\temp\sp_testconfigurations.json", client.testPoints);

            // Step 2 - Get Test Plans
            client.testPlans = client.GetTestPlans(projectToUse);
            //SerializeAndSave(@"C:\temp\sp_testplans.json", client.testPlans);

            // Step 3 - Get Test Suites (also gets test points)
            Log.Information("----- Starting Suite List processing -----");
            foreach (var plan in client.testPlans)
            {
                if (plan.Value != null)
                {
                    Log.Information("Adding suite collection for {planId}", plan.Value.Id);
                    client.testSuiteSets.Add(client.GetTestSuites(projectToUse, plan.Value.Id.ToString()));
                }
            }
            //SerializeAndSave(@"C:\temp\sp_testsuites.json", client.testSuiteSets);

            // Step 4 - Get Case and Point Ids
            foreach (var suiteSet in client.testSuiteSets)
            {
                foreach (var suite in suiteSet)
                {
                    if (suite.Value != null && suite.Value.TestCaseCount > 0)
                    {
                        client.GetTestCaseIds(projectToUse, suite.Value.Plan.Id, suite.Key.ToString());
                    }
                }
            }
            //SerializeAndSave(@"C:\temp\sp_testCaseIds.json", client.testCaseIds);

            // Step 5 - Get Test Cases
            foreach (var caseId in client.testCaseIds)
            {
                client.GetTestCase(projectToUse, caseId);
            }
            //SerializeAndSave(@"C:\temp\sp_testcases.json", client.testCases);

            // Step 6 - Get Test Points
            foreach (var suiteSet in client.testSuiteSets)
            {
                foreach (var suite in suiteSet)
                {
                    if (suite.Value != null && suite.Value.TestCaseCount > 0)
                    {
                        client.GetTestPoints(projectToUse, suite.Value.Plan.Id, suite.Key.ToString());
                    }
                }
            }
            //SerializeAndSave(@"C:\temp\sp_testpoints.json", client.testPoints);
            return client;
        }

        static void SetAdoApiStuff(string projectToUse, ADO_API_Client client)
        {
            foreach(KeyValuePair<int, TestPlan> plan in client.testPlans)
            {
                var item = plan.Value;
                client.CreateTestPlan(projectToUse, item);
            }
        }

        private static void SerializeAndSave(string filename, object item)
        {
            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                sw.Write(JsonConvert.SerializeObject(item, Formatting.Indented));
            }
        }

        private static object DeserializeItem(string filename, object item)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    return JsonConvert.DeserializeObject(sr.ReadToEnd(), item.GetType());
                }
            }
            catch(Exception EX)
            {
                Console.Write(EX.ToString());
            }
            return null;
        }
    }
}
