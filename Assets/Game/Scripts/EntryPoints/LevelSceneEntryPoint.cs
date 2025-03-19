using Game.Scripts.DialogDataParams;
using Game.Scripts.DialogMechanics;
using Game.Scripts.EntryPoints.Abstract;
using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.Popups.DialogPopap;
using UnityEngine;
using Zenject;

namespace Game.Scripts.EntryPoints
{
    public class LevelSceneEntryPoint : SceneEntryPoint
    {
        [SerializeField] private DialogDataObject _dialogData;

        private DialogViewModel _dialogViewModel;
        private LevelUIController _uiController;
        private TextAssetsManager _textAssetsManager;
        private EndingDialogManager _endingDialogManager;

        [Inject]
        private void Constructor(LevelUIController uiController)
        {
            _uiController = uiController;
        }

        public override void RunScene()
        {
            ShowUI();

            _endingDialogManager = new EndingDialogManager(_uiController, _dialogData);
            _textAssetsManager = new TextAssetsManager(_endingDialogManager, _dialogData);
            _dialogViewModel.Init(_textAssetsManager, _dialogData);
            
            _endingDialogManager.OnStoriesEnd += OnStoriesEnd;
        }

        public override void FinishScene()
        {
            _endingDialogManager.OnStoriesEnd -= OnStoriesEnd;
            _endingDialogManager.KillLevelFinishView();
            
            Destroy(gameObject);
        }

        private void ShowUI()
        {
            _uiController.OpenGameplayWindow();
            _dialogViewModel = _uiController.OpenDialogPopup(); 
        }

        private void OnStoriesEnd()
        {
            _dialogViewModel.CloseRequest();
        }
    }
}