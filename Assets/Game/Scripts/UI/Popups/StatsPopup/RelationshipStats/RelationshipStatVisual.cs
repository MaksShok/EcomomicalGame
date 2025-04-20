using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.StatsPopup.RelationshipStats
{
    public class RelationshipStatVisual : StatVisual
    {
        [SerializeField] 
        private Image _progress;

        protected override void UpdateMe(float newValue)
        {
            _progress.fillAmount = newValue / Stat.MaxValue;
        }
    }
}