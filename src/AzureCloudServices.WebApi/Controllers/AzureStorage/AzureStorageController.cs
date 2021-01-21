using AzureCloudServices.Bll.Services.AzureStorage;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AzureCloudServices.WebApi.Controllers.AzureStorage.ViewModels;

namespace AzureCloudServices.WebApi.Controllers.AzureStorage
{
	[ApiController]
	[Route("api/v1/storage")]
	public class AzureStorageController : ControllerBase
	{
		private readonly IAzureStorageService _azureStorageService;

		public AzureStorageController(IAzureStorageService azureStorageService)
		{
			_azureStorageService = azureStorageService;
		}

		[HttpGet]
		public async Task<IActionResult> Get(string name)
		{
			var response = await _azureStorageService.GetBlobAsync(name);
			return response != null ? Ok(response) : NotFound();
		}

		[HttpGet("list")]
		public async Task<IActionResult> GetBlobs()
		{
			var blobs = await _azureStorageService.ListBlobsAsync();
			return Ok(blobs);
		}
		
		[HttpPost]
		public async Task<IActionResult> CreateBlob(NewBlobRequest entry)
		{
			await _azureStorageService.UploadBlobAsync(entry.Name, entry.Path);
			return Ok();
		}

		[HttpPost("update")]
		public async Task<IActionResult> UpdateBlobContent(UpdateBlobRequest entry)
		{
			await _azureStorageService.UpdateBlobContentAsync(entry.Name, entry.Content);
			return Ok();
		}
		
		[HttpDelete]
		public async Task<IActionResult> RemoveBlob(string name)
		{
			await _azureStorageService.DeleteBlobAsync(name);
			return Ok();
		}
		
		[HttpDelete("all")]
		public async Task<IActionResult> RemoveAllBlobs(string name)
		{
			var blobs = await _azureStorageService.ListBlobsAsync();
			foreach(var item in blobs)
			{
				await _azureStorageService.DeleteBlobAsync(item);
			}
			return Ok();
		}
	}
}