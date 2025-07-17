namespace PokeGame.Core.Persistence.Migrations.Abstract
{
    internal interface IMigrator
    {
        public Task Migrate();
    }
}