namespace PokeGame.Core.Api.Models;

public record WebOutcome
{
    public string? ExceptionMessage { get; init; }
    
    public bool IsSuccess => string.IsNullOrEmpty(ExceptionMessage);
}

public sealed record WebOutcome<T>: WebOutcome
{
    public T? Data { get; init; }
}