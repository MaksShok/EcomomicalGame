using System;
using Game.Scripts.DialogMechanics;
using Game.Scripts.EnterExitParams.GameplayScene;
using Game.Scripts.EnterExitParams.MenuScene;
using Game.Scripts.EntryPoints;
using Game.Scripts.UI.MVVM;
using R3.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Windows.GameplayWindow
{
    public class GameplayWindowView : View<GameplayWindowViewModel>
    {
        [SerializeField] private Button _exitToLevelMenuButton;
        [SerializeField] private Button _restartDialogButton;

        private void Start()
        {
            _exitToLevelMenuButton.onClick.AddListener(ExitToLevelMenuButtonClicked);
            _restartDialogButton.onClick.AddListener(RestartDialogButtonClicked);
        }

        private void ExitToLevelMenuButtonClicked()
        {
            ViewModel.ExitToLevelMenu();
        }

        private void RestartDialogButtonClicked()
        {
            ViewModel.RestartDialog();
        }

        protected override void OnUnBindViewModel()
        {
            _exitToLevelMenuButton.onClick.RemoveListener(ExitToLevelMenuButtonClicked);
            _restartDialogButton.onClick.RemoveListener(RestartDialogButtonClicked);
            Destroy(gameObject);
        }
    }

    public class GameplayWindowViewModel : ViewModel
    {
        public override string PrefabName => "GameplayMainWindow";
        
        private readonly GameplayEntryPoint _entryPoint;
        private readonly TextAssetsManager _textAssetsManager;

        public GameplayWindowViewModel(GameplayEntryPoint entryPoint, TextAssetsManager textAssetsManager)
        {
            _entryPoint = entryPoint;
            _textAssetsManager = textAssetsManager;
        }
        
        public void ExitToLevelMenu()
        {
            MenuEnterParams menuEnterParams = new MenuEnterParams(false);
            GameplayExitParams gameplayExitParams = new GameplayExitParams(menuEnterParams);
            
            _entryPoint.ExitSceneRequest(gameplayExitParams);
        }

        public void RestartDialog()
        {
            _textAssetsManager.StartFromFirstStory();
        }
    }
}