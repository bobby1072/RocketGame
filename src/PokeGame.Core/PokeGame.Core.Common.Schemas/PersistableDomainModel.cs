namespace PokeGame.Core.Common.Schemas;

public abstract class PersistableDomainModel<TEquatable, TId> : DomainModel<TEquatable>
    where TEquatable : DomainModel<TEquatable>
{
    public TId Id { get; set; }
}