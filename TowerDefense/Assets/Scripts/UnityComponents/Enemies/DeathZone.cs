using Components.Destroy;
using Components.Health;
using Infrastructure.Services.World;
using Leopotam.Ecs;
using UnityComponents.Observers;
using UnityComponents.Views;
using UnityEngine;
using Zenject;

namespace UnityComponents.Enemies
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private TriggerObserver triggerObserver;
        [SerializeField] private EntityView entityView;

        private IWorldService _worldService;
        private PlayerView _playerView;

        [Inject]
        private void Construct(IWorldService worldService, PlayerView playerView)
        {
            _playerView = playerView;
            _worldService = worldService;
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