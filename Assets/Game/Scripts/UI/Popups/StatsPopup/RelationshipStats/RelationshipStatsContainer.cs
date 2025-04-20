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
                    RelationshipStatVisual statVisual = allStatsVisualFromResources.FirstOrDefault(s
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