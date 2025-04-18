using System;
using Game.Scripts.DialogData;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.Popups.DialogFinishPopup;
using UnityEngine;

namespace Game.Scripts.DialogMechanics
{
    public class EndingStoryManager
    {
        private const string PositiveEnd = "Positive";
        private const string NegativeEnd = "Negative";

        
        public event Action OnStoriesEnd;

        private readonly LevelUIController _levelUIController;
        private readonly PlayerStatsManager _statsManager;
        private LevelFinishViewModelAbstract _viewModel;
        private  DialogDataObject _dialogData;
        private bool _isVictory;

        public EndingStoryManager(LevelUIController levelUIController, PlayerStatsManager statsManager)
        {
            _levelUIController = levelUIController;
            _statsManager = statsManager;
        }

        public void InitDialogData(DialogDataObject dialogData) => _dialogData = dialogData;
        
        public TextAsset GetDefineEnding()
        {
            TextAsset endAsset;
            
            if (_statsManager.MoodCoefficient.Value >= 0)
            {
                _isVictory = true;
                _dialogData.EndingsDict.TryGetValue(PositiveEnd, out endAsset);
            }
            else
            {
                _isVictory = false;
                _dialogData.EndingsDict.TryGetValue(NegativeEnd, out endAsset);
            }

            return endAsset;
        }

        public void End()
        {
            if (_isVictory)
                _viewModel = _levelUIController.OpenPositiveEndingPopup();
            else
                _viewModel = _levelUIController.OpenNegativeEndingPopup();
            
            OnStoriesEnd?.Invoke();
        }

        public void StopDialog()
        {
            OnStoriesEnd?.Invoke();
            OnStoriesEnd = null;
            _viewModel?.CloseRequest();
        }
    }
}