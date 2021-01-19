using System.Threading.Tasks;

namespace AzureCloudServices.Bll.Services.AzureServiceBus
{
    public interface IAzureServiceBusService
    {
        Task SendMessage(string messageBody);
    }
}