using System.Linq;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using UnityEngine;

namespace Game.Scripts.UI.Popups.StatsPopup.MoneyBalanceStat
{
    public class BalanceStatsContainer : StatsContainer<BalanceStatVisual>
    {
        protected override void ShowStats()
        {
            foreach (BalanceStatVisual statVisualPrefab in DialogData.balanceStats)
            {
                if (StatsManager.Stats.TryGetValue(statVisualPrefab.statType, out Stat stat))
                {
                    if (stat != null)
                    {
                        BalanceStatVisual statVisual = Instantiate(statVisualPrefab, gameObject.transform);
                        statVisual.Init(stat);
                        visualStats.Add(statVisual);
                    }
                }
            }
        }
    }
}