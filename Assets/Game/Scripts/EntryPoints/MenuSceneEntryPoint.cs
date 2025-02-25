using Game.Scripts.GameStates;
using Game.Scripts.UI.Root;
using UnityEngine;
using Zenject;

namespace Game.Scripts.EntryPoints
{
    public class MenuSceneEntryPoint : MonoBehaviour
    {
        private GameLoopState _gameLoopState;
        private UIRootViewModel _rootViewModel;
        private UIRootBinder _uiRootBinder;
            
        [Inject]
        private void Contructor(GameLoopState gameLoopState, UIRootViewModel rootViewModel,
            UIRootBinder uiRootBinder)
        {
            _uiRootBinder = uiRootBinder;
            _rootViewModel = rootViewModel;
            _gameLoopState = gameLoopState;
        }

        private void Start()
        {
            _uiRootBinder.Bind(_rootViewModel);
            _gameLoopState.Enter();
        }
    }
}