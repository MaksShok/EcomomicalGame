using System;
using Game.Scripts.DialogData;
using Game.Scripts.DialogMechanics;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.MVVM;
using R3;

namespace Game.Scripts.UI.Popups.StatsPopup
{
    public class StatsViewModel : ViewModel
    {
        public override string PrefabName => "StatsPopap";

        public DialogDataObject DialogData { get; }

        private readonly GameplayUIController _uiController;
        private readonly PlayerStatsManager _playerStatsManager;

        private IDisposable _disposable; 

        public StatsViewModel(PlayerStatsManager playerStatsManager, DialogDataObject dialogData,
            GameplayUIController uiController, DialogManager dialogManager)
        {
            _playerStatsManager = playerStatsManager;
            DialogData = dialogData;
            _uiController = uiController;

            _disposable = dialogManager.Dialog.Where(e => e.ChangeStats)
                .Subscribe(e => OpenDistributeStatsPopap());
        }

        private void OpenDistributeStatsPopap()
        {
            _uiController.OpenDistributeStatsPopap(DialogData);
        }

        public override void Dispose()
        {
            _disposable.Dispose();
        }
    }
}