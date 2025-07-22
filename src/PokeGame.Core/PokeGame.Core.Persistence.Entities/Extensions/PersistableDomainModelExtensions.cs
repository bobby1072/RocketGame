using PokeGame.Core.Schemas;

namespace PokeGame.Core.Persistence.Entities.Extensions;

internal static class PersistableDomainModelExtensions
{
    public static PokedexPokemonEntity ToEntity(this PokedexPokemon pokemon)
    {
        return new PokedexPokemonEntity
        {
            Id = pokemon.Id,
            Attack = pokemon.Stats.Attack,
            Defense = pokemon.Stats.Defense,
            Speed = pokemon.Stats.Speed,
            SpecialAttack = pokemon.Stats.SpecialAttack,
            SpecialDefense = pokemon.Stats.SpecialDefense,
            Hp = pokemon.Stats.Hp,
            Type1 = pokemon.Type.Type1.ToString(),
            Type2 = pokemon.Type.Type2?.ToString(),
            ChineseName = pokemon.ChineseName,
            EnglishName = pokemon.EnglishName,
            FrenchName = pokemon.FrenchName,
            JapaneseName = pokemon.JapaneseName
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