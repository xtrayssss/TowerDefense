using UnityEngine;

namespace Infrastructure.Services.Coroutines
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void Awake() => 
            DontDestroyOnLoad(this);
    }
}