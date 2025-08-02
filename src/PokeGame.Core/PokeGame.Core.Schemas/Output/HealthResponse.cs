using PokeGame.Core.Common.Configurations;

namespace PokeGame.Core.Schemas.Output;

public sealed record HealthResponse
{
    public required ServiceInfo ServiceInfo { get; init; }
    public DateTime CurrentLocalTime => DateTime.Now.ToLocalTime();
}