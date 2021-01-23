using Azure.Storage.Blobs;

namespace AzureCloudServices.Dal.AzureStorage
{
	public class AzureStorageRepositoryParameters
	{
		public BlobServiceClient Client { get; set; }
		public string Container { get; set; }
	}
}
