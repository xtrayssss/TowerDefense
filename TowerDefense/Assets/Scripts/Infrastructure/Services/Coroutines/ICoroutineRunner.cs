using System.Collections;
using UnityEngine;

namespace Infrastructure.Services.Coroutines
{
    internal interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator enumerator);
    }
}