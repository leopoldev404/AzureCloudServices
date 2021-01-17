using System.Threading.Tasks;

namespace AzureCloudServices.Bll.Abstractions
{
    public interface IAzureRedisCacheRepository
    {
        Task<string> GetCacheItem(string key);
        Task CreateCacheItem(string key, string value);
    }
}