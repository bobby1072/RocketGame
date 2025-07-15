namespace PokeGame.Core.Domain.Models.Input;

public sealed record RegisterUserInput
{
    public required string Email { get; set; }
    public required string Name { get; set; }
}