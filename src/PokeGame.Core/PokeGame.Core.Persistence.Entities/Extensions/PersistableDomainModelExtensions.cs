using PokeGame.Core.Domain.Models;

namespace PokeGame.Core.Persistence.Entities.Extensions;

internal static class PersistableDomainModelExtensions
{
    public static UserEntity ToEntity(this User runtimeObj)
    {
        return new UserEntity
        {
            Id = runtimeObj.Id,
            Email = runtimeObj.Email,
            Name = runtimeObj.Name,
            DateCreated = runtimeObj.DateCreated,
            DateModified = runtimeObj.DateModified,
        };
    }
}