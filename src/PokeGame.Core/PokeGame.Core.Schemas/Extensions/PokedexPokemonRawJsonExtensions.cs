using BT.Common.FastArray.Proto;

namespace PokeGame.Core.Schemas.Extensions;

public static class PokedexPokemonRawJsonExtensions
{
    public static PokedexPokemon ToRuntimeModel(this PokedexPokemonRawJson pokedexPokemonRawJson)
    {
        return new PokedexPokemon
        {
            Id = pokedexPokemonRawJson.Id,
            EnglishName = pokedexPokemonRawJson.Name.English,
            FrenchName = pokedexPokemonRawJson.Name.French,
            ChineseName = pokedexPokemonRawJson.Name.Chinese,
            JapaneseName = pokedexPokemonRawJson.Name.Japanese,
            Stats = pokedexPokemonRawJson.Base.ToRuntimeModel(),
            Type = new PokedexPokemonType
            {
                Type1 = Enum.Parse<PokemonType>(pokedexPokemonRawJson.Type.FastArrayFirst()),
                Type2 = Enum.Parse<PokemonType>(pokedexPokemonRawJson.Type.FastArraySecond()),
            }
        };
    }
    
    
    public static PokedexPokemonStats ToRuntimeModel(this PokedexPokemonStatsRawJson pokedexPokemonStatsRawJson)
    {
        return new PokedexPokemonStats
        {
            Hp = pokedexPokemonStatsRawJson.Hp,
            Attack = pokedexPokemonStatsRawJson.Attack,
            Defense = pokedexPokemonStatsRawJson.Defense,
            Speed = pokedexPokemonStatsRawJson.Speed,
            SpecialAttack = pokedexPokemonStatsRawJson.SpecialAttack,
            SpecialDefense = pokedexPokemonStatsRawJson.SpecialDefense,
        };
    }
}