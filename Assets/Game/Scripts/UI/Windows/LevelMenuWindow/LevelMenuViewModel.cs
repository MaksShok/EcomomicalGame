using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.MVVM;

namespace Game.Scripts.UI.Windows.LevelMenuWindow
{
    public class LevelMenuViewModel : ViewModel
    {
        public override string PrefabName => "LevelMenu";

        private readonly MenuUIController _uiController;

        public LevelMenuViewModel(MenuUIController uiController)
        {
            _uiController = uiController;
        }

        public void ExitToStartMenuRequest()
        {
            _uiController.OpenStartMenu();
        }
    }
}