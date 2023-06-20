namespace Infrastructure.Services.Factories
{
    internal class GameFactory : IGameFactory
    {
        public IUnitFactory UnitFactory { get; set; }
        public IEnemySpawnerFactory EnemySpawners { get; set; }
    }
}