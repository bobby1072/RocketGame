using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PokeGame.Core.Domain.Models.Validators;

namespace PokeGame.Core.Domain.Models.Extensions;

public static class DomainModelServiceCollectionExtensions
{
    public static IServiceCollection AddDomainModelValidators(this IServiceCollection services)
    {
        services
            .AddSingleton<IValidator<User>, UserValidator>();
        
        return services;
    }
}