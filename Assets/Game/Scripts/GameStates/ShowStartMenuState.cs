using Game.Scripts.EntryPoints;
using Game.Scripts.EntryPoints.Abstract;
using Game.Scripts.Global;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.GameStates
{
    public class ShowStartMenuState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneProgressService _sceneProgressService;
        private readonly SceneLoader _sceneLoader;

        public ShowStartMenuState(GameStateMachine stateMachine, SceneProgressService sceneProgressService,
            SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneProgressService = sceneProgressService;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _sceneLoader.LoadMenuScene(RequestToOpenStartMenu);
        }

        public void Exit()
        {
            
        }

        private void RequestToOpenStartMenu()
        {
            SceneEntryPoint entryPoint = _sceneProgressService.CurrentSceneEntryPoint;
            if (entryPoint is MenuSceneEntryPoint menuSceneEntryPoint)
            {
                menuSceneEntryPoint.OpenStartMenu(); 
            }
            else
            {
                Debug.LogError("CurrentSceneEntryPoint is not of type MenuSceneEntryPoint.");
            }
        }
    }
}