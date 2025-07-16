using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokeGame.Core.Common.Configurations;
using PokeGame.Core.Common.Extensions;
using PokeGame.Core.Common.Services.Extensions;
using PokeGame.Core.Domain.Models.Extensions;
using PokeGame.Core.Domain.Models.Input;
using PokeGame.Core.Domain.Services.Abstract;
using PokeGame.Core.Domain.Services.User.Commands;
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
            .AddHttpClient()
            .AddLogging()
            // .AddDistributedMemoryCache()
            .AddCommonServices()
            .AddDomainModelValidators()
            .AddPokeGamePersistence(configuration, environment.IsDevelopment())
            .ConfigureSingletonOptions<ServiceInfo>(serviceInfoSection);



        services
            .AddUserServices();

        return services;
    }

    private static IServiceCollection AddUserServices(this IServiceCollection services)
    {
        services
            .AddScoped<IDomainCommand<SaveUserInput, Domain.Models.User>, SaveUserCommand>();

        return services;
    }
}