using Game.Scripts.UI.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Windows.LevelMenuWindow
{
    public class LevelMenuWindow : View<LevelMenuViewModel>
    {
        [SerializeField] private Button _exitToStartMenuButton;

        private void Start()
        {
            _exitToStartMenuButton.onClick.AddListener(ExitToStartMenuButtonClicked);
        }

        private void ExitToStartMenuButtonClicked()
        {
            ViewModel.ExitToStartMenuRequest();
        }
        
        protected override void OnUnBindViewModel()
        {
            _exitToStartMenuButton.onClick.RemoveListener(ExitToStartMenuButtonClicked);
            Destroy(gameObject);
        }
    }
}