using System;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using Serilog;

namespace HttpWebTestingResults
{
    public class HttpWebTestResults
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime executionTime { get; set; }

        public Collection<WebTestResultsItem> webTestResultsItems { get; set; }

        public HttpWebTestResults()
        {
            webTestResultsItems = new Collection<WebTestResultsItem>();
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
    }
}
