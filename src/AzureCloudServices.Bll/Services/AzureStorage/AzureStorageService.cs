using AzureCloudServices.Bll.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureCloudServices.Bll.Services.AzureStorage
{
	public class AzureStorageService : IAzureStorageService
    {
        private readonly IAzureStorageRepository _azureStorageRepository;

        public AzureStorageService(IAzureStorageRepository storageRepository)
        {
            _azureStorageRepository = storageRepository;
        }

		public async Task<string> GetBlobAsync(string name) 
			=> await _azureStorageRepository.GetBlobAsync(name);

		public async Task<IEnumerable<string>> ListBlobsAsync()
			=> await _azureStorageRepository.ListBlobsAsync();

		public async Task UploadBlobAsync(string name, string path)
			=> await _azureStorageRepository.UploadBlobAsync(name, path);

		public async Task UploadContentBlobAsync(string name, string content)
			=> await _azureStorageRepository.UploadContentBlobAsync(name, content);

		public async Task DeleteBlobAsync(string name)
			=> await _azureStorageRepository.DeleteBlobAsync(name);
	}
}
