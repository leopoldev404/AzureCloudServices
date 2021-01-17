using System.Threading.Tasks;
using AzureCloudServices.Bll.Abstractions;

namespace AzureCloudServices.Bll.Services.AzureRedisCache
{
    public class AzureRedisCacheService : IAzureRedisCacheService
    {
        private readonly IAzureRedisCacheRepository _azureRedisCacheRepository;

        public AzureRedisCacheService(IAzureRedisCacheRepository azureRedisCacheRepository)
        {
            _azureRedisCacheRepository = azureRedisCacheRepository;
        }

        public async Task<string> GetCacheItem(string key)
            => await _azureRedisCacheRepository.GetCacheItem(key);

        public async Task CreateCacheItem(string key, string value)
            => await _azureRedisCacheRepository.CreateCacheItem(key, value);
    }
}