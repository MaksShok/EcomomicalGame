using System;
using System.Collections;
using Game.Scripts.EnterExitParams.GameplayScene;
using Game.Scripts.EnterExitParams.MenuScene;
using Game.Scripts.EntryPoints;
using Game.Scripts.EntryPoints.Abstract;
using Game.Scripts.Interfaces;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;
using AsyncOperation = UnityEngine.AsyncOperation;

namespace Game.Scripts.Global
{
    public class SceneLoader
    {
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
            if (SceneManager.GetActiveScene().name == Scenes.MenuSceneName)
            {
                onSceneLoaded?.Invoke();
                yield break;
            }
            
            _currentSceneEntryPointService.FinishSceneRequest();
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(Scenes.MenuSceneName);

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
            string sceneName = gameplayEnterParams.SceneName;
            
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onSceneLoaded?.Invoke();
                yield break;
            }
            
            _currentSceneEntryPointService.FinishSceneRequest();
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneName);

            while (!sceneLoading.isDone)
            {
                yield return null;
            }

            if (sceneName == Scenes.FirstLevel)
            {
                FirstLevelEntryPoint entryPoint = _currentSceneEntryPointService.GetEntryPoint<FirstLevelEntryPoint>();
                entryPoint.RunScene(gameplayEnterParams).Subscribe(gameplayExitParams 
                    => _coroutineRunner.StartCoroutine(LoadAndStartMenuScene(gameplayExitParams?.MenuEnterParams)));
            }
            else if (sceneName == Scenes.SecondLevel)
            {
                
            }

            onSceneLoaded?.Invoke();
        }
    }
}