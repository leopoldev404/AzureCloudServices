using AzureCloudServices.Bll.Services.AzureStorage;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
			return response != null ? Ok(response) : NoContent();
		}

		[HttpGet("list")]
		public async Task<IActionResult> GetBlobs()
		{
			var list = await _azureStorageService.ListBlobsAsync();
			return Ok(list);
		}
	}
}
