using System;
using Game.Scripts.UI.MVVM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.TeoryPopup
{
    public class TeoryPopapView : View<TeoryViewModel>
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _mainText;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _exitButton.onClick.AddListener(ExitButtonClicked);
            _titleText.text = ViewModel.TitleText;
            _mainText.text = ViewModel.MainText;
        }

        private void ExitButtonClicked()
        {
            ViewModel.CloseRequest();
        }
            
        protected override void OnUnBindViewModel()
        {
            Destroy(gameObject);
        }
    }
}