using System;
using Game.Scripts.DialogDataParams;
using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.Popups.DialogFinishPopup;
using UnityEngine;

namespace Game.Scripts.DialogMechanics
{
    public class EndingDialogManager
    {
        public event Action OnStoriesEnd;

        private int _moodСoefficient;
        
        private LevelFinishViewModelAbstract _viewModel;

        private readonly LevelUIController _levelUIController;
        private readonly DialogDataObject _dialogData;

        public EndingDialogManager(LevelUIController levelUIController ,DialogDataObject dialogData)
        {
            _levelUIController = levelUIController;
            _dialogData = dialogData;
        }

        public void ResetCoefficient() => _moodСoefficient = 0;

        public TextAsset GetDefineEnding()
        {
            if (_moodСoefficient >= 0)
                return _dialogData.positiveEndingTextAsset;
            else
                return _dialogData.negativeEndingTextAsset;
        }
        
        public void RegisterChoiceResult(DialogMood moodType)
        {
            switch (moodType)
            {
                case DialogMood.Positive:
                    _moodСoefficient += 1;
                    break;
                case DialogMood.Negative:
                    _moodСoefficient -= 1;
                    break;
            }
        }

        public void End()
        {
            if (_moodСoefficient >= 0)
                _viewModel = _levelUIController.OpenPositiveEndingPopup();
            else
                _viewModel = _levelUIController.OpenNegativeEndingPopup();
            
            OnStoriesEnd?.Invoke();
        }

        public void KillLevelFinishView()
        {
            _viewModel.CloseRequest();
        }
    }
}