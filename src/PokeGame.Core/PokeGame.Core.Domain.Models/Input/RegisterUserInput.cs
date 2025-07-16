namespace PokeGame.Core.Domain.Models.Input;

public sealed class RegisterUserInput
{
    public required string Email { get; set; }
    public required string Name { get; set; }


    public User ToUserModel() =>
        new()
        {
            Email = Email,
            Name = Name,
        };
}