using System.Collections.Generic;
using Game.Scripts.DialogData;
using Game.Scripts.DialogMechanics;
using Game.Scripts.DialogMechanics.EndManagers;
using Game.Scripts.EnterExitParams.GameplayScene;
using Game.Scripts.EntryPoints.Abstract;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.MVVM;
using Game.Scripts.UI.Popups.DialogPopap;
using ModestTree;
using R3;
using Zenject;

namespace Game.Scripts.EntryPoints
{
    public class GameplayEntryPoint : SceneEntryPoint
    {
        private Subject<GameplayExitParams> _exitSceneSignalSubj;

        private List<ViewModel> _openedViewModels = new();
        
        private DialogDataObject _dialogData;
        private GameplayUIController _uiController;
        private EndingManager _endingStoryManager;
        private TextAssetsManager _textAssetsManager;

        [Inject]
        private void Constructor(GameplayUIController uiController, EndingManager endingStoryManager,
            TextAssetsManager textAssetsManager)
        {
            _uiController = uiController;
            _endingStoryManager = endingStoryManager;
            _textAssetsManager = textAssetsManager;
        }

        public Observable<GameplayExitParams> RunScene(GameplayEnterParams gameplayEnterParams)
        {
            _dialogData = gameplayEnterParams.DialogDataObject;
            
            PrepareDialogUI(gameplayEnterParams);
            
            _exitSceneSignalSubj = new Subject<GameplayExitParams>();
            return _exitSceneSignalSubj;
        }

        public override void FinishScene()
        {
            _endingStoryManager.StopDialog();
            
            foreach (ViewModel viewModel in _openedViewModels)
            {
                viewModel.CloseRequest();
            } _openedViewModels.Clear();
        }

        public void ExitSceneRequest(GameplayExitParams exitParams = default)
        {
            _exitSceneSignalSubj.OnNext(exitParams);
        }

        private void PrepareDialogUI(GameplayEnterParams gameplayEnterParams)
        {
            _uiController.OpenGameplayWindow();
            _textAssetsManager.InitDialogData(_dialogData);
            _openedViewModels.Add(_uiController.OpenDialogPopup(_dialogData));
            
            if (!_dialogData.financialStats.IsEmpty() 
                || !_dialogData.balanceStats.IsEmpty() 
                || !_dialogData.relationshipStats.IsEmpty())
            {
                _openedViewModels.Add(_uiController.OpenStatsPopap(_dialogData));
                //_uiController.OpenDistributeStatsPopap(_dialogData);
            }
        }
    }
}