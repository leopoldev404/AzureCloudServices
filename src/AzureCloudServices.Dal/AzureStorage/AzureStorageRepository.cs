using System;
using Azure.Storage.Blobs;
using AzureCloudServices.Bll.Abstractions;
using AzureCloudServices.Bll.Services.Logging;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

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
			catch (Exception ex)
			{
				_logger.Log(ex);
				return null;
			}
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

		public async Task UploadBlobAsync(string name, string path)
		{
			var blobClient = _containerClient.GetBlobClient(name);
			await blobClient.UploadAsync(path, new BlobHttpHeaders { ContentType = "application/octet-stream" });
		}

		public async Task UpdateBlobContentAsync(string name, string content)
		{
			var blobClient = _containerClient.GetBlobClient(name);
			var bytes = Encoding.UTF8.GetBytes(content);
			await using var stream = new MemoryStream(bytes);
			await blobClient.UploadAsync(stream, new BlobHttpHeaders {ContentType = "application/octet-stream"});
		}

		public async Task DeleteBlobAsync(string name)
		{
			var client = _containerClient.GetBlobClient(name);
			await client.DeleteIfExistsAsync();
		}
	}
}