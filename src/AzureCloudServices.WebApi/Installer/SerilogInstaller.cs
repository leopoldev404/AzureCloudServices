using AzureCloudServices.Bll.Services.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureCloudServices.WebApi.Installer
{
    public class SerilogInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ILogger>(sp => new SerilogLoggerWrapper(Serilog.Log.Logger));
        }
    }
}