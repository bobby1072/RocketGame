using System.Text.Json;

namespace PokeGame.Core.Common.Models;

public sealed record PokedexJsonFile
{
    public JsonDocument Data { get; init; }
}