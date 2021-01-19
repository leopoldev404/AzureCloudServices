using System.Collections.Generic;
using System.Text.Unicode;
using System.Threading.Tasks;
using AzureCloudServices.Bll.Services.AzureServiceBus;
using AzureCloudServices.Bll.Services.Logging;
using AzureCloudServices.Bll.Utils;
using AzureCloudServices.WebApi.Controllers.AzureServiceBus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Amqp.Serialization;

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
            
            await _azureServiceBusService.SendMessage(json);
            return Ok();
        }
    }
}