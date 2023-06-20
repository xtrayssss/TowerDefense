using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    internal class EnemySpawnerFactory : IEnemySpawnerFactory
    {
        private readonly ISpawnService _spawnService;
        private IAssetProvider _assetProvider;
        private IStaticData _staticData;

        public EnemySpawnerFactory(ISpawnService spawnService) =>
            _spawnService = spawnService;

        public void CreateSpawner()
        {
            GameObject enemySpawners = _staticData.GetEnemySpawners();
         
            _spawnService.Instantiate(_assetProvider.LoadResource(AssetPaths.EnemySpawnerPath));
        }
    }
}