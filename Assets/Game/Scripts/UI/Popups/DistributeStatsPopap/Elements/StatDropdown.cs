using System.Collections.Generic;
using System.Linq;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Popups.StatsPopup.AbstractStatsVisual;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.Popups.DistributeStatsPopap.Elements
{
    public class StatDropdown : MonoBehaviour
    {
        public PlayerStat SelectedStatType { get; private set; }

        [SerializeField] private TMP_Dropdown _dropdown;
        [SerializeField] private TextMeshProUGUI _selectedStatName;

        private List<StatVisual> _visualStatsList;

        public void Init(List<StatVisual> visualStatsList)
        {
            _visualStatsList = visualStatsList;
            
            foreach (StatVisual statVisual in _visualStatsList)
            {
                _dropdown.options.Add(new TMP_Dropdown.OptionData(statVisual.statVisualizedName));
            }

            _selectedStatName.text = _dropdown.options[0].text;
            _dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(_dropdown); });
            SelectedStatType = GetSelectedStatType();
            _dropdown.RefreshShownValue();
        }

        private void DropdownItemSelected(TMP_Dropdown dropdown)
        {
            int index = dropdown.value;
            string statName = _dropdown.options[index].text;
            _selectedStatName.text = statName;
            
            SelectedStatType = GetSelectedStatType();
        }

        private PlayerStat GetSelectedStatType()
        {
            return _visualStatsList.FirstOrDefault(s 
                => s.statVisualizedName == _selectedStatName.text)!.statType;
        }
    }
}