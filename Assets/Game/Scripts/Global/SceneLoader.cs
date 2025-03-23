using System;
using System.Collections;
using Game.Scripts.EnterExitParams.GameplayScene;
using Game.Scripts.EnterExitParams.MenuScene;
using Game.Scripts.EntryPoints;
using Game.Scripts.Interfaces;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;
using AsyncOperation = UnityEngine.AsyncOperation;

namespace Game.Scripts.Global
{
    public class SceneLoader
    {
        private const string MenuSceneName = "Menu";
        private const string GameplaySceneName = "Gameplay";

        private readonly CurrentSceneEntryPointService _currentSceneEntryPointService;
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(CurrentSceneEntryPointService currentSceneEntryPointService, ICoroutineRunner coroutineRunner)
        {
            _currentSceneEntryPointService = currentSceneEntryPointService;
            _coroutineRunner = coroutineRunner;
        }

        public void LoadMenuSceneFromBoot()
        {
            _coroutineRunner.StartCoroutine(LoadAndStartMenuScene());
        }
        
        private IEnumerator LoadAndStartMenuScene(MenuEnterParams menuEnterParams = null, Action onSceneLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == MenuSceneName)
            {
                onSceneLoaded?.Invoke();
                yield break;
            }
            
            _currentSceneEntryPointService.FinishSceneRequest();
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(MenuSceneName);

            while (!sceneLoading.isDone)
            {
                yield return null;
            }
            
            MenuEntryPoint entryPoint = _currentSceneEntryPointService.GetEntryPoint<MenuEntryPoint>();
            
            entryPoint.RunScene(menuEnterParams).Subscribe(menuExitParams 
                => _coroutineRunner.StartCoroutine(LoadAndStartGameplayScene(menuExitParams.GameplayEnterParams)));

            onSceneLoaded?.Invoke();
        }
        
        private IEnumerator LoadAndStartGameplayScene(GameplayEnterParams gameplayEnterParams, Action onSceneLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == GameplaySceneName)
            {
                onSceneLoaded?.Invoke();
                yield break;
            }
            
            _currentSceneEntryPointService.FinishSceneRequest();
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(GameplaySceneName);

            while (!sceneLoading.isDone)
            {
                yield return null;
            }

            GameplayEntryPoint entryPoint = _currentSceneEntryPointService.GetEntryPoint<GameplayEntryPoint>();
            
            entryPoint.RunScene(gameplayEnterParams).Subscribe(gameplayExitParams 
                => _coroutineRunner.StartCoroutine(LoadAndStartMenuScene(gameplayExitParams?.MenuEnterParams)));

            onSceneLoaded?.Invoke();
        }
    }
}