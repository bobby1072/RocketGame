using System.Linq.Expressions;
using BT.Common.OperationTimer.Proto;
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


    public async Task RunCommandAsync<TCommand, TInput>(TInput input) where TCommand : IDomainCommand<TInput>
    {
        var foundCommand = _serviceProvider.GetRequiredService<TCommand>();
     
        _logger.LogInformation("Attempting to execute {CommandName}", foundCommand.CommandName);
        
        var timeTaken = await OperationTimerUtils.TimeAsync(() => foundCommand.ExecuteAsync(input));
        
        _logger.LogInformation("Executed {CommandName} in {TimeTaken}ms", foundCommand.CommandName, timeTaken.Milliseconds);
    }
    public async Task<TReturn> RunCommandAsync<TCommand, TInput, TReturn>(TInput input) where TCommand : IDomainCommand<TInput, TReturn>
    {
        var foundCommand = _serviceProvider.GetRequiredService<TCommand>();

        _logger.LogInformation("Attempting to execute {CommandName}", foundCommand.CommandName);
        
        var (timeTaken, result) = await OperationTimerUtils.TimeWithResultsAsync(() => foundCommand.ExecuteAsync(input));
        
        _logger.LogInformation("Executed {CommandName} in {TimeTaken}ms", foundCommand.CommandName, timeTaken.Milliseconds);

        return result;
    }
}