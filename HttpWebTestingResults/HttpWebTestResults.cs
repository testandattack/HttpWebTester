using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Serilog;
using GTC.Extensions;
using HttpWebTesting;

namespace HttpWebTestingResults
{
    public class HttpWebTestResults
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string TestAgent { get; set; }

        public DateTime executionTime { get; set; }

        public bool ContainsFailedExecutionItem = false;

        [JsonProperty(PropertyName = "TestResultsItems")]
        public WebTestResultsItemCollection webTestResultsItems { get; set; }

        [JsonProperty(PropertyName = "Original Web Test")]
        public HttpWebTest originalWebTest { get; set; }

        public HttpWebTestResults()
        {
            webTestResultsItems = new WebTestResultsItemCollection();
            executionTime = DateTime.UtcNow;
            // Results design still under construction
            //throw new NotImplementedException();
        }

        public void SaveTestResults(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                sw.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
                Log.ForContext<HttpWebTestResults>().Information("aved Test results to {fileName}");
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);//base.ToString();
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine($"Results for test '{Name}'");
        //    sb.AppendLine($"Executed on {executionTime.ToString()}");
        //    foreach(var item in webTestResultsItems)
        //    {
        //        sb.Append(item.ToString());
        //    }

        //    return sb.ToString();
        //}
    }
}
