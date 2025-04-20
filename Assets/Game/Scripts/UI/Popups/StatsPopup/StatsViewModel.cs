using Game.Scripts.DialogData;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.MVVM;

namespace Game.Scripts.UI.Popups.StatsPopup
{
    public class StatsViewModel : ViewModel
    {
        public override string PrefabName => "StatsPopap";

        public DialogDataObject DialogData
        {
            get { return _dialogData; }
            private set { }
        }

        private readonly DialogDataObject _dialogData;
        private readonly PlayerStatsManager _playerStatsManager;

        public StatsViewModel(PlayerStatsManager playerStatsManager, DialogDataObject dialogData)
        {
            _playerStatsManager = playerStatsManager;
            _dialogData = dialogData;
        }
    }
}