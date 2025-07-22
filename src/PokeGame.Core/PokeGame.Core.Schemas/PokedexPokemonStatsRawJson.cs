using System.Text.Json.Serialization;

namespace PokeGame.Core.Schemas;

public sealed record PokedexPokemonStatsRawJson
{
    [JsonPropertyName("HP")]
    public int Hp { get; init; }
    [JsonPropertyName("Attack")]
    public int Attack { get; init; }
    [JsonPropertyName("Defense")]
    public int Defense { get; init; }
    [JsonPropertyName("Sp. Attack")]
    public int SpecialAttack { get; init; }
    [JsonPropertyName("Sp. Defense")]
    public int SpecialDefense { get; init; }
    [JsonPropertyName("Speed")]
    public int Speed { get; init; }
}