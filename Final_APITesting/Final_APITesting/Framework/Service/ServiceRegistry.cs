using Final_APITesting.Framework.HttpClientFactory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_APITesting.Framework.Service
{
    public static class ServiceRegistry
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var testConfig = configuration.GetSection("TestConfiguration").Get<TestConfiguration>();
            services.AddSingleton(testConfig);
            services.AddSingleton(provider => new HttpClientProvider(testConfig));

            return services;
        }
    }
}
