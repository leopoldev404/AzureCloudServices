using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace AzureCloudServices.Bll.Services.AzureServiceBus
{
    public class AzureServiceBusService : IAzureServiceBusService
    {
        private readonly IQueueClient _serviceBusClient;
        private readonly AzureServiceBusParameters _azureServiceBusParameters;

        public AzureServiceBusService(IQueueClient serviceBusClient, AzureServiceBusParameters azureServiceBusParameters)
        {
            _serviceBusClient = serviceBusClient;
            _azureServiceBusParameters = azureServiceBusParameters;
        }

        public async Task SendMessage(string body)
        {
            var message = new Message(Encoding.UTF8.GetBytes(body));
            await _serviceBusClient.SendAsync(message);
        }
    }
}