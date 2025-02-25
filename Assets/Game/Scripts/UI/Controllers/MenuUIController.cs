using Game.Scripts.UI.LevelMenuWindow;
using Game.Scripts.UI.MVVM;
using Game.Scripts.UI.Root;
using Game.Scripts.UI.StartMenuWindow;

namespace Game.Scripts.UI.Controllers
{
    public class MenuUIController
    {
        private readonly UIRootViewModel _rootViewModel;

        public MenuUIController(UIRootViewModel rootViewModel)
        {
            _rootViewModel = rootViewModel;
        }

        public StartMenuViewModel OpenStartMenu()
        {
            StartMenuViewModel viewModel = new StartMenuViewModel(this);
            _rootViewModel.OpenWindow(viewModel);

            return viewModel;
        }

        public LevelMenuViewModel OpenLevelMenu()
        {
            LevelMenuViewModel viewModel = new LevelMenuViewModel(this);
            _rootViewModel.OpenWindow(viewModel);

            return viewModel;
        }
    }
}