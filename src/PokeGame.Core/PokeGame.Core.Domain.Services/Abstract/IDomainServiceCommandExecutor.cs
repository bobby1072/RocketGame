using System.Linq.Expressions;

namespace PokeGame.Core.Domain.Services.Abstract;

public interface IDomainServiceCommandExecutor
{
    Task RunCommandAsync<TCommand, TInput>(Expression<Func<TCommand, Task>> commandRun)
        where TCommand : IDomainCommand<TInput>;

    Task<TReturn> RunCommandAsync<TCommand, TInput, TReturn>(Expression<Func<TCommand, Task<TReturn>>> commandRun)
        where TCommand : IDomainCommand<TInput, TReturn>;
}