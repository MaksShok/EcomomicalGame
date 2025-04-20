using Game.Scripts.DialogData;
using Game.Scripts.EntryPoints.Abstract;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.MVVM;
using Game.Scripts.UI.Popups.StatsPopup.FinancialStats;
using Game.Scripts.UI.Popups.StatsPopup.MoneyBalanceStat;
using Game.Scripts.UI.Popups.StatsPopup.RelationshipStats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.StatsPopup
{
    public class StatsPopap : View<StatsViewModel>
    {
        [SerializeField] private FinancialStatsContainer _financialStatsContainer;
        [SerializeField] private RelationshipStatsContainer _relationshipStatsContainer;
        [SerializeField] private BalanceStatsContainer _balanceStatsContainer;
        
        private PlayerStatsManager _statsManager;
        private DialogDataObject _dialogData;

        private void Start()
        {
            _statsManager = SceneEntryPoint.DiContainer.Resolve<PlayerStatsManager>();
            _dialogData = ViewModel.DialogData;
            
            _financialStatsContainer.Init(_dialogData, _statsManager);
            _relationshipStatsContainer.Init(_dialogData, _statsManager);
            _balanceStatsContainer.Init(_dialogData, _statsManager);
        }

        protected override void OnUnBindViewModel()
        {
            Destroy(gameObject);
        }
    }
}