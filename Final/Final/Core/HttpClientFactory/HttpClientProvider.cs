using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace Final.Core.HttpClientFactory
{
    public class HttpClientProvider
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public HttpClientProvider(TestConfiguration config)
        {

            _httpClient.BaseAddress = new Uri(config.BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.Token);


        }

        public static HttpClient Client => _httpClient;
    }
}
