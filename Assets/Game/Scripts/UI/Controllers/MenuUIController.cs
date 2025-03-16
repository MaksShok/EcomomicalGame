using Game.Scripts.Global;
using Game.Scripts.UI.MVVM;
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
            StartMenuViewModel viewModel = new StartMenuViewModel(_container.Resolve<GameStateMachine>());
            _rootViewModel.OpenWindow(viewModel);

            return viewModel;
        }

        public LevelMenuViewModel OpenLevelMenu()
        {
            LevelMenuViewModel viewModel = new LevelMenuViewModel(this, _container.Resolve<GameStateMachine>());
            _rootViewModel.OpenWindow(viewModel);

            return viewModel;
        }
    }
}