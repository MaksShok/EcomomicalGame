using System;
using System.Collections;
using Game.Scripts.EntryPoints;
using Game.Scripts.Interfaces;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using AsyncOperation = UnityEngine.AsyncOperation;
using Object = UnityEngine.Object;

namespace Game.Scripts.Global
{
    public class SceneLoader
    {
        private const string MenuSceneName = "MenuScene";
        private const string LevelSceneName = "LevelScene";

        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadLevelScene(Action onSceneLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadSceneAsync(LevelSceneName, onSceneLoaded));
        }

        public void LoadMenuScene(Action onSceneLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadSceneAsync(MenuSceneName, onSceneLoaded));
        }

        private IEnumerator LoadSceneAsync(string sceneName, Action onSceneLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onSceneLoaded?.Invoke();
                yield break;
            }

            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneName);

            while (!sceneLoading.isDone)
            {
                yield return null;
            }

            onSceneLoaded?.Invoke();
        }
    }
}