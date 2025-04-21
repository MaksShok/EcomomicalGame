using System.Linq;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using UnityEngine;

namespace Game.Scripts.UI.Popups.StatsPopup.RelationshipStats
{
    public class RelationshipStatsContainer : StatsContainer<RelationshipStatVisual>
    {
        protected override void ShowStats()
        {
            foreach (RelationshipStatVisual statVisualPrefab in DialogData.relationshipStats)
            {
                if (StatsManager.Stats.TryGetValue(statVisualPrefab.statType, out Stat stat))
                {
                    if (stat != null)
                    {
                        RelationshipStatVisual statVisual = Instantiate(statVisualPrefab, gameObject.transform);
                        statVisual.Init(stat);
                        visualStats.Add(statVisual);
                    }
                }
            }
        }
    }
}