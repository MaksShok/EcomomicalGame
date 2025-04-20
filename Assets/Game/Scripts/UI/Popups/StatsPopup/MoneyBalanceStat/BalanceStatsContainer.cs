using System.Linq;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using UnityEngine;

namespace Game.Scripts.UI.Popups.StatsPopup.MoneyBalanceStat
{
    public class BalanceStatsContainer : StatsContainer<BalanceStatVisual>
    {
        protected override string PathToResources => "Prefabs/Stats/BalanceStats/";
        
        protected override void ShowStats()
        {
            foreach (PlayerStat statType in DialogData.balanceStats)
            {
                BalanceStatVisual[] allStatsVisualFromResources = Resources
                    .LoadAll<BalanceStatVisual>(PathToResources);
                
                if (StatsManager.Stats.TryGetValue(statType, out Stat stat))
                {
                    BalanceStatVisual statVisual = allStatsVisualFromResources.FirstOrDefault(s
                        => s.statType == statType);
                    if (statVisual != null)
                    {
                        visualStats.Add(statVisual);
                        statVisual.Init(stat);
                        Instantiate(statVisual, gameObject.transform);
                    }
                }
            }
        }
    }
}