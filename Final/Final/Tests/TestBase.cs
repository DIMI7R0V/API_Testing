using Final.Core.HttpClientFactory;

namespace Final.Tests
{
    public class TestBase
    {
        protected HttpClient Client;

        [SetUp]
        public void Setup()
        {
            Client = HttpClientProvider.Client;
        }
    }
}
