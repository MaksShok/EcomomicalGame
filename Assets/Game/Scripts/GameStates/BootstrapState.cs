using Game.Scripts.EntryPoints;
using Game.Scripts.Global;
using Game.Scripts.Interfaces;
using Game.Scripts.UI.Root;
using UnityEngine;

namespace Game.Scripts.GameStates
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly CurrentSceneEntryPointService _sceneProgressService;
        private readonly UIRootViewModel _rootViewModel;
        private readonly UIRootBinder _uiRootBinder;

        public BootstrapState(GameStateMachine stateMachine, CurrentSceneEntryPointService sceneProgressService,
            UIRootViewModel rootViewModel, UIRootBinder uiRootBinder)
        {
            _stateMachine = stateMachine;
            _sceneProgressService = sceneProgressService;
            _rootViewModel = rootViewModel;
            _uiRootBinder = uiRootBinder;
        }
        
        public void Enter()
        {
            _uiRootBinder.Bind(_rootViewModel);
            //_sceneProgressService.CurrentSceneEntryPoint.RunScene();
            _stateMachine.Enter<ShowStartMenuState>();
        }

        public void Exit()
        {
            //_sceneProgressService.CurrentSceneEntryPoint.FinishScene();
        }
    }
}