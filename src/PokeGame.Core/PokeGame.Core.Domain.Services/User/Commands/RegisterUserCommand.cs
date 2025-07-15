using Microsoft.Extensions.Logging;
using PokeGame.Core.Domain.Models.Input;
using PokeGame.Core.Domain.Services.Abstract;
using PokeGame.Core.Persistence.Repositories.Abstract;

namespace PokeGame.Core.Domain.Services.User.Commands;

public sealed class RegisterUserCommand: IDomainCommand<RegisterUserInput, Domain.Models.User>
{
    public string CommandName => nameof(RegisterUserCommand);
    private readonly IUserRepository _userRepository;
    private readonly ILogger<RegisterUserCommand> _logger;
    public RegisterUserCommand(IUserRepository userRepository, ILogger<RegisterUserCommand> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }
    
    
    public Task<Domain.Models.User> ExecuteAsync(RegisterUserInput input)
    {
        throw new NotImplementedException();
    }
}