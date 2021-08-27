using System;
using System.Collections.ObjectModel;

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
            throw new NotImplementedException();
        }
    }
}
