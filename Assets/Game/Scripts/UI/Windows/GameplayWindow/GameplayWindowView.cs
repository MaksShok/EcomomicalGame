using System;
using Game.Scripts.UI.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Windows.GameplayWindow
{
    public class GameplayWindowView : View<GameplayWindowViewModel>
    {
        [SerializeField] private Button _exitToLevelMenuButton;

        private void Start()
        {
            _exitToLevelMenuButton.onClick.AddListener(ExitToLevelMenuButtonClicked);
        }

        private void ExitToLevelMenuButtonClicked()
        {
            ViewModel.ExitToLevelMenu();
        }

        protected override void OnUnBindViewModel()
        {
            _exitToLevelMenuButton.onClick.RemoveListener(ExitToLevelMenuButtonClicked);
            Destroy(gameObject);
        }
    }

    public class GameplayWindowViewModel : ViewModel
    {
        public override string PrefabName => "GameplayMainWindow";

        public void ExitToLevelMenu()
        {
            
        }
    }
}