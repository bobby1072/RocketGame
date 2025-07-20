using System.Text.Json.Serialization;

namespace PokeGame.Core.Schemas;

public sealed record PokedexPokemonStatsRawJson
{
    [JsonPropertyName("HP")]
    public required int Hp { get; set; }
    [JsonPropertyName("Attack")]
    public required int Attack { get; set; }
    [JsonPropertyName("Defense")]
    public required int Defense { get; set; }
    [JsonPropertyName("Sp. Attack")]
    public required int SpecialAttack { get; set; }
    [JsonPropertyName("Sp. Defence")]
    public required int SpecialDefense { get; set; }
    [JsonPropertyName("Speed")]
    public required int Speed { get; set; }
}