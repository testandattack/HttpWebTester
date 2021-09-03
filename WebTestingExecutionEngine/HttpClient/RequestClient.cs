using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebTestExecutionEngine.HttpClient
{
    /// <summary>
    /// This class is a simple placeholder for now. As the 
    /// engine gets more advanced, this portion will eventually
    /// house a fully thread-safe reusable set of objects to
    /// allow for easy test concurrency.
    /// </summary>
    public class RequestClient
    {
        public RequestClient() { }

        public static async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            var httpResponse = client.SendAsync(request);
            return await httpResponse;
        }
    }
}
