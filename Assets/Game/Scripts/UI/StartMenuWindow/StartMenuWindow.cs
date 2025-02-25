using Game.Scripts.UI.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.StartMenuWindow
{
    public class StartMenuWindow: View<StartMenuViewModel>
    {
        [SerializeField] private Button _openLevelMenuButton;

        private void Start()
        {
            _openLevelMenuButton.onClick.AddListener(OpenLevelMenuButtonClicked);
        }

        private void OpenLevelMenuButtonClicked()
        {
            ViewModel.OpenLevelMenuRequest();
        }

        protected override void OnUnBindViewModel()
        {
            _openLevelMenuButton.onClick.RemoveListener(OpenLevelMenuButtonClicked);
            Destroy(gameObject);
        }
    }
}