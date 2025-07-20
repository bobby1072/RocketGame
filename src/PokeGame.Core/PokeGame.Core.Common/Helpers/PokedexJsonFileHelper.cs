using System.Text.Json;
using PokeGame.Core.Common.Models;

namespace PokeGame.Core.Common.Helpers;

internal static class PokedexJsonFileHelper
{
    public static async Task<JsonDocument> GetFromDataFolder()
    {
        var readJson = await File.ReadAllTextAsync(Path.GetFullPath("../Data/Pokedex.json"));

        return JsonDocument.Parse(readJson);
    }
}