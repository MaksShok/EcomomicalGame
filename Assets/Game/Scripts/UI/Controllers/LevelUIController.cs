using Game.Scripts.DialogData;
using Game.Scripts.DialogMechanics;
using Game.Scripts.EntryPoints;
using Game.Scripts.UI.Popups.DialogFinishPopup;
using Game.Scripts.UI.Popups.DialogPopap;
using Game.Scripts.UI.Root;
using Game.Scripts.UI.Windows.GameplayWindow;
using UnityEngine.Rendering;
using Zenject;

namespace Game.Scripts.UI.Controllers
{
    public class LevelUIController
    {
        private readonly UIRootViewModel _rootViewModel;
        private readonly DiContainer _container;

        public LevelUIController(UIRootViewModel rootViewModel, DiContainer container)
        {
            _rootViewModel = rootViewModel;
            _container = container;
        }

        public GameplayWindowViewModel OpenGameplayWindow()
        {
            GameplayWindowViewModel viewModel = new GameplayWindowViewModel(_container.Resolve<FirstLevelEntryPoint>(),
                _container.Resolve<TextAssetsManager>());
            _rootViewModel.OpenWindow(viewModel);

            return viewModel;
        }

        public DialogViewModel OpenDialogPopup()
        {
            DialogViewModel viewModel = new DialogViewModel(
                _container.Resolve<TextAssetsManager>());
            _rootViewModel.OpenPopup(viewModel);

            return viewModel;
        }

        public NegativeEndingViewModel OpenNegativeEndingPopup()
        {
            NegativeEndingViewModel viewModel = new NegativeEndingViewModel(
                _container.Resolve<FirstLevelEntryPoint>());
            _rootViewModel.OpenPopup(viewModel);

            return viewModel;
        }
        
        public PositiveEndingViewModel OpenPositiveEndingPopup()
        {
            PositiveEndingViewModel viewModel = new PositiveEndingViewModel(
                _container.Resolve<FirstLevelEntryPoint>());
            _rootViewModel.OpenPopup(viewModel);

            return viewModel;
        }
    }
}