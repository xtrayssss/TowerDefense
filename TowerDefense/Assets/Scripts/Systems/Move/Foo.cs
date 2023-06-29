using UnityEngine;
using Zenject;

namespace Systems.Move
{
    public class Foo : MonoBehaviour
    {
        Vector3 _velocity;
        
        [Inject]
        public void Construct()
        {
            Reset(Vector3.zero);
        }

        public void Update()
        {
            transform.position += _velocity * Time.deltaTime;
        }

        void Reset(Vector3 velocity)
        {
            transform.position = Vector3.zero;
            _velocity = velocity;
        }

        public class Pool : MonoMemoryPool<Vector3, Foo>
        {
            protected override void Reinitialize(Vector3 velocity, Foo foo)
            {
                foo.Reset(velocity);
            }
        }
    }
}