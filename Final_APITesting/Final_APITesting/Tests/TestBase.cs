using Final_APITesting.Framework.HttpClientFactory;
using Final_APITesting.Framework.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Final_APITesting.Tests
{
    public class TestBase
    {
        protected HttpClient Client;
        private ServiceProvider _serviceProvider;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false)
                .Build();

            var services = new ServiceCollection();
            services.RegisterServices(configuration);
            _serviceProvider = services.BuildServiceProvider();

            var httpClientProvider = _serviceProvider.GetRequiredService<HttpClientProvider>();
            Client = httpClientProvider.Client;
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            if (_serviceProvider != null)
            {
                _serviceProvider.Dispose();
            }
        }
    }
}
