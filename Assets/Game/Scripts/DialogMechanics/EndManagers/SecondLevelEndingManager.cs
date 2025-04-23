using System;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Controllers;
using UnityEngine;

namespace Game.Scripts.DialogMechanics.EndManagers
{
    public class SecondLevelEndingManager : EndingManager
    {
        private const string PositiveEnd = "Positive";
        private const string ExtraSuccessEnd = "ExtraSuccess";
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

        public override TextAsset GetDefineEnding(string endKey = default)
        {
            TextAsset endAsset;

            if (!string.IsNullOrEmpty(endKey))
            {
                DialogData.EndingsDict.TryGetValue(endKey, out endAsset);
                if (endKey == PositiveEnd) IsVictory = true;
                return endAsset;
            }
            
            if (_statsManager.Money.Value >= 110)
            {
                IsVictory = true;
                DialogData.EndingsDict.TryGetValue(ExtraSuccessEnd, out endAsset);
            }
            else if (_statsManager.Money.Value >= 50)
            {
                IsVictory = true;
                DialogData.EndingsDict.TryGetValue(PositiveEnd, out endAsset);
            }
            else
            {
                DialogData.EndingsDict.TryGetValue(MoneyLossEnd, out endAsset);
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