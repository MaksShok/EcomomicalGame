using Game.Scripts.UI.MVVM;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Scripts.UI.Windows.LevelMenuWindow
{
    public class LevelMenuWindow : View<LevelMenuViewModel>
    {
        [SerializeField] private Button _startFirstLevelButton;
        [SerializeField] private Button _startSecondLevelButton;
        
        [SerializeField] private Button _showFirstLevelTeoryButton;
        [SerializeField] private Button _showSecondLevelTeoryButton;
        
        [SerializeField] private Button _exitToStartMenuButton;

        private void Start()
        {
            _startFirstLevelButton.onClick.AddListener(StartFirstLevelButtonClicked);
            _startSecondLevelButton.onClick.AddListener(StartSecondLevelButtonClicked);
            
            _showFirstLevelTeoryButton.onClick.AddListener(ShowFirstLevelTeoryButtonClicked);
            _showSecondLevelTeoryButton.onClick.AddListener(ShowSecondLevelTeoryButtonClicked);
            
            _exitToStartMenuButton.onClick.AddListener(ExitToStartMenuButtonClicked);
        }

        private void StartFirstLevelButtonClicked()
        {
            ViewModel.StartFirstLevelRequest();
        }

        private void StartSecondLevelButtonClicked()
        {
            ViewModel.StartSecondLevelRequest();
        }

        private void ShowFirstLevelTeoryButtonClicked()
        {
            ViewModel.ShowFirstLevelTeoryRequest();
        }

        private void ShowSecondLevelTeoryButtonClicked()
        {
            ViewModel.ShowSecondLevelTeoryRequest();
        }

        private void ExitToStartMenuButtonClicked()
        {
            ViewModel.ExitToStartMenuRequest();
        }
        
        protected override void OnUnBindViewModel()
        {
            _startFirstLevelButton.onClick.RemoveListener(StartFirstLevelButtonClicked);
            _startSecondLevelButton.onClick.RemoveListener(StartSecondLevelButtonClicked);
            
            _exitToStartMenuButton.onClick.RemoveListener(ExitToStartMenuButtonClicked);
            _showSecondLevelTeoryButton.onClick.RemoveListener(ShowSecondLevelTeoryButtonClicked);
            
            Destroy(gameObject);
        }
    }
}