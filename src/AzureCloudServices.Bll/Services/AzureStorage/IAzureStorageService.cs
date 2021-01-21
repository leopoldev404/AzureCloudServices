using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureCloudServices.Bll.Services.AzureStorage
{
    public interface IAzureStorageService
    {
        Task<string> GetBlobAsync(string name);
        Task<IEnumerable<string>> ListBlobsAsync();
        Task UploadBlobAsync(string name, string path);
        Task UpdateBlobContentAsync(string name, string content);
        Task DeleteBlobAsync(string name);
    }
}
