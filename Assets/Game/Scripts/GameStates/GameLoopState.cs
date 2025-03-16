using Game.Scripts.Global;
using UnityEngine;
using IState = Game.Scripts.Interfaces.IState;

namespace Game.Scripts.GameStates
{
    public class GameLoopState : IState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly SceneProgressService _sceneProgressService;

        public GameLoopState(SceneLoader sceneLoader, SceneProgressService sceneProgressService)
        {
            _sceneLoader = sceneLoader;
            _sceneProgressService = sceneProgressService;
        }
        
        public void Enter()
        {
            _sceneLoader.LoadLevelScene(AfterLoadedScene);
        }

        public void Exit()
        {
            _sceneProgressService.CurrentSceneEntryPoint.FinishScene();
        }

        private void AfterLoadedScene()
        {
            _sceneProgressService.CurrentSceneEntryPoint.RunScene();
        }
    }
}