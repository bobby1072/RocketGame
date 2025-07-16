namespace PokeGame.Core.Domain.Services.Abstract;

internal interface IDomainCommand
{
    public string CommandName { get; }
}

internal interface IDomainCommand<in TInput> : IDomainCommand
{
    public Task ExecuteAsync(TInput input);
}

internal interface IDomainCommand<in TInput, TOutput> : IDomainCommand
{
    public Task<TOutput> ExecuteAsync(TInput input);
}