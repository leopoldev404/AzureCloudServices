using System.Runtime.Serialization;

namespace AzureCloudServices.WebApi.Controllers.AzureServiceBus.ViewModels
{
    public class ServiceBusEntryViewModel
    {
        [DataMember(Name = "id")] public string Id { get; set; }
        [DataMember(Name = "text")] public string Text { get; set; }
    }
}