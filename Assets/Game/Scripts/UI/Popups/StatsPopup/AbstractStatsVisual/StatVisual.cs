using Game.Scripts.PlayerStatMechanics;
using UnityEngine;

namespace Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual
{
    public abstract class StatVisual : MonoBehaviour
    {
        [SerializeField] 
        public string statVisualizedName;
        
        [SerializeField] 
        public PlayerStat statType;
        
        public Stat Stat { get; private set; }
        
        public void Init(Stat stat)
        {
            Stat = stat;
            Stat.ValueChanged += UpdateMe;
            UpdateMe(Stat.Value);
        }

        protected abstract void UpdateMe(float newValue);
    }
}