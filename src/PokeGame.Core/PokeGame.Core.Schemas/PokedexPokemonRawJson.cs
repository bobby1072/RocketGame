using System.Text.Json.Serialization;
using BT.Common.FastArray.Proto;

namespace PokeGame.Core.Schemas;

public sealed record PokedexPokemonRawJson
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }
    [JsonPropertyName("name")]
    public required PokedexPokemonNameRawJson Name { get; init; }
    [JsonPropertyName("type")]
    public required IReadOnlyCollection<string> Type { get; init; }
    [JsonPropertyName("base")]
    public required PokedexPokemonStatsRawJson Base { get; init; }

    public PokedexPokemon ToRuntimeModel()
    {
        return new PokedexPokemon
        {
            Id = Id,
            EnglishName = Name.English,
            FrenchName = Name.French,
            ChineseName = Name.Chinese,
            JapaneseName = Name.Japanese,
            Stats = Base.ToRuntimeModel(),
            Type = new PokedexPokemonType
            {
                Type1 = Enum.Parse<PokemonType>(Type.First()),
                Type2 = Enum.Parse<PokemonType>(Type.FastArraySecond()),
            }
        };
    }
}