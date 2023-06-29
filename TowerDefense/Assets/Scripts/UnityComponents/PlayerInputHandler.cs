using Components.Mouse;
using Leopotam.Ecs;
using UnityComponents.Views;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityComponents
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerView playerView;
        
        public void OnRightClick(InputAction.CallbackContext callbackContext) => 
            playerView.Entity.Get<RightClickEvent>();
    }
}