using System.Linq;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using UnityEngine;

namespace Game.Scripts.UI.Popups.StatsPopup.FinancialStats
{
    public class FinancialStatsContainer : StatsContainer<FinancialStatVisual>
    {
        protected override string PathToResources => "Prefabs/Stats/FinancialStats/";
        
        protected override void ShowStats()
        {
            foreach (PlayerStat statType in DialogData.financialStats)
            {
                FinancialStatVisual[] allStatsVisualFromResources = Resources
                    .LoadAll<FinancialStatVisual>(PathToResources);
                
                if (StatsManager.Stats.TryGetValue(statType, out Stat stat))
                {
                    FinancialStatVisual statVisual = allStatsVisualFromResources.FirstOrDefault(s
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