using Game.Scripts.DialogMechanics;
using Game.Scripts.DialogMechanics.EndManagers;
using Game.Scripts.EnterExitParams.GameplayScene;
using Game.Scripts.EntryPoints.Abstract;
using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.Popups.DialogPopap;
using R3;
using Zenject;

namespace Game.Scripts.EntryPoints
{
    public class SecondLevelEntryPoint : SceneEntryPoint
    {
        private Subject<GameplayExitParams> _exitSceneSignalSubj;
        
        private DialogViewModel _dialogViewModel;
        private SecondLevelUIController _uiController;
        private SecondLevelEndingManager _endingStoryManager; 
        private TextAssetsManager _textAssetsManager;

        [Inject]
        private void Constructor(SecondLevelUIController uiController, SecondLevelEndingManager endingStoryManager,
            TextAssetsManager textAssetsManager)
        {
            _uiController = uiController;
            _endingStoryManager = endingStoryManager;
            _textAssetsManager = textAssetsManager;
        }

        public Observable<GameplayExitParams> RunScene(GameplayEnterParams gameplayEnterParams)
        {
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
            _textAssetsManager.InitDialogData(gameplayEnterParams.DialogDataObject);
            
            _uiController.OpenGameplayWindow();
            //_dialogViewModel = _uiController.OpenDialogPopup();
            
            _endingStoryManager.StoriesEnd += () => {_dialogViewModel.CloseRequest();};
        }
    }
}