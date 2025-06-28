using Microsoft.Extensions.DependencyInjection;
using PokeGame.Core.Common.Services.Abstract;
using PokeGame.Core.Common.Services.Concrete;

namespace PokeGame.Core.Common.Services.Extensions;

public static class CommonServicesServiceCollectionExtensions
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICachingService, DistributedCachingService>();
        
        
        return services;
    }
}