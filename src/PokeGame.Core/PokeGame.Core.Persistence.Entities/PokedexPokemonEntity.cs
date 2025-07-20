using System.ComponentModel.DataAnnotations.Schema;
using BT.Common.Persistence.Shared.Entities;
using PokeGame.Core.Schemas;
using PokeGame.Core.Schemas.Extensions;

namespace PokeGame.Core.Persistence.Entities;

[Table("pokedex", Schema = "public")]
public sealed class PokedexPokemonEntity: BaseEntity<int, PokedexPokemon>
{
    public required PokedexPokemonRawJson PokemonJson { get; init; }

    public override PokedexPokemon ToModel()
    {
        return PokemonJson.ToRuntimeModel();
    }
}