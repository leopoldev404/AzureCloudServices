using Azure.Storage.Blobs;
using AzureCloudServices.Bll.Abstractions;
using AzureCloudServices.Bll.Services.AzureStorage;
using AzureCloudServices.Dal.AzureStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AzureCloudServices.WebApi.Installer
{
	public class AzureStorageInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			var repoStorageParameters = new AzureStorageRepositoryParameters()
			{
				ConnecitonString = configuration["AzureStorageRepositorySettings:ConnectionString"],
				Container = configuration["AzureStorageRepositorySettings:Container"]
			};

			services.AddSingleton(sp => new BlobServiceClient
				(repoStorageParameters.ConnecitonString));

			services.AddSingleton(sp => repoStorageParameters);
			services.AddSingleton<IAzureStorageService, AzureStorageService>();
			services.AddSingleton<IAzureStorageRepository, AzureStorageRepository>();
		}
	}
}
