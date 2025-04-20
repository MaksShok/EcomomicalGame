using Game.Scripts.DialogData;
using Game.Scripts.DialogMechanics;
using Game.Scripts.EntryPoints;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Popups.DialogFinishPopup;
using Game.Scripts.UI.Popups.DialogPopap;
using Game.Scripts.UI.Popups.StatsPopup;
using Game.Scripts.UI.Root;
using Game.Scripts.UI.Windows.GameplayWindow;
using UnityEngine.Rendering;
using Zenject;

namespace Game.Scripts.UI.Controllers
{
    public class FirstLevelUIController
    {
        private readonly UIRootViewModel _rootViewModel;
        private readonly DiContainer _container;

        public FirstLevelUIController(UIRootViewModel rootViewModel, DiContainer container)
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

        public DialogViewModel OpenDialogPopup(DialogDataObject dialogData)
        {
            DialogViewModel viewModel = new DialogViewModel(
                _container.Resolve<TextAssetsManager>(), _container.Resolve<DialogManager>(), dialogData);
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

        public StatsViewModel OpenStatsPopap(DialogDataObject dialogData)
        {
            StatsViewModel viewModel = new StatsViewModel(_container.Resolve<PlayerStatsManager>(), dialogData);
            _rootViewModel.OpenPopup(viewModel);

            return viewModel;
        }
    }
}