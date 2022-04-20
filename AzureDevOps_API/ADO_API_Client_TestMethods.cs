using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using GTC.Extensions;
using System.Linq;

namespace AzureDevOps_API
{
    public partial class ADO_API_Client
    {
        #region -- REST API Urls for Azure DevOps -----
        // 0 = site.SiteOrg
        // 1 = site.Project
        private const string URI_GetTestPlans_5_0 = "https://dev.azure.com/{0}/{1}/_apis/test/plans?api-version=5.0";

        // 0 = site.SiteOrg
        // 1 = site.Project
        // 2 = plan ID
        private const string URI_GetTestPlan_5_0 = "https://dev.azure.com/{0}/{1}/_apis/test/plans/{2}?api-version=5.0";

        // 0 = site.SiteOrg
        // 1 = site.Project
        // 2 = plan ID
        private const string URI_GetTestSuites_5_0 = "https://dev.azure.com/{0}/{1}/_apis/test/plans/{2}/suites?api-version=5.0";

        // 0 = site.SiteOrg
        // 1 = site.Project
        // 2 = plan ID
        // 3 = suite ID
        private const string URI_GetTestSuite_5_0 = "https://dev.azure.com/{0}/{1}/_apis/test/plans/{2}/suites/{3}?api-version=5.0";

        // 0 = site.SiteOrg
        // 1 = site.Project
        // 2 = plan ID
        // 3 = suite ID
        private const string URI_GetTestCases_5_0 = "https://dev.azure.com/{0}/{1}/_apis/test/plans/{2}/suites/{3}/testcases?api-version=5.0";

        // 0 = site.SiteOrg
        // 1 = test case ID
        private const string URI_GetTestCase_5_0 = "https://dev.azure.com/{0}/_apis/wit/workitems/{1}?api-version=5.0";

        // 0 = site.SiteOrg
        // 1 = site.Project
        private const string URI_GetTestConfigurations_5_0 = "https://dev.azure.com/{0}/{1}/_apis/testplan/configurations?api-version=5.0-preview.1";

        // 0 = site.SiteOrg
        // 1 = site.Project
        // 2 = configuration ID
        private const string URI_GetTestConfiguration_5_0 = "https://dev.azure.com/{0}/{1}/_apis/testplan/configurations/{2}?api-version=5.0-preview.1";

        // 0 = site.SiteOrg
        // 1 = site.Project
        // 2 = plan ID
        // 3 = suite ID
        private const string URI_GetTestPoints_6_0 = "https://dev.azure.com/{0}/{1}/_apis/test/Plans/{2}/Suites/{3}/points?api-version=6.0";

        // 0 = site.SiteOrg
        // 1 = site.Project
        // 2 = plan ID
        // 3 = suite ID
        // 4 = point Id
        private const string URI_GetTestPoint_6_0 = "https://dev.azure.com/{0}/{1}/_apis/test/Plans/{2}/Suites/{3}/points/{4}?api-version=6.0";

        private const string URI_PostTestPlan_5_0 = "https://dev.azure.com/{0}/{1}/_apis/test/plans?api-version=5.0";

        #region -- Special Cases -----
        // 0 = site.SiteOrg
        // 1 = site.Project
        // 2 = plan ID
        private const string URI_TestPlanClone_5_0 = "https://dev.azure.com/{0}/{1}/_apis/test/Plans/{2}/cloneoperation?api-version=5.0-preview.2";
        #endregion
        #endregion

        public Dictionary<int, TestPlan> GetTestPlans(string devOpsSite)
        {
            Dictionary<int, TestPlan> testPlans = new Dictionary<int, TestPlan>();
            try
            {
                Log.Information("Getting List of test plans.");
                string url = string.Format(URI_GetTestPlans_5_0, _settings.DevOpsSites[devOpsSite].SiteOrg, _settings.DevOpsSites[devOpsSite].Project);
                string testPlansRaw = GetApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
                JObject o = JObject.Parse(testPlansRaw);
                IEnumerable<JToken> tokens = o.SelectTokens("$.value[*].id");
                foreach(JToken token in tokens)
                {
                    Log.Information("Adding {planId} to the collection", (int)token);
                    testPlans.Add((int)token, GetTestPlan(devOpsSite, token.ToString()));
                }
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetTestPlans: {devOpsSite}", devOpsSite);
            }
            return testPlans;
        }

        public TestPlan GetTestPlan(string devOpsSite, string planId)
        {
            string returnValue;
            try
            {
                TestPlan _testPlan;
                string url = string.Format(URI_GetTestPlan_5_0, _settings.DevOpsSites[devOpsSite].SiteOrg, _settings.DevOpsSites[devOpsSite].Project, planId);
                returnValue = GetApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
                _testPlan = JsonConvert.DeserializeObject<TestPlan>(returnValue);
                return _testPlan;
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetTestPlan: {planId}", planId);
            }
            return null;
        }

        public TestPlan CreateTestPlan(string devOpsSite, TestPlan plan)
        {
            //TestPlan newPlan = new TestPlan();
            //newPlan.Name = plan.Name;
            //newPlan.Description = plan.Description;
            //newPlan.Area = new ShallowReference(name: plan.Area.Name);
            //newPlan.Area.Name = plan.Area.Name;
            //newPlan.StartDate = plan.StartDate;
            //newPlan.EndDate = plan.EndDate;
            //newPlan.Iteration = plan.Iteration;
            //newPlan.State = plan.State;

            //string newPlanAsString = JsonConvert.SerializeObject(newPlan);
            string newPlanAsString = @"{
  'name': '{0}',
  'description': '{1}'
}";
            string sBody = newPlanAsString
                .Replace("{0}", plan.Name)
                .Replace("{1}", plan.Description ?? "")
                .Replace("'", "\"");
            Log.Information("Posting plan");
            string url = string.Format(URI_PostTestPlan_5_0, _settings.DevOpsSites[devOpsSite].SiteOrg, _settings.DevOpsSites[devOpsSite].Project);
            string testPlanCreated = PostApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, url, sBody).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<TestPlan>(testPlanCreated);
        }

        public Dictionary<int, TestSuite> GetTestSuites(string devOpsSite, string planId)
        {

            Dictionary<int, TestSuite> testSuites = new Dictionary<int, TestSuite>();
            try
            {
                Log.Information("Getting list of suites for {planId}", planId);
                string url = string.Format(URI_GetTestSuites_5_0, _settings.DevOpsSites[devOpsSite].SiteOrg, _settings.DevOpsSites[devOpsSite].Project, planId);
                string testSuitesRaw = GetApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
                JObject o = JObject.Parse(testSuitesRaw);
                IEnumerable<JToken> tokens = o.SelectTokens("$.value[*].id");
                foreach (JToken token in tokens)
                {
                    Log.Information("Adding {suiteId} to the collection for {planId}", (int)token, planId);
                    testSuites.Add((int)token, GetTestSuite(devOpsSite, planId, token.ToString()));
                }
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetTestSuites: {planId}", planId);
            }
            return testSuites;
        }

        public TestSuite GetTestSuite(string devOpsSite, string planId, string suiteId)
        {
            string returnValue;
            try
            {
                TestSuite _testSuite;
                string url = string.Format(URI_GetTestSuite_5_0, _settings.DevOpsSites[devOpsSite].SiteOrg, _settings.DevOpsSites[devOpsSite].Project, planId, suiteId);
                returnValue = GetApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
                _testSuite = JsonConvert.DeserializeObject<TestSuite>(returnValue);
                //if(_testSuite.TestCaseCount > 0)
                //{
                //    GetTestCaseIds(devOpsSite, planId, suiteId);
                //    GetTestPointIds(devOpsSite, planId, suiteId);
                //}
                return _testSuite;
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetTestSuite: {planId} {suiteId}", planId, suiteId);
            }
            return null;
        }

        public void GetTestCaseIds(string devOpsSite, string planId, string suiteId)
        {
            Log.Information("Getting list of suites for {planId}", planId);
            string url = string.Format(URI_GetTestCases_5_0, _settings.DevOpsSites[devOpsSite].SiteOrg, _settings.DevOpsSites[devOpsSite].Project, planId, suiteId);
            string testCasesRaw = GetApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
            JObject o = JObject.Parse(testCasesRaw);
            IEnumerable<JToken> tokens = o.SelectTokens("$.value[*]");
            int x = 0;
            foreach (JToken token in tokens)
            {
                SuiteTestCase stc = JsonConvert.DeserializeObject<SuiteTestCase>(token.ToString());
                if (testCaseIds.AddUnique(stc.Workitem.Id))
                    x++;
            }
            Log.Information("Adding {qty} test case ids to the list", x);
        }

        public void GetTestPoints(string devOpsSite, string planId, string suiteId)
        {
            Log.Information("Getting list of points for {planId} {suiteId}", planId, suiteId);
            string url = string.Empty;
            string testPointsRaw;
            try
            {
                int x = 0;
                url = string.Format(URI_GetTestPoints_6_0, _settings.DevOpsSites[devOpsSite].SiteOrg, _settings.DevOpsSites[devOpsSite].Project, planId, suiteId);
                testPointsRaw = GetApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
                KeyValuePair<string, TestPoint[]> planTestPoints = JsonConvert.DeserializeObject<KeyValuePair<string, TestPoint[]>>(testPointsRaw);
                foreach(TestPoint point in planTestPoints.Value)
                {
                    string sTemp = point.Url;
                    if(testPoints.ContainsKey(point.Id) == false)
                    {
                        x++;
                        //string pointUrl = string.Format(URI_GetTestPoint_6_0, _settings.DevOpsSites[devOpsSite].SiteOrg, _settings.DevOpsSites[devOpsSite].Project, planId, suiteId, point.Id);
                        //string testPointRaw = GetApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
                        string testPointRaw = GetApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, sTemp).GetAwaiter().GetResult();
                        TestPoint fullTestPoint = JsonConvert.DeserializeObject<TestPoint>(testPointRaw);
                        Log.Information("Adding point with the id {id}", point.Id);
                        testPoints.Add(point.Id, fullTestPoint);
                    }
                }
                Log.Information("Adding {qty} test points to the list", x);
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetTestPointIds: {planId} {suiteId}", planId, suiteId, url);
            }
        }

        public void GetTestCase(string devOpsSite, string testCaseId)
        {
            try
            {
                WorkItem testCase = new WorkItem();
                string url = string.Format(URI_GetTestCase_5_0, _settings.DevOpsSites[devOpsSite].SiteOrg, testCaseId);
                string response = GetApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
                testCase = JsonConvert.DeserializeObject<WorkItem>(response);
                testCases.Add(Int32.Parse(testCaseId), testCase);
                Log.Information("Added testcase {testCaseId} to the list.", testCaseId);
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetTestCase: {testCaseId}",testCaseId);
            }

        }

        public void GetTestPoint(string devOpsSite, string testPointId)
        {
            try
            {
                TestPoint testPoint = new TestPoint();
                string url = string.Format(URI_GetTestCase_5_0, _settings.DevOpsSites[devOpsSite].SiteOrg, testPointId);
                string response = GetApiResponseWithRetry(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
                testPoint = JsonConvert.DeserializeObject<TestPoint>(response);
                testPoints.Add(Int32.Parse(testPointId), testPoint);
                Log.Information("Added testPoint {testPointId} to the list.", testPointId);
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetTestPoint: {testPointId}", testPointId);
            }

        }

        public void GetTestConfigurations(string devOpsSite)
        {
            try
            {
                TestConfiguration config = new TestConfiguration();
                string url = string.Format(URI_GetTestConfigurations_5_0, _settings.DevOpsSites[devOpsSite].SiteOrg, _settings.DevOpsSites[devOpsSite].Project);
                string response = GetApiResponse(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
                JObject o = JObject.Parse(response);
                IEnumerable<JToken> tokens = o.SelectTokens("$.value[*]");
                int x = 0;
                foreach (JToken token in tokens)
                {
                    TestConfiguration tp = JsonConvert.DeserializeObject<TestConfiguration>(token.ToString());
                    if (testConfigurationIds.AddUnique(tp.Id.ToString()))
                    {
                        x++;
                        GetTestConfiguration(devOpsSite, tp.Id.ToString());                    }
                }
                Log.Information("Adding {qty} test case ids to the list", x);
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetTestConfigurations");
            }
        }

        public void GetTestConfiguration(string devOpsSite, string configurationId)
        {
            try
            {
                TestConfiguration config = new TestConfiguration();
                string url = string.Format(URI_GetTestConfiguration_5_0, _settings.DevOpsSites[devOpsSite].SiteOrg, _settings.DevOpsSites[devOpsSite].Project, configurationId);
                string response = GetApiResponse(_settings.DevOpsSites[devOpsSite].SitePAT, url).GetAwaiter().GetResult();
                config = JsonConvert.DeserializeObject<TestConfiguration>(response);
                testConfigurations.Add(Int32.Parse(configurationId), config);
                Log.Information("Added testConfiguration {configurationId} to the list.", configurationId);
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetTestCase: {configurationId}", configurationId);
            }
        }
    }
}
