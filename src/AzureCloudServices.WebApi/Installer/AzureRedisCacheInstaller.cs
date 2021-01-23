using AzureCloudServices.Bll.Abstractions;
using AzureCloudServices.Bll.Services.AzureRedisCache;
using AzureCloudServices.Dal.AzureRedisCache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace AzureCloudServices.WebApi.Installer
{
    public class AzureRedisCacheInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var repoParameters = new AzureRedisCacheRepositoryParameters()
            {
                DatabaseId = int.Parse(configuration["AzureRedisCacheSettings:DatabaseId"])
            };

            services.AddSingleton<IConnectionMultiplexer>
                (ConnectionMultiplexer.Connect(configuration["AzureRedisCacheSettings:ConnectionString"]));
            services.AddSingleton(repoParameters);
            services.AddSingleton<IAzureRedisCacheService, AzureRedisCacheService>();
            services.AddSingleton<IAzureRedisCacheRepository, AzureRedisCacheRepository>();
        }
    }
}