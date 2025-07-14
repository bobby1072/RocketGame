using Microsoft.EntityFrameworkCore;
using PokeGame.Core.Persistence.Entities;

namespace PokeGame.Core.Persistence.Contexts;

internal sealed class PokeGameContext: DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public PokeGameContext(DbContextOptions<PokeGameContext> options) : base(options) {}
}