using System.Threading.Tasks;
using AzureCloudServices.Bll.Abstractions;
using StackExchange.Redis;

namespace AzureCloudServices.Dal.AzureRedisCache
{
    public class AzureRedisCacheRepository : IAzureRedisCacheRepository
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly AzureRedisCacheRepositoryParameters _repositoryParameters;
        
        public AzureRedisCacheRepository(IConnectionMultiplexer connectionMultiplexer, AzureRedisCacheRepositoryParameters repositoryParameters)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _repositoryParameters = repositoryParameters;
        }
        
        public async Task<string> GetCacheItem(string key)
        {
            var db = _connectionMultiplexer.GetDatabase(_repositoryParameters.DatabaseId);
            return await db.StringGetAsync(key);
        }

        public async Task CreateCacheItem(string key, string value)
        {
            var db = _connectionMultiplexer.GetDatabase(_repositoryParameters.DatabaseId);
            await db.StringSetAsync(key, value);
        }
    }
}