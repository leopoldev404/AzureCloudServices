using System;
using System.Threading.Tasks;
using AzureCloudServices.Bll.Services.AzureRedisCache;
using AzureCloudServices.Bll.Services.Logging;
using AzureCloudServices.WebApi.Controllers.AzureRedisCache.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AzureCloudServices.WebApi.Controllers.AzureRedisCache
{
    [ApiController]
    [Route("api/v1/cache")]
    public class AzureRedisCacheExplorerController : ControllerBase
    {
        private readonly IAzureRedisCacheService _azureRedisCacheService;
        private readonly ILogger _logger;

        public AzureRedisCacheExplorerController(IAzureRedisCacheService azureRedisCacheService, ILogger logger)
        {
            _azureRedisCacheService = azureRedisCacheService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetRedisCacheValue(string key)
        {
            _logger.Log($"getting item by key {key}");
            var res = await _azureRedisCacheService.GetCacheItem(key);
            return !string.IsNullOrEmpty(res) ? Ok(res) : NotFound();
        }
        
        [HttpPost]
        public async Task<IActionResult> GetRedisCacheValue(NewCacheEntryViewModel entry)
        {
            _logger.Log($"getting item by key {entry.Key} and value {entry.Value}");
            await _azureRedisCacheService.CreateCacheItem(entry.Key, entry.Value);
            return Created("Created new cache item", entry);
        }
    }
}