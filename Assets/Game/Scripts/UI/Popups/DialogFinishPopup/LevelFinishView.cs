using System;
using Game.Scripts.UI.MVVM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.DialogFinishPopup
{
    public class LevelFinishView : View<LevelFinishViewModelAbstract>
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _mainText;
        [SerializeField] private Button _goToLevelMenuButton;

        private void Start()
        {
            _titleText.text = ViewModel.TitleText;
            _mainText.text = ViewModel.MainText;
            _goToLevelMenuButton.onClick.AddListener(GoToLevelMenuButtonClicked);
        }

        private void GoToLevelMenuButtonClicked()
        {
            ViewModel.GoToLevelMenuRequest();
        }

        protected override void OnUnBindViewModel()
        {
            _goToLevelMenuButton.onClick.RemoveListener(GoToLevelMenuButtonClicked);
            Destroy(gameObject);
        }
    }
}