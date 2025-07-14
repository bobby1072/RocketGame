namespace PokeGame.Core.Domain.Models;

public abstract class DomainModel { }

public abstract class DomainModel<TSelf>: DomainModel, IEquatable<TSelf> where TSelf : DomainModel
{
    public abstract bool Equals(TSelf? other);    
}