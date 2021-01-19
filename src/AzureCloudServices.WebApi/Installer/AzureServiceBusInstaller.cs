using AzureCloudServices.Bll.Services.AzureServiceBus;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureCloudServices.WebApi.Installer
{
    public class AzureServiceBusInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var serviceBusParameters = new AzureServiceBusParameters()
            {
                ConnectionString = configuration["AzureServiceBusSettings:ConnectionString"],
                Queue = configuration["AzureServiceBusSettings:Queue"]
            };

            services.AddSingleton<IQueueClient>(new QueueClient
                (serviceBusParameters.ConnectionString, serviceBusParameters.Queue));
            services.AddSingleton(sp => serviceBusParameters);
            services.AddSingleton<IAzureServiceBusService, AzureServiceBusService>();
        }
    }
}