using System.Linq;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using UnityEngine;

namespace Game.Scripts.UI.Popups.StatsPopup.RelationshipStats
{
    public class RelationshipStatsContainer : StatsContainer<RelationshipStatVisual>
    {
        protected override string PathToResources => "Prefabs/Stats/RelationshipStats/";

        protected override void ShowStats()
        {
            foreach (PlayerStat statType in DialogData.relationshipStats)
            {
                RelationshipStatVisual[] allStatsVisualFromResources = Resources
                    .LoadAll<RelationshipStatVisual>(PathToResources);
                
                if (StatsManager.Stats.TryGetValue(statType, out Stat stat))
                {
                    RelationshipStatVisual statVisualPrefab = allStatsVisualFromResources.FirstOrDefault(s
                        => s.statType == statType);
                    if (statVisualPrefab != null)
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