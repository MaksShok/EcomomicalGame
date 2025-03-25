using Game.Scripts.EntryPoints;
using Game.Scripts.UI.Popups.TeoryPopup;
using Game.Scripts.UI.Root;
using Game.Scripts.UI.Windows.LevelMenuWindow;
using Game.Scripts.UI.Windows.StartMenuWindow;
using Zenject;

namespace Game.Scripts.UI.Controllers
{
    public class MenuUIController
    {
        private readonly UIRootViewModel _rootViewModel;
        private readonly DiContainer _container;

        public MenuUIController(UIRootViewModel rootViewModel, DiContainer container)
        {
            _rootViewModel = rootViewModel;
            _container = container;
        }

        public StartMenuViewModel OpenStartMenu()
        {
            StartMenuViewModel viewModel = new StartMenuViewModel(this);
            _rootViewModel.OpenWindow(viewModel);

            return viewModel;
        }

        public LevelMenuViewModel OpenLevelMenu()
        {
            LevelMenuViewModel viewModel = new LevelMenuViewModel(this, 
                _container.Resolve<MenuEntryPoint>());
            _rootViewModel.OpenWindow(viewModel);

            return viewModel;
        }

        public TeoryPopupViewModel OpenTeoryPopup()
        {
            TeoryPopupViewModel viewModel = new TeoryPopupViewModel();
            _rootViewModel.OpenPopup(viewModel);

            return viewModel;
        }
    }
}