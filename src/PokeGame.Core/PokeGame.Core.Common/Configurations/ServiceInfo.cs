namespace PokeGame.Core.Common.Configurations;

public sealed record ServiceInfo
{
    public static readonly string Key = nameof(ServiceInfo);
    
    public required string ReleaseName { get; init; }
    
    public required string ReleaseVersion { get; init; }
}