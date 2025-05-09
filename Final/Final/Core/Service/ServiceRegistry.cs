using Microsoft.Extensions.Configuration;

namespace Final.Core.Service
{
    public static class ServiceRegistry
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var testConfig = configuration.GetSection("TestConfiguration").Get<TestConfiguration>();
            services.AddSingleton(testConfig);

            return services;
        }
    }
}
