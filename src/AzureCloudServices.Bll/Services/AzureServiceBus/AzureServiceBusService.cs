using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace AzureCloudServices.Bll.Services.AzureServiceBus
{
    public class AzureServiceBusService : IAzureServiceBusService
    {
        private readonly IQueueClient _serviceBusClient;
        
        public AzureServiceBusService(IQueueClient serviceBusClient)
        {
            _serviceBusClient = serviceBusClient;
        }

        public async Task SendMessage(string body)
        {
            var message = new Message(Encoding.UTF8.GetBytes(body));
            await _serviceBusClient.SendAsync(message);
        }
    }
}