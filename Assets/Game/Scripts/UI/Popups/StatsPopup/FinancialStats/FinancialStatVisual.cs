using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.Popups.StatsPopup.FinancialStats
{
    public class FinancialStatVisual : StatVisual
    {
        [SerializeField] 
        private TextMeshProUGUI _value;

        protected override void UpdateMe(float newValue)
        {
            _value.text = $"{newValue} / {Stat.TargetValue}";
        }
    }
}