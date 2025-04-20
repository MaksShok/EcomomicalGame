using System.Globalization;
using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.Popups.StatsPopup.MoneyBalanceStat
{
    public class BalanceStatVisual : StatVisual
    {
        [SerializeField] 
        private TextMeshProUGUI _balanceValue;
        
        protected override void UpdateMe(float newValue)
        {
            _balanceValue.text = $"{newValue}";
        }
    }
}