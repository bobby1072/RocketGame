
namespace PokeGame.Core.Common;

public struct ExceptionConstants
{
    public const string InternalError = "An internal error occurred";
    public const string MissingEnvVars = "Missing environment variables";
}

public struct MiscConstants
{
    public const string CorrelationIdHeader = "X-Correlation-ID";
}


public struct ServiceKeys
{
    public const string PokedexJsonFile = "PokedexJsonFile";
}