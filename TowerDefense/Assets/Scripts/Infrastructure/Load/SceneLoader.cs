using System;
using System.Collections;
using Infrastructure.Services.Coroutines;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Load
{
    internal class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Load<T>(T t, Action onLoaded) => 
            _coroutineRunner.StartCoroutine(LoadCoroutine(t, onLoaded));

        private IEnumerator LoadCoroutine<T>(T t, Action onLoaded)
        {
            AsyncOperation loadOperation = LoadSceneAsync(t);
            
            yield return new WaitUntil(() => !loadOperation.isDone);
            
            onLoaded?.Invoke();
        }

        private AsyncOperation LoadSceneAsync<T>(T t)
        {
            if (t is string sceneName)
                return SceneManager.LoadSceneAsync(sceneName);

            return SceneManager.LoadSceneAsync(Convert.ToInt32(t));
        }
    }
}