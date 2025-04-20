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
                    FinancialStatVisual statVisualPrefab = allStatsVisualFromResources.FirstOrDefault(s
                        => s.statType == statType);
                    if (statVisualPrefab != null)
                    {
                        FinancialStatVisual statVisual = Instantiate(statVisualPrefab, gameObject.transform);
                        statVisual.Init(stat);
                        visualStats.Add(statVisual);
                    }
                }
            }
        }
    }
}