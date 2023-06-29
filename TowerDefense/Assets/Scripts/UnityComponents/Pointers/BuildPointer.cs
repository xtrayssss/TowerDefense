using Infrastructure.Services.World;
using Leopotam.Ecs;
using UnityComponents.Observers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace UnityComponents.Pointers
{
    public class BuildPointer : MonoBehaviour
    {
        [SerializeField] private PointerObserver pointerObserver;
        private IWorldService _worldService;
        private EcsEntity _entity;

        [Inject]
        public void Construct(IWorldService worldService) =>
            _worldService = worldService;

        private void Start()
        {
            pointerObserver.PointerEntered += OnPointEntered;
            pointerObserver.PointerExited += OnPointerExited;
        }

        private void OnDestroy()
        {
            pointerObserver.PointerEntered -= OnPointEntered;
            pointerObserver.PointerExited -= OnPointerExited;
        }


        private void OnPointEntered(PointerEventData eventData)
        {
            _entity = _worldService.World.NewEntity();
            _entity.Get<BuildPointerTag>();
        }

        private void OnPointerExited(PointerEventData eventData)
        {
            if (!_entity.IsNull() && _entity.IsAlive())
                _entity.Destroy();
        }
    }

    internal struct BuildPointerTag
    {
    }
}