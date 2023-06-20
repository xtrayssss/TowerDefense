using Leopotam.Ecs;
using UnityEngine;

namespace UnityComponents
{
    sealed class Startup : MonoBehaviour
    {
        EcsWorld _world;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Start()
        {
            _world = new EcsWorld();
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems);
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
        }

        private void Update() => 
            _updateSystems.Run();

        private void FixedUpdate() =>
            _fixedUpdateSystems.Run();

        private void OnDestroy()
        {
            if (_updateSystems != null && _fixedUpdateSystems != null)
            {
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