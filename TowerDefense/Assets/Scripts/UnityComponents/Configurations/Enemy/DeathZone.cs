using Components.Destroy;
using Components.Health;
using Infrastructure.Services.World;
using Leopotam.Ecs;
using UnityComponents.Observers;
using UnityComponents.Views;
using UnityEngine;
using Zenject;

namespace UnityComponents.Configurations.Enemy
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private TriggerObserver triggerObserver;
        [SerializeField] private EntityView entityView;

        private PlayerView _playerView;
        private IWorldService _worldService;

        [Inject]
        private void Construct(PlayerView playerView, IWorldService worldService)
        {
            _worldService = worldService;
            _playerView = playerView;
        }

        private void OnEnable() =>
            triggerObserver.TriggerEntered += OnTriggerEntered;

        private void OnDisable() =>
            triggerObserver.TriggerEntered -= OnTriggerEntered;

        private void OnTriggerEntered(Collider2D other)
        {
            if (other.CompareTag("DeathTrigger"))
            {
                _playerView.Entity.Get<Health>().CurrentHealth -= 10;
                entityView.Entity.Get<SelfDestroyRequest>();
                entityView.Entity.Get<SelfDestroyModelRequest>();
                _worldService.World.NewEntity().Get<CheckAliveEnemiesRequest>();
            }
        }
    }
}