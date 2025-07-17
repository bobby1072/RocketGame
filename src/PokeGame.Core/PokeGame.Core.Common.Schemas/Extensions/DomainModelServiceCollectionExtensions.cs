using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PokeGame.Core.Common.Schemas.Validators;

namespace PokeGame.Core.Common.Schemas.Extensions;

public static class DomainModelServiceCollectionExtensions
{
    public static IServiceCollection AddDomainModelValidators(this IServiceCollection services)
    {
        services
            .AddSingleton<IValidator<User>, UserValidator>();
        
        return services;
    }
}