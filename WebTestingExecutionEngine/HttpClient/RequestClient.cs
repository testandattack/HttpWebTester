using Serilog;
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
            try
            {
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                client.Timeout = new TimeSpan(0, 0, 30);

                if (request.Method == HttpMethod.Post)
                {
                    var httpResponse = client.PostAsync(request.RequestUri, request.Content);
                    return await httpResponse;
                }
                else if (request.Method == HttpMethod.Get)
                {
                    var httpResponse = client.GetAsync(request.RequestUri);
                    return await httpResponse;
                }
                else if (request.Method == HttpMethod.Put)
                {
                    var httpResponse = client.PutAsync(request.RequestUri, request.Content);
                    return await httpResponse;
                }
                else if (request.Method == HttpMethod.Delete)
                {
                    var httpResponse = client.DeleteAsync(request.RequestUri);
                    return await httpResponse;
                }
                else if (request.Method == HttpMethod.Patch)
                {
                    var httpResponse = client.PatchAsync(request.RequestUri, request.Content);
                    return await httpResponse;
                }
            }
            catch (Exception ex)
            {
                Log.ForContext("SourceContext", "RequestClient").Error(ex, "exception executing request", request.RequestUri.GetLeftPart(UriPartial.Path));
            }
            return null;
        }
    }
}
