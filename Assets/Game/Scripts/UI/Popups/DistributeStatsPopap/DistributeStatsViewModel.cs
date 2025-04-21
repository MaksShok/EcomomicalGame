using Game.Scripts.DialogData;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.MVVM;

namespace Game.Scripts.UI.Popups.DistributeStatsPopap
{
    public class DistributeStatsViewModel : ViewModel
    {
        public override string PrefabName => "DistributeStatsPopap";

        public DialogDataObject DialogData { get; }
        public PlayerStatsManager StatsManager { get; }

        public DistributeStatsViewModel(PlayerStatsManager statsManager, DialogDataObject dialogData)
        {
            StatsManager = statsManager;
            DialogData = dialogData;
        }

        public void ApplyDistribute(PlayerStat from, PlayerStat to, int value)
        {
            Stat fromStat = StatsManager.Stats[from];
            Stat toStat = StatsManager.Stats[to];

            StatsManager.DistributeMoney(from, to, value);
        }

        public void ExitRequest()
        {
            CloseRequest();
        }
    }
}