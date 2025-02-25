using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.MVVM;

namespace Game.Scripts.UI.StartMenuWindow
{
    public class StartMenuViewModel : ViewModel
    {
        public override string PrefabName => "StartMenu";
        
        private readonly MenuUIController _uiController;

        public StartMenuViewModel(MenuUIController uiController)
        {
            _uiController = uiController;
        }
        
        public void OpenLevelMenuRequest()
        {
            _uiController.OpenLevelMenu();
        }
    }
}