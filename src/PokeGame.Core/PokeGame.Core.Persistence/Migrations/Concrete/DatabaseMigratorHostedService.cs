using AiTrainer.Web.Persistence.Migrations.Abstract;
using BT.Common.Polly.Extensions;
using Microsoft.Extensions.Hosting;
using PokeGame.Core.Persistence.Configurations;

namespace AiTrainer.Web.Persistence.Migrations.Concrete
{
    internal sealed class DatabaseMigratorHostedService : IHostedService
    {
        private readonly IEnumerable<IMigrator> _databaseMigrators;
        private readonly DbMigrationSettings _dbMigrationsConfiguration;
        public DatabaseMigratorHostedService(
            IEnumerable<IMigrator>? databaseMigrators, 
            DbMigrationSettings dbMigrationsConfiguration)
        {
            _databaseMigrators = databaseMigrators ?? new List<IMigrator>();
            _dbMigrationsConfiguration = dbMigrationsConfiguration;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(2000, cancellationToken);
            var pipeline = _dbMigrationsConfiguration.ToPipeline();
            
            await pipeline.ExecuteAsync(async _ => await Migrate(), cancellationToken);
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task Migrate()
        {
            foreach (var migrator in _databaseMigrators)
            {
                await migrator.Migrate();
            }
        }

    }
}
