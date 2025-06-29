using AiTrainer.Web.Persistence.Migrations.Abstract;
using AiTrainer.Web.Persistence.Migrations.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace PokeGame.Core.Persistence.Extensions;

public static class PersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddPokeGamePersistence(this IServiceCollection services)
    {
        services
            .AddSingleton<IMigrator, DatabaseMigrations>()
            .AddHostedService<DatabaseMigratorHostedService>();
        

        return services;
    }
}