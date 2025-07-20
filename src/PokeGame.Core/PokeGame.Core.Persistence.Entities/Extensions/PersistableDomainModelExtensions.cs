using PokeGame.Core.Schemas;

namespace PokeGame.Core.Persistence.Entities.Extensions;

internal static class PersistableDomainModelExtensions
{
    public static PokedexPokemonEntity ToEntity(this PokedexPokemon pokemon)
    {
        return new PokedexPokemonEntity
        {
            Id = pokemon.Id,
            PokemonJson = pokemon.ToJsonType()
        };
    }
    
    public static UserEntity ToEntity(this User runtimeObj)
    {
        return new UserEntity
        {
            Id = runtimeObj.Id,
            Email = runtimeObj.Email,
            Name = runtimeObj.Name,
            DateCreated = runtimeObj.DateCreated,
            DateModified = runtimeObj.DateModified,
        };
    }
}