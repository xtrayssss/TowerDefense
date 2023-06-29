using System.Collections;
using System.Collections.Generic;
using Infrastructure.Installers;
using Infrastructure.Services.Coroutines;
using Infrastructure.Services.Random;
using Infrastructure.Services.StaticData;
using Leopotam.Ecs;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Enemies;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Factories
{
    internal class EnemyFactory : IEnemyFactoryService
    {
        private readonly IStaticData _staticData;
        private readonly IRandomService _randomService;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly PrefabContainer _parent;
        private readonly DiContainer _container;

        private readonly Dictionary<EnemyFactoryTypeId, IEnemyFactory> _factories =
            new Dictionary<EnemyFactoryTypeId, IEnemyFactory>();

        public EnemyFactory(IStaticData staticData, IRandomService randomService, ICoroutineRunner coroutineRunner,
            MushroomFactory.Factory mushroom, PyramidFactory.Factory pyramid, PrefabContainer parent, DiContainer container)
        {
            _staticData = staticData;
            _randomService = randomService;
            _coroutineRunner = coroutineRunner;
            _parent = parent;
            _container = container;

            MushroomFactory mushroomFactory = mushroom.Create();
            PyramidFactory pyramidFactory = pyramid.Create();

            _factories.Add(EnemyFactoryTypeId.Mushroom, mushroomFactory);
            _factories.Add(EnemyFactoryTypeId.Pyramid, pyramidFactory);
        }

        public void CreateEnemy(EcsWorld world, EnemyTypeId[] enemiesTypeId, float amountEnemies, Vector3 spawnPosition,
            EcsEntity spawnerEntity, float coolDown) =>
            _coroutineRunner.StartCoroutine(SpawnCoroutine(world, spawnerEntity, amountEnemies, enemiesTypeId,
                spawnPosition, coolDown, _container));

        private IEnumerator SpawnCoroutine(EcsWorld world, EcsEntity spawnerEntity, float amountEnemies,
            EnemyTypeId[] enemiesTypeId, Vector3 spawnPosition, float coolDown, DiContainer diContainer)
        {
            int i = 0;

            while (i < amountEnemies)
            {
                EnemyTypeId randomEnemyType = _randomService.GetRandomElement(enemiesTypeId);
                EnemyConfiguration enemyConfiguration = _staticData.GetEnemyData(randomEnemyType);

                _factories[enemyConfiguration.EnemyFactoryTypeId]
                    .SpawnEnemy(world, enemyConfiguration, spawnPosition, spawnerEntity, diContainer, _parent.transform);
                i++;

                yield return new WaitForSeconds(coolDown);
            }
        }
    }
}