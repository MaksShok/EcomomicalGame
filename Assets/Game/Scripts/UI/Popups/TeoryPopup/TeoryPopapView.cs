using System;
using Game.Scripts.UI.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.TeoryPopup
{
    public class TeoryPopapView : View<TeoryPopupViewModel>
    {
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _exitButton.onClick.AddListener(ExitButtonClicked);
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