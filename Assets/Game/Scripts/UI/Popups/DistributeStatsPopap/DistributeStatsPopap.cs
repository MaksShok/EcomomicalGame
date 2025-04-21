using System.Collections.Generic;
using Game.Scripts.DialogData;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.MVVM;
using Game.Scripts.UI.Popups.DistributeStatsPopap.Elements;
using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using Game.Scripts.UI.Popups.StatsPopup.FinancialStats;
using Game.Scripts.UI.Popups.StatsPopup.MoneyBalanceStat;
using Game.Scripts.UI.Popups.StatsPopup.RelationshipStats;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.DistributeStatsPopap
{
    public class DistributeStatsPopap : View<DistributeStatsViewModel>
    {
        [SerializeField] private DistributionInputField _inputField;

        [SerializeField] private StatDropdown _fromStatDropdown;
        [SerializeField] private StatDropdown _toStatDropdown;

        [SerializeField] private Button _applyButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private FinancialStatsContainer _financialStatsContainer;
        [SerializeField] private RelationshipStatsContainer _relationshipStatsContainer;
        [SerializeField] private BalanceStatsContainer _balanceStatsContainer;

        private DialogDataObject _dialogData;
        private PlayerStatsManager _statsManager;

        private void Start()
        {
            _dialogData = ViewModel.DialogData;
            _statsManager = ViewModel.StatsManager;
            
            _financialStatsContainer.Init(_dialogData, _statsManager);
            _relationshipStatsContainer.Init(_dialogData, _statsManager);
            _balanceStatsContainer.Init(_dialogData, _statsManager);

            List<StatVisual> statVisuals = new List<StatVisual>();
            foreach (StatVisual statVisual in _dialogData.balanceStats) {
                statVisuals.Add(statVisual);
            }
            foreach (StatVisual statVisual in _dialogData.financialStats) {
                statVisuals.Add(statVisual);
            }
            _fromStatDropdown.Init(statVisuals);
            _toStatDropdown.Init(statVisuals);
            
            _applyButton.onClick.AddListener(ApplyButtonClicked);
            _exitButton.onClick.AddListener(ExitButtonClicked);
        }

        private void ApplyButtonClicked()
        {
            PlayerStat fromStatType = _fromStatDropdown.SelectedStatType;
            PlayerStat toStatType = _toStatDropdown.SelectedStatType;
            int value = _inputField.GetEnteredValue();
            
            ViewModel.ApplyDistribute(fromStatType, toStatType, value);
        }

        private void ExitButtonClicked()
        {
            ViewModel.ExitRequest();
        }
        
        protected override void OnUnBindViewModel()
        {
            _applyButton.onClick.RemoveListener(ApplyButtonClicked);
            _exitButton.onClick.RemoveListener(ExitButtonClicked);
            
            Destroy(gameObject);
        }
    }
}