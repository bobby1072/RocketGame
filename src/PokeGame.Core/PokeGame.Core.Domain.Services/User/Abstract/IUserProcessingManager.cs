using PokeGame.Core.Schemas.Input;

namespace PokeGame.Core.Domain.Services.User.Abstract;

public interface IUserProcessingManager
{
    Task<Schemas.User> GetUserAsync(string email);
    Task<Schemas.User> SaveUserAsync(SaveUserInput input);
}