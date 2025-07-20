using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PokeGame.Core.Persistence.Migrations.Abstract;

public interface IDatabaseMigratorHealthCheck: IHealthCheck
{
    bool MigrationCompleted { get; set; }
}