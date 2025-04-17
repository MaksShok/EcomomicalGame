using Game.Scripts.UI.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Windows.LevelMenuWindow
{
    public class LevelMenuWindow : View<LevelMenuViewModel>
    {
        [SerializeField] private Button _startMoneySaveLevelButton;
        [SerializeField] private Button _showMoneySaveTeoryButton;
        [SerializeField] private Button _exitToStartMenuButton;

        private void Start()
        {
            _startMoneySaveLevelButton.onClick.AddListener(StartMoneySaveButtonClicked);
            _showMoneySaveTeoryButton.onClick.AddListener(MoneySaveTeoryButtonClicked);
            _exitToStartMenuButton.onClick.AddListener(ExitToStartMenuButtonClicked);
        }

        private void StartMoneySaveButtonClicked()
        {
            ViewModel.StartFirstLevelRequest();
        }

        private void MoneySaveTeoryButtonClicked()
        {
            ViewModel.ShowFirstLevelTeoryRequest();
        }

        private void ExitToStartMenuButtonClicked()
        {
            ViewModel.ExitToStartMenuRequest();
        }
        
        protected override void OnUnBindViewModel()
        {
            _startMoneySaveLevelButton.onClick.RemoveListener(StartMoneySaveButtonClicked);
            _exitToStartMenuButton.onClick.RemoveListener(ExitToStartMenuButtonClicked);
            Destroy(gameObject);
        }
    }
}