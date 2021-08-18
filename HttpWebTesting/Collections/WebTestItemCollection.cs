using Newtonsoft.Json;
using HttpWebTesting.WebTestItems;

namespace HttpWebTesting.Collections
{

    [JsonObject]
    public class WebTestItemCollection : BaseCollection<WebTestItem>
    {
        public WebTestItemCollection() { }
    }
}
