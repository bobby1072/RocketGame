using System.Text.Json;

namespace PokeGame.Core.Common.Helpers;

internal static class PokedexJsonFileHelper
{
    public static async Task<JsonDocument> GetFromDataFolder(string? path = null)
    {
        var pathToUse = path ??
                        $"..{Path.DirectorySeparatorChar}PokeGame.Core.Common{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}Pokedex.json";
        
        var readJson = await File
            .ReadAllTextAsync(Path
                .GetFullPath(pathToUse)
            );

        return JsonDocument.Parse(readJson);
    }
}