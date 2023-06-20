using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    internal interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator enumerator);
    }
}