using Microsoft.Extensions.Logging;
using PokeGame.Core.Domain.Services.Abstract;
using PokeGame.Core.Domain.Services.User.Commands;
using PokeGame.Core.Schemas.Input;

namespace PokeGame.Core.Domain.Services.User.Concrete;

internal sealed class UserProcessingManager
{
    private readonly IDomainServiceCommandExecutor _commandExecutor;
    private readonly ILogger<UserProcessingManager> _logger;
    public UserProcessingManager(IDomainServiceCommandExecutor commandExecutor, ILogger<UserProcessingManager> logger)
    {
        _commandExecutor = commandExecutor;
        _logger = logger;
    }

    public Task<Schemas.User> SaveUserAsync(SaveUserInput input) => _commandExecutor
        .RunCommandAsync<SaveUserCommand, SaveUserInput, Schemas.User>(input);
}