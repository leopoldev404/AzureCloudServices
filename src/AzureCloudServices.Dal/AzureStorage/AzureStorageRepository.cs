using System;
using Azure.Storage.Blobs;
using AzureCloudServices.Bll.Abstractions;
using AzureCloudServices.Bll.Services.Logging;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AzureCloudServices.Dal.AzureStorage
{
	public class AzureStorageRepository : IAzureStorageRepository
	{
		private readonly ILogger _logger;
		private readonly AzureStorageRepositoryParameters _repositoryParameters;
		private readonly BlobContainerClient _containerClient;
		

		public AzureStorageRepository(ILogger logger, BlobServiceClient client, AzureStorageRepositoryParameters repositoryParameters)
		{
			_logger = logger;
			_repositoryParameters = repositoryParameters;
			_containerClient = client.GetBlobContainerClient(repositoryParameters.Container);
		}

		public async Task<string> GetBlobAsync(string name)
		{
			try
			{
				var client = _containerClient.GetBlobClient(name);
				var download = await client.DownloadAsync();
				using var stream = new StreamReader(download.Value.Content);
				return await stream.ReadToEndAsync();
			}
			catch (Exception ex) { return null; }
		}

		public async Task<IEnumerable<string>> ListBlobsAsync()
		{
			var items = new List<string>();

			await foreach (var item in _containerClient.GetBlobsAsync())
			{
				items.Add(item.Name);
			}
			return items;
		}

		public Task UploadBlobAsync(string name, string path)
		{
			throw new System.NotImplementedException();
		}

		public Task UploadContentBlobAsync(string name, string content)
		{
			throw new System.NotImplementedException();
		}

		public Task DeleteBlobAsync(string name)
		{
			throw new System.NotImplementedException();
		}
	}
}
