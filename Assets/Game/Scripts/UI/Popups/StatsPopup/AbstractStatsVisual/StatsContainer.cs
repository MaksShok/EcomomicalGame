using System.Collections.Generic;
using System.Linq;
using Game.Scripts.DialogData;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Popups.StatsPopup.FinancialStats;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual
{
    public abstract class StatsContainer<TStatVisual> : MonoBehaviour where TStatVisual : StatVisual
    {
        protected abstract string PathToResources { get; }

        public List<TStatVisual> visualStats = new();
        
        protected DialogDataObject DialogData;
        protected PlayerStatsManager StatsManager;

        public virtual void Init(DialogDataObject dialogData, PlayerStatsManager statsManager)
        {
            DialogData = dialogData;
            StatsManager = statsManager;
            
            ShowStats();
        }

        protected abstract void ShowStats();
    }
}