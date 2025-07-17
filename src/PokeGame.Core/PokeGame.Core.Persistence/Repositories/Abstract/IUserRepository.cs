using BT.Common.Persistence.Shared.Repositories.Abstract;
using PokeGame.Core.Common.Schemas;
using PokeGame.Core.Persistence.Entities;

namespace PokeGame.Core.Persistence.Repositories.Abstract;

public interface IUserRepository : IRepository<UserEntity, Guid?, User>
{ }