using Infrastructure.Services.Random;
using Infrastructure.Services.StaticData;
using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Enemies;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    internal class EnemyFactory : IEnemyFactory
    {
        private readonly IStaticData _staticData;
        private readonly IRandomService _randomService;
        private readonly IMushroomFactory _mushroomFactory;

        public EnemyFactory(IStaticData staticData, IRandomService randomService, IMushroomFactory mushroomFactory)
        {
            _staticData = staticData;
            _randomService = randomService;
            _mushroomFactory = mushroomFactory;
        }

        public void CreateEnemy(EcsWorld world, EnemyTypeId[] enemiesTypeId, float amountEnemies, Vector2 at)
        {
            for (int i = 0; i < amountEnemies; i++)
            {
                EnemyTypeId randomEnemyType = _randomService.GetRandomElement(enemiesTypeId);
                EnemyConfiguration enemyConfiguration = _staticData.GetEnemyData(randomEnemyType);
                _mushroomFactory.SpawnMushroom(world, randomEnemyType, enemyConfiguration, at);
            }
        }
    }
}