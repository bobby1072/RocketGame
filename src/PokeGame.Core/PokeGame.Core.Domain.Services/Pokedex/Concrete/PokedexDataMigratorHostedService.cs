using System.Text.Json;
using BT.Common.FastArray.Proto;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PokeGame.Core.Common;
using PokeGame.Core.Domain.Services.Abstract;
using PokeGame.Core.Domain.Services.Pokedex.Commands;
using PokeGame.Core.Persistence.Migrations.Abstract;
using PokeGame.Core.Schemas;
using PokeGame.Core.Schemas.Extensions;

namespace PokeGame.Core.Domain.Services.Pokedex.Concrete;

internal sealed class PokedexDataMigratorHostedService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IDatabaseMigratorHealthCheck _databaseMigratorHealthCheck;
    private readonly JsonDocument _pokedexJsonFile;
    private readonly ILogger<PokedexDataMigratorHostedService> _logger;

    public PokedexDataMigratorHostedService(
        IServiceProvider serviceProvider,
        IDatabaseMigratorHealthCheck databaseMigratorHealthCheck,
        [FromKeyedServices(ServiceKeys.PokedexJsonFile)] JsonDocument pokedexJsonFile,
        ILogger<PokedexDataMigratorHostedService> logger)
    {
        _serviceProvider = serviceProvider;
        _databaseMigratorHealthCheck = databaseMigratorHealthCheck;
        _pokedexJsonFile = pokedexJsonFile;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("PokedexDataMigratorHostedService starting...");

        // Wait for database migration to complete
        while (!_databaseMigratorHealthCheck.MigrationCompleted && !stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Waiting for database migration to complete...");
            await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
        }

        if (stoppingToken.IsCancellationRequested)
        {
            _logger.LogWarning("PokedexDataMigratorHostedService was cancelled before database migration completed");
            return;
        }

        _logger.LogInformation("Database migration completed. Starting Pokedex data seeding...");

        try
        {
            await SeedPokedexDataAsync(stoppingToken);
            _logger.LogInformation("Pokedex data seeding completed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while seeding Pokedex data");
            throw;
        }
    }

    private async Task SeedPokedexDataAsync(CancellationToken cancellationToken)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var commandExecutor = scope.ServiceProvider.GetRequiredService<IDomainServiceCommandExecutor>();

        var pokedexPokemonList = _pokedexJsonFile
            .Deserialize<IReadOnlyCollection<PokedexPokemonRawJson>>()
            ?.FastArraySelect(x => x.ToRuntimeModel())
            .ToArray() ?? [];
        
        if (pokedexPokemonList.Length > 0)
        {
            await commandExecutor.RunCommandAsync<CreatePokedexPokemonCommand, IReadOnlyCollection<PokedexPokemon>, IReadOnlyCollection<PokedexPokemon>>(pokedexPokemonList);
        }
        else
        {
            throw new InvalidOperationException("No Pokemon records were parsed/found in JSON file");
        }
    }
}
