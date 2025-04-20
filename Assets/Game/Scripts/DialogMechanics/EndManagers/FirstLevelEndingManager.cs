using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Controllers;
using UnityEngine;

namespace Game.Scripts.DialogMechanics.EndManagers
{
    public class FirstLevelEndingManager : EndingManager
    {
        private const string PositiveEnd = "Positive";
        private const string NegativeEnd = "Negative";
        
        private readonly GameplayUIController _levelUIController;
        private readonly PlayerStatsManager _statsManager;

        public FirstLevelEndingManager(GameplayUIController levelUIController, PlayerStatsManager statsManager)
        {
            _levelUIController = levelUIController;
            _statsManager = statsManager;
        }

        public override TextAsset GetDefineEnding()
        {
            TextAsset endAsset;
            
            if (_statsManager.MoodCoefficient.Value >= 0)
            {
                IsVictory = true;
                DialogData.EndingsDict.TryGetValue(PositiveEnd, out endAsset);
            }
            else
            {
                IsVictory = false;
                DialogData.EndingsDict.TryGetValue(NegativeEnd, out endAsset);
            }

            return endAsset;
        }

        public override void End()
        {
            if (IsVictory)
                LevelFinishViewModel = _levelUIController.OpenPositiveEndingPopup();
            else
                LevelFinishViewModel = _levelUIController.OpenNegativeEndingPopup();
            
            OnStoriesEnd();
        }
    }
}