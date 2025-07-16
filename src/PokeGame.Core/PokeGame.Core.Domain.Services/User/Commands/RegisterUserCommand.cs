using System.Net;
using FluentValidation;
using Microsoft.Extensions.Logging;
using PokeGame.Core.Common.Exceptions;
using PokeGame.Core.Domain.Models.Input;
using PokeGame.Core.Domain.Services.Abstract;
using PokeGame.Core.Persistence.Repositories.Abstract;

namespace PokeGame.Core.Domain.Services.User.Commands;

public sealed class RegisterUserCommand: IDomainCommand<RegisterUserInput, Domain.Models.User>
{
    public string CommandName => nameof(RegisterUserCommand);
    private readonly IUserRepository _userRepository;
    private readonly IValidator<Domain.Models.User> _validator;
    private readonly ILogger<RegisterUserCommand> _logger;
    public RegisterUserCommand(IUserRepository userRepository, IValidator<Domain.Models.User> validator, ILogger<RegisterUserCommand> logger)
    {
        _userRepository = userRepository;
        _validator = validator;
        _logger = logger;
    }
    
    
    public async Task<Domain.Models.User> ExecuteAsync(RegisterUserInput input)
    {
        _logger.LogInformation("About to attempt to register user with name: {Name}...", input.Name);

        var parsedUser = input.ToUserModel();
        var validationResult = await _validator.ValidateAsync(parsedUser);

        if (!validationResult.IsValid)
        {
            throw new PokeGameApiUserException(HttpStatusCode.BadRequest, "Invalid email address");
        }
        
        var createdUser = await _userRepository.Create(parsedUser);

        if (!createdUser.IsSuccessful || createdUser.Data.Count == 0)
        {
            throw new PokeGameApiServerException("Failed to register user");
        }
        
        return createdUser.Data.First();
    }
}