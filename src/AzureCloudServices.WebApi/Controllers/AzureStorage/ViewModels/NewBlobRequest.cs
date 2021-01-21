using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureCloudServices.WebApi.Controllers.AzureStorage.ViewModels
{
    public class NewBlobRequest
    {
        [Required][JsonPropertyName("name")] public string Name { get; set; }
        [Required][JsonPropertyName("path")] public string Path { get; set; }
    }
}