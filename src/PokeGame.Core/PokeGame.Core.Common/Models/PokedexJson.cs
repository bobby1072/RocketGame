using System.Text.Json;

namespace PokeGame.Core.Common.Models;

public sealed record PokedexJson
{
    public JsonDocument Data { get; init; }
}