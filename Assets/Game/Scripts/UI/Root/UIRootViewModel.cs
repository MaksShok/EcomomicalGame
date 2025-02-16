using System;
using System.Collections.Generic;
using Game.Scripts.UI.MVVM;
using ObservableCollections;
using R3;

namespace Game.Scripts.UI.Root
{
    public class UIRootViewModel : IDisposable
    {
        public IObservableCollection<ViewModel> ActiveViewModels => _activeViewModels;
        private ObservableList<ViewModel> _activeViewModels = new();

        private Dictionary<ViewModel, IDisposable> _subscriptions = new();

        public void OpenView(ViewModel viewModel)
        {
            if (_activeViewModels.Contains(viewModel))
            {
                return;
            }

            _activeViewModels.Add(viewModel);
            
            IDisposable subscription = viewModel.ClosedRequest.Subscribe(CloseView);
            _subscriptions.Add(viewModel, subscription);
        }

        public void CloseView(ViewModel viewModel)
        {
            if (!_activeViewModels.Contains(viewModel))
            {
                return;
            }
            
            viewModel.Dispose();
            _activeViewModels.Remove(viewModel);

            IDisposable subscription = _subscriptions[viewModel];
            subscription?.Dispose();
            _subscriptions.Remove(viewModel);
        }

        public void CloseAllView()
        {
            foreach (ViewModel viewModel in _activeViewModels)
            {
                CloseView(viewModel);
            }
        }

        public void Dispose()
        {
            CloseAllView();
        }
    }
}