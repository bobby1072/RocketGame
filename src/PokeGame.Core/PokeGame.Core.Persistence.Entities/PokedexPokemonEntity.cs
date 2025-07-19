using System.Text.Json;
using BT.Common.Persistence.Shared.Entities;
using PokeGame.Core.Schemas;

namespace PokeGame.Core.Persistence.Entities;

public sealed class PokedexPokemonEntity: BaseEntity<int, PokedexPokemon>
{
    public required JsonDocument PokemonJson { get; init; }
}