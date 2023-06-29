using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Systems.Move
{
    public interface IBar
    {
    }

    public class Bar : MonoBehaviour, IBar
    {
        private Foo.Pool _fooPool;
        private readonly List<Foo> _foos = new List<Foo>();

        [Inject]
        public void Construct(Foo.Pool pool)
        {
            _fooPool = pool;

            Debug.Log(_fooPool);
        }

        private void Start()
        {
            InvokeRepeating(nameof(Test), 1.0f, 2);
            InvokeRepeating(nameof(Test2), 2, 3);
        }

        private void Test2()
        {
            //RemoveFoo();
        }

        private void Test() =>
            AddFoo();

        public void AddFoo()
        {
            float maxSpeed = 10.0f;
            float minSpeed = 1.0f;

            Debug.Log("Invoke");
            _foos.Add(_fooPool.Spawn(new Vector3(1, 1, 1)));
        }

        public void RemoveFoo()
        {
            var foo = _foos[0];
            _fooPool.Despawn(foo);
            _foos.Remove(foo);
        }
    }
}