using BT.Common.Persistence.Shared.Utils;
using Microsoft.Extensions.Logging;
using PokeGame.Core.Common.Exceptions;
using PokeGame.Core.Domain.Services.Abstract;
using PokeGame.Core.Persistence.Repositories.Abstract;
using PokeGame.Core.Schemas;

namespace PokeGame.Core.Domain.Services.Pokedex.Commands;

internal sealed class CreatePokedexPokemonCommand: IDomainCommand<IReadOnlyCollection<PokedexPokemon>, IReadOnlyCollection<PokedexPokemon>>
{
    public string CommandName => nameof(CreatePokedexPokemonCommand);
    private readonly IPokedexPokemonRepository _pokedexPokemonRepository;
    private readonly ILogger<CreatePokedexPokemonCommand> _logger;

    public CreatePokedexPokemonCommand(
        IPokedexPokemonRepository pokedexPokemonRepository,
        ILogger<CreatePokedexPokemonCommand> logger
    )
    {
        _pokedexPokemonRepository = pokedexPokemonRepository;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<PokedexPokemon>> ExecuteAsync(IReadOnlyCollection<PokedexPokemon> input)
    {
        _logger.LogInformation("About to create {PokedexPokemonSaveCount} pokedex pokemon records...", input.Count);
        
        _logger.LogDebug("Pokedex pokemon records to be created: {@CreationArray}", input);

        var saveResult = await
            EntityFrameworkUtils.TryDbOperation(() => _pokedexPokemonRepository.Create(input), _logger)
                ?? throw new PokeGameApiServerException("Failed to create pokedex pokemon");

        if (saveResult.IsSuccessful != true || saveResult.Data.Count == 0)
        {
            throw new PokeGameApiServerException("Failed to create pokedex pokemon");
        }

        return saveResult.Data;
    }
}