using System.Threading.Tasks;

namespace AzureCloudServices.Bll.Services.AzureRedisCache
{
    public interface IAzureRedisCacheService
    {
        Task<string> GetCacheItem(string key);
        Task CreateCacheItem(string key, string value);
    }
}