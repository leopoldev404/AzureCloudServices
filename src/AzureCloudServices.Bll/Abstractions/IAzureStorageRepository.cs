using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureCloudServices.Bll.Abstractions
{
	public interface IAzureStorageRepository
    {
        Task<string> GetBlobAsync(string name);
        Task<IEnumerable<string>> ListBlobsAsync();
        Task UploadBlobAsync(string name, string path);
        Task UpdateBlobContentAsync(string name, string content);
        Task DeleteBlobAsync(string name);
    }
}
