using BT.Common.Persistence.Shared.Entities;
using PokeGame.Core.Schemas;

namespace PokeGame.Core.Persistence.Entities;

public abstract class BasePokeGameEntity<TId, TRuntime> : BaseEntity<TId, TRuntime> where TRuntime: PersistableDomainModel<TRuntime, TId> { }