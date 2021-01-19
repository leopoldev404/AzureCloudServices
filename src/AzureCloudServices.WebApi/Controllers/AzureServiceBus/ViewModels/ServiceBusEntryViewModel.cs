using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AzureCloudServices.WebApi.Controllers.AzureServiceBus.ViewModels
{
    [DataContract]
    public class ServiceBusEntryViewModel
    {
        [Required]
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [Required]
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}