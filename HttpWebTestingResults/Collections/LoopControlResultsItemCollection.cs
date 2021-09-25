using Newtonsoft.Json;
using HttpWebTesting.WebTestItems;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HttpWebTestingResults
{

    public class LoopControlResultsItemCollection
    {
        [JsonProperty(PropertyName = "LoopResultsItems")]
        public Dictionary<string, WebTestResultsItemCollection> loopResultsItems { get; set; }


        public LoopControlResultsItemCollection() 
        {
            loopResultsItems = new Dictionary<string, WebTestResultsItemCollection>();
        }

        public Collection<WebTestResultsItem> GetResultsListForIteration(string iteration)
        {
            if (loopResultsItems.ContainsKey(iteration))
                return loopResultsItems[iteration];
            else
                return new WebTestResultsItemCollection();
        }

        public void Add(string iteration, WebTestResultsItemCollection items)
        {
            loopResultsItems.Add(iteration, items);
        }
    }
}
