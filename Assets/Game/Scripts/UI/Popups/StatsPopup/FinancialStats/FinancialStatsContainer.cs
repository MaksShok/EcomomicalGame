using System.Linq;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using UnityEngine;

namespace Game.Scripts.UI.Popups.StatsPopup.FinancialStats
{
    public class FinancialStatsContainer : StatsContainer<FinancialStatVisual>
    {
        protected override void ShowStats()
        {
            foreach (FinancialStatVisual statVisualPrefab in DialogData.financialStats)
            {
                if (StatsManager.Stats.TryGetValue(statVisualPrefab.statType, out Stat stat))
                {
                    if (stat != null)
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