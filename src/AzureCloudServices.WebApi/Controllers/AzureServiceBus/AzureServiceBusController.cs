using System.Threading.Tasks;
using AzureCloudServices.Bll.Services.AzureServiceBus;
using AzureCloudServices.Bll.Services.Logging;
using AzureCloudServices.Bll.Utils;
using AzureCloudServices.WebApi.Controllers.AzureServiceBus.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AzureCloudServices.WebApi.Controllers.AzureServiceBus
{
    [ApiController]
    [Route("api/v1/servicebus")]
    public class AzureServiceBusController : ControllerBase
    {
        private readonly IAzureServiceBusService _azureServiceBusService;
        private readonly ILogger _logger;
        
        public AzureServiceBusController(IAzureServiceBusService azureServiceBusService, ILogger logger)
        {
            _azureServiceBusService = azureServiceBusService;
            _logger = logger;
        }
        
        [HttpPost]
        public async Task<IActionResult> Send(ServiceBusEntryViewModel entry)
        {
            var json = entry.ToJson();
            _logger.Log(json);

            var obj = json.ToObject<ServiceBusEntryViewModel>();
            _logger.Log(obj.Id);

            await _azureServiceBusService.SendMessage(json);
            return Ok($"Message with Id: {obj.Id} has been delivered");
        }
    }
}