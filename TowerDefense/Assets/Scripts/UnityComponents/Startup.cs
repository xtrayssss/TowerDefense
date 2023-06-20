using Systems.SpawnSystem;
using Infrastructure.Services.Factories;
using Infrastructure.Services.World;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace UnityComponents
{
    sealed class Startup : MonoBehaviour
    {
        private EcsSystems _initSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private IEnemyFactory _enemyFactory;
        private EcsWorld _world;

        [Inject]
        private void Construct(IEnemyFactory enemyFactory, IWorldService worldService)
        {
            _world = worldService.World;
            _enemyFactory = enemyFactory;
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

        private void AddOneFrames()
        {
        }

        private void AddSystems()
        {
            _updateSystems
                .Add(new EnemySpawnSystem(_enemyFactory));
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