namespace PokeGame.Core.Domain.Services.Abstract;

public interface IDomainCommand
{
    public string CommandName { get; }
}

public interface IDomainCommand<in TInput> : IDomainCommand
{
    public Task ExecuteAsync(TInput input);
}

public interface IDomainCommand<in TInput, TOutput> : IDomainCommand
{
    public Task<TOutput> ExecuteAsync(TInput input);
}