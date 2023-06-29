using System.Collections.Generic;
using Components.Movement;
using Leopotam.Ecs;
using UnityComponents.Observers;
using UnityEngine;

namespace UnityComponents.Towers
{
    public class AttackZone : MonoBehaviour
    {
        [SerializeField] private TriggerObserver triggerObserver;
        [SerializeField] private TowerView towerView;

        private void OnEnable()
        {
            triggerObserver.TriggerEntered += OnTriggerEntered;
            triggerObserver.TriggerExited += OnTriggerExited;
        }

        private void OnDisable()
        {
            triggerObserver.TriggerEntered -= OnTriggerEntered;
            triggerObserver.TriggerExited -= OnTriggerExited;
        }

        private void OnTriggerEntered(Collider2D other)
        {
            
        }

        private void OnTriggerExited(Collider2D other)
        {
        }
    }

    internal struct QueueEnemies
    {
        public Queue<Transform> Enemies;

        public void Initialize() =>
            Enemies = new Queue<Transform>();
    }

    internal struct CalculateDistanceProgress : IEcsIgnoreInFilter
    {
    }
}