using Systems.Destroy;
using Systems.Move;
using Systems.SpawnSystem;
using Systems.WayPoints;
using Components.Destroy;
using Components.EnemySpawn;
using Components.Movement;
using Infrastructure.Services.Factories;
using Infrastructure.Services.World;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace UnityComponents
{
    public sealed class Startup : MonoBehaviour
    {
        private EcsSystems _initSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private IEnemyFactoryService _enemyFactoryService;
        private EcsWorld _world;

        [Inject]
        private void Construct(IEnemyFactoryService enemyFactoryService, IWorldService worldService)
        {
            _world = worldService.World;
            _enemyFactoryService = enemyFactoryService;
        }

        private void Start()
        {
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
            _initSystems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_initSystems);
#endif
            AddSystems();
            AddOneFrames();

            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        private void AddSystems()
        {
            _updateSystems
                .Add(new CalculatedDirectionSystem())
                .Add(new WayPointSettingSystem())
                .Add(new DestroyModelSystem())
                .Add(new DestroySystem())
                .Add(new SettingNextWaveSystem())
                .Add(new EnemySpawnSystem(_enemyFactoryService));

            _fixedUpdateSystems
                .Add(new MovementSystem());
        }

        private void AddOneFrames()
        {
            _updateSystems
                .OneFrame<SelfSpawnRequest>()
                .OneFrame<SelfCalculatedDirectionRequest>()
                .OneFrame<SelfDestroyRequest>()
                .OneFrame<SelfDestroyModelRequest>()
                .OneFrame<CheckAliveEnemiesRequest>();
        }

        private void Update() =>
            _updateSystems.Run();

        private void FixedUpdate() =>
            _fixedUpdateSystems.Run();

        private void OnDestroy()
        {
            if (_updateSystems != null && _fixedUpdateSystems != null && _initSystems != null)
            {
                _initSystems.Destroy();
                _initSystems = null;
                _updateSystems.Destroy();
                _updateSystems = null;
                _fixedUpdateSystems.Destroy();
                _fixedUpdateSystems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}