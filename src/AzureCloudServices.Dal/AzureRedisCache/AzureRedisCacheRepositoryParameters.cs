using StackExchange.Redis;

namespace AzureCloudServices.Dal.AzureRedisCache
{
    public class AzureRedisCacheRepositoryParameters
    {
        public string ConnectionString { get; set; }
        public int DatabaseId { get; set; }
    }
}