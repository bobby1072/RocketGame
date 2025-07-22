using System.Text.Json;

namespace PokeGame.Core.Common.Helpers;

internal static class PokedexJsonFileHelper
{
    public static async Task<JsonDocument> GetFromDataFolder()
    {
        var readJson = await File
            .ReadAllTextAsync(Path
                .GetFullPath($"..{Path.DirectorySeparatorChar}PokeGame.Core.Common{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}Pokedex.json")
            );

        return JsonDocument.Parse(readJson);
    }
}