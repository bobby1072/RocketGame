using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokeGame.Core.Common.Configurations;
using PokeGame.Core.Common.Extensions;
using PokeGame.Core.Common.Services.Extensions;
using PokeGame.Core.Persistence.Extensions;

namespace PokeGame.Core.Domain.Services.Extensions;

public static class DomainServicesServiceCollectionExtensions
{
    public static IServiceCollection AddPokeGameApplicationServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        var serviceInfoSection = configuration.GetSection(ServiceInfo.Key);

        if (!serviceInfoSection.Exists())
        {
            throw new ArgumentException("Service info section not found");
        }

        services
            .ConfigureSingletonOptions<ServiceInfo>(serviceInfoSection)
            .AddHttpClient()
            .AddLogging()
            .AddDistributedMemoryCache()
            .AddCommonServices()
            .AddPokeGamePersistence(configuration, environment.IsDevelopment());
        

        return services;
    }
}