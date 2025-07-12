using Microsoft.EntityFrameworkCore;

namespace PokeGame.Core.Persistence.Contexts;

public sealed class PokeGameContext: DbContext
{
    public PokeGameContext(DbContextOptions<PokeGameContext> options) : base(options) {}
}