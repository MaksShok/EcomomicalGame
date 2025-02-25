using System;
using System.Collections.Generic;
using Game.Scripts.UI.MVVM;
using ObservableCollections;
using R3;

namespace Game.Scripts.UI.Root
{
    public class UIRootViewModel : IDisposable
    {
        public ReadOnlyReactiveProperty<ViewModel> OpenedWindow => _openedWindow;
        public IObservableCollection<ViewModel> OpenedPopups => _openedPopups;

        private ReactiveProperty<ViewModel> _openedWindow = new();
        private ObservableList<ViewModel> _openedPopups = new();
        
        private Dictionary<ViewModel, IDisposable> _popupSubscriptions = new();

        public void OpenWindow(ViewModel viewModel)
        {
            _openedWindow.Value?.Dispose();
            _openedWindow.Value = viewModel;
        }
        
        public void OpenPopup(ViewModel viewModel)
        {
            if (_openedPopups.Contains(viewModel))
            {
                return;
            }

            _openedPopups.Add(viewModel);
            
            IDisposable subscription = viewModel.ClosedRequest.Subscribe(ClosePopup);
            _popupSubscriptions.Add(viewModel, subscription);
        }

        private void ClosePopup(ViewModel viewModel)
        {
            if (!_openedPopups.Contains(viewModel))
            {
                return;
            }
            
            viewModel.Dispose();
            _openedPopups.Remove(viewModel);

            IDisposable subscription = _popupSubscriptions[viewModel];
            subscription?.Dispose();
            _popupSubscriptions.Remove(viewModel);
        }

        public void CloseAllUI()
        {
            foreach (ViewModel viewModel in _openedPopups)
            {
                ClosePopup(viewModel);
            }

            _openedWindow.Value?.Dispose();
        }

        public void Dispose()
        {
            CloseAllUI();
        }
    }
}