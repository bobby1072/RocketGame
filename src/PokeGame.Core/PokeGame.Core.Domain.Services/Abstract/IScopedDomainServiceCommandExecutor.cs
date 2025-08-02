
namespace PokeGame.Core.Domain.Services.Abstract;

internal interface IScopedDomainServiceCommandExecutor
{
    Task RunCommandAsync<TCommand, TInput>(TInput input) where TCommand : IDomainCommand<TInput>;

    Task<TReturn> RunCommandAsync<TCommand, TInput, TReturn>(TInput input)
        where TCommand : IDomainCommand<TInput, TReturn>;
}