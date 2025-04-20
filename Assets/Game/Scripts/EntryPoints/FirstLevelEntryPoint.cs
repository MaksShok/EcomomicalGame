using Game.Scripts.DialogData;
using Game.Scripts.DialogMechanics;
using Game.Scripts.DialogMechanics.EndManagers;
using Game.Scripts.EnterExitParams.GameplayScene;
using Game.Scripts.EntryPoints.Abstract;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.Popups.DialogPopap;
using ModestTree;
using R3;
using Zenject;

namespace Game.Scripts.EntryPoints
{
    public class FirstLevelEntryPoint : SceneEntryPoint
    {
        private Subject<GameplayExitParams> _exitSceneSignalSubj;
        
        private DialogViewModel _dialogViewModel;
        private DialogDataObject _dialogData;
        private FirstLevelUIController _uiController;
        private EndingManager _endingStoryManager;
        private TextAssetsManager _textAssetsManager;

        [Inject]
        private void Constructor(FirstLevelUIController uiController, EndingManager endingStoryManager,
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
        }

        public void ExitSceneRequest(GameplayExitParams exitParams = default)
        {
            _exitSceneSignalSubj.OnNext(exitParams);
        }

        private void PrepareDialogUI(GameplayEnterParams gameplayEnterParams)
        {
            _uiController.OpenGameplayWindow();
            _textAssetsManager.InitDialogData(_dialogData);
            _dialogViewModel = _uiController.OpenDialogPopup(_dialogData);
            
            if (!_dialogData.financialStats.IsEmpty() 
                || !_dialogData.balanceStats.IsEmpty() 
                || !_dialogData.relationshipStats.IsEmpty())
            {
                _uiController.OpenStatsPopap(_dialogData);
            }
            
            _endingStoryManager.StoriesEnd += () => {_dialogViewModel.CloseRequest();};
        }
    }
}