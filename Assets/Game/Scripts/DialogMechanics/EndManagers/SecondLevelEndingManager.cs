using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Controllers;
using UnityEngine;

namespace Game.Scripts.DialogMechanics.EndManagers
{
    public class SecondLevelEndingManager : EndingManager
    {
        private const string PositiveEnd = "Positive";
        private const string NegativeEnd = "Negative";
        private const string HealthLossEnd = "HealthLoss";
        private const string MoneyLossEnd = "MoneyLoss";
        private const string FriendRelationshipLossEnd = "FriendRelationshipLoss";
        
        private readonly GameplayUIController _levelUIController;
        private readonly PlayerStatsManager _statsManager;

        public SecondLevelEndingManager(GameplayUIController uiController, PlayerStatsManager statsManager)
        {
            _levelUIController = uiController;
            _statsManager = statsManager;
        }

        public override TextAsset GetDefineEnding()
        {
            TextAsset endAsset;

            if (_statsManager.Health.Value <= 15)
            {
                DialogData.EndingsDict.TryGetValue(HealthLossEnd, out endAsset);
            }
            else if (_statsManager.FriendRelationship.Value <= 10)
            {
                DialogData.EndingsDict.TryGetValue(FriendRelationshipLossEnd, out endAsset);
            }
            else if (_statsManager.PresentMoney.Value >= _statsManager.PresentMoney.TargetValue 
                     && _statsManager.BlackDayMoney.Value >= _statsManager.BlackDayMoney.TargetValue)
            {
                DialogData.EndingsDict.TryGetValue(PositiveEnd, out endAsset);
            }
            else if (_statsManager.Money.Value < 0)
            {
                DialogData.EndingsDict.TryGetValue(MoneyLossEnd, out endAsset);
            }
            else
            {
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