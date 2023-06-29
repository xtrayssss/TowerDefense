using Systems.Build;
using Systems.Destroy;
using Systems.Grid;
using Systems.Init;
using Systems.Mouse;
using Systems.Move;
using Systems.SpawnSystem;
using Systems.UITower;
using Systems.WayPoints;
using Components.Destroy;
using Components.EnemySpawn;
using Components.Mouse;
using Components.Movement;
using Components.UITower;
using Infrastructure.Services.Factories;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.World;
using Leopotam.Ecs;
using UnityComponents.Containers;
using UnityEngine;
using Zenject;
using Voody.UniLeo;

namespace UnityComponents
{
    public sealed class Startup : MonoBehaviour
    {
        private EcsSystems _initSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private IEnemyFactoryService _enemyFactoryService;
        private EcsWorld _world;
        private IPlayerFactory _playerFactory;
        private IStaticData _staticData;
        private IEnemySpawnerFactory _enemySpawnerFactory;
        private IWorldService _worldService;
        private SceneReferenceContainer _sceneReferenceContainer;
        private ITowerFactory _towerFactory;

        [Inject]
        private void Construct(IEnemyFactoryService enemyFactoryService, IWorldService worldService,
            IPlayerFactory playerFactory, IStaticData staticData,
            IEnemySpawnerFactory enemySpawnerFactory, SceneReferenceContainer sceneReferenceContainer, ITowerFactory towerFactory)
        {
            _towerFactory = towerFactory;
            _sceneReferenceContainer = sceneReferenceContainer;
            _worldService = worldService;
            _enemySpawnerFactory = enemySpawnerFactory;
            _staticData = staticData;
            _playerFactory = playerFactory;
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

            _initSystems.ConvertScene();

            AddSystems();
            AddOneFrames();

            _initSystems.Init();
            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        private void AddSystems()
        {
            _updateSystems
                .Add(new InitLevelSystem(_playerFactory, _worldService, _staticData, _enemySpawnerFactory))
                .Add(new CalculatedDirectionSystem())
                .Add(new WayPointSettingSystem())
                .Add(new DestroyModelSystem())
                .Add(new RotationSystem())
                .Add(new DestroySystem())
                .Add(new SettingNextWaveSystem())
                .Add(new EnemySpawnSystem(_enemyFactoryService))
                .Add(new RightClickSystem())
                .Add(new MousePositionSystem())
                .Add(new ConvertWorldToCellSystem())
                .Add(new ConvertCellToWorldSystem())
                .Add(new WindowBuildTowerSystem())
                .Add(new IndicateTowerIconSystem())
                .Add(new BuildTowerSystem(_towerFactory))
                .Add(new FindingNearEnemySystem());

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
                .OneFrame<CheckAliveEnemiesRequest>()
                .OneFrame<SelfConvertCellToWorldRequest>()
                .OneFrame<SelfConvertWorldToCellRequest>()
                .OneFrame<RightClickEvent>()
                .OneFrame<ClickHandleSelfRequest>()
                .OneFrame<SpawnTowerSelfRequest>()
                .OneFrame<IndicateTowerIconSelfRequest>();
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