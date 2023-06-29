using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityComponents.Observers
{
    public class PointerObserver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action<PointerEventData> PointerEntered;
        public event Action<PointerEventData> PointerExited;

        public void OnPointerEnter(PointerEventData eventData) =>
            PointerEntered?.Invoke(eventData);

        public void OnPointerExit(PointerEventData eventData) =>
            PointerExited?.Invoke(eventData);
    }
}