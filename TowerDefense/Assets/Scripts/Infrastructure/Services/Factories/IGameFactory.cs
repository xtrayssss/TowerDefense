using Infrastructure.GameState;

namespace Infrastructure.Services.Factories
{
    internal interface IGameFactory : IService
    {
        public IUnitFactory UnitFactory { get; set; }
        public IEnemySpawnerFactory EnemySpawners { get; set; }
    }
}