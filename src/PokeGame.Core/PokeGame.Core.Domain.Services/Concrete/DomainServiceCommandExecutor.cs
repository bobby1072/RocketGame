using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PokeGame.Core.Domain.Services.Abstract;

namespace PokeGame.Core.Domain.Services.Concrete;

internal sealed class DomainServiceCommandExecutor: IDomainServiceCommandExecutor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<DomainServiceCommandExecutor> _logger;
    public DomainServiceCommandExecutor(IServiceProvider serviceProvider, ILogger<DomainServiceCommandExecutor> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }


    public async Task RunCommandAsync<TCommand, TInput>(Expression<Func<TCommand, Task>> commandRun) where TCommand : IDomainCommand<TInput>
    {
        var foundCommand = _serviceProvider.GetRequiredService<TCommand>();
     
        _logger.LogInformation("Attempting to execute {CommandName}", foundCommand.CommandName);

        
        await commandRun.Compile().Invoke(foundCommand);
    }
    public Task<TReturn> RunCommandAsync<TCommand, TInput, TReturn>(Expression<Func<TCommand, Task<TReturn>>> commandRun) where TCommand : IDomainCommand<TInput, TReturn>
    {
        var foundCommand = _serviceProvider.GetRequiredService<TCommand>();

        _logger.LogInformation("Attempting to execute {CommandName}", foundCommand.CommandName);
        
        return commandRun.Compile().Invoke(foundCommand);
    }
}