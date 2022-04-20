using Microsoft.TeamFoundation.TestManagement.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GTC.Extensions;

namespace AzureDevOps_API
{
    public partial class ADO_API_Client
    {
        private AdoSettings _settings;

        public Dictionary<int, TestConfiguration> testConfigurations { get; set; }
        public Dictionary<int, WorkItem> testCases { get; set; }
        public Dictionary<int, TestPlan> testPlans { get; set; }
        public List<Dictionary<int, TestSuite>> testSuiteSets { get; set; }
        public Dictionary<int, TestPoint> testPoints { get; set; }
        public List<string> testCaseIds { get; set; }
        public List<string> testPointIds { get; set; }
        public List<string> testConfigurationIds { get; set; }


        public ADO_API_Client()
        {
            _settings = LoadAdoSettings.LoadSettings();
            testConfigurations = new Dictionary<int, TestConfiguration>();
            testCases = new Dictionary<int, WorkItem>();
            testPlans = new Dictionary<int, TestPlan>();
            testSuiteSets = new List<Dictionary<int, TestSuite>>();
            testPoints = new Dictionary<int, TestPoint>();
            testCaseIds = new List<string>();
            testPointIds = new List<string>();
            testConfigurationIds = new List<string>();
        }

        public static async Task<string> GetApiResponseWithRetry(string pat, string url)
        {
            string returnValue = await GetApiResponse(pat, url);
            if(returnValue == "ServiceUnavailable")
            {
                Log.ForContext<ADO_API_Client>().Information("Received Error 503 for {url}. Retrying...", url);
                Thread.Sleep(2000);
                returnValue = await GetApiResponse(pat, url);
            }
            return returnValue;
        }

        public static async Task<string> PostApiResponseWithRetry(string pat, string url, string body)
        {
            string returnValue = await PostApiResponse(pat, url, body);
            if (returnValue == "ServiceUnavailable")
            {
                Log.ForContext<ADO_API_Client>().Information("Received Error 503 for {url}. Retrying...", url);
                Thread.Sleep(2000);
                returnValue = await PostApiResponse(pat, url, body);
            }
            return returnValue;
        }

        public static async Task<string> GetApiResponse(string pat, string url)
        {
            try
            {
                var personalaccesstoken = pat;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken))));

                    Uri uri = new Uri(url);
                    using (HttpResponseMessage response = client.GetAsync(uri).Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
                            return "ServiceUnavailable";
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return responseBody;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetApiResponse: {url}",url);
            }
            return string.Empty;
        }

        public static async Task<string> PostApiResponse(string pat, string url, string body)
        {
            try
            {
                var personalaccesstoken = pat;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken))));

                    StringContent content = new StringContent(body);

                    Uri uri = new Uri(url);
                    
                    using (HttpResponseMessage response = client.PostAsync(uri, content).Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
                            return "ServiceUnavailable";
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return responseBody;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ForContext<ADO_API_Client>().Error(ex, "GetApiResponse: {url}", url);
            }
            return string.Empty;
        }

    }
}
