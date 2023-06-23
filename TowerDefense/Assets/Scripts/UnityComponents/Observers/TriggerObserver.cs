﻿using System;
using UnityEngine;

namespace UnityComponents.Observers
{
    internal class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> TriggerEntered;
        public event Action<Collider2D> TriggerExited;

        private void OnTriggerEnter2D(Collider2D other) =>
            TriggerEntered?.Invoke(other);

        private void OnTriggerExit2D(Collider2D other) =>
            TriggerExited?.Invoke(other);
    }
}