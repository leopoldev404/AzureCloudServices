using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace AzureCloudServices.WebApi.Controllers.AzureStorage.ViewModels
{
    public class UpdateBlobRequest
    {
        [Required][JsonPropertyName("name")] public string Name { get; set; }
        [Required][JsonPropertyName("content")] public string Content { get; set; }
    }
}