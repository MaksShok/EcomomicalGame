using Game.Scripts.UI.MVVM;
using ObservableCollections;
using R3;
using UnityEngine;

namespace Game.Scripts.UI.Root
{
    public class UIRootBinder : MonoBehaviour
    {
        [SerializeField] 
        private UIContainer _uiContainer;
        
        private UIRootViewModel _rootViewModel;

        private readonly CompositeDisposable _subscriptions = new ();   

        public void Bind(UIRootViewModel rootViewModel)
        {
            _rootViewModel = rootViewModel;

            _subscriptions.Add(_rootViewModel.OpenedWindow
                .Subscribe(w => _uiContainer.OpenWindow(w)));
            
            foreach (ViewModel viewModel in _rootViewModel.OpenedPopups)
            {
                _uiContainer.OpenPopup(viewModel);
            }

            _subscriptions.Add(_rootViewModel.OpenedPopups.ObserveAdd()
                .Subscribe(p => _uiContainer.OpenPopup(p.Value)));

            _subscriptions.Add(_rootViewModel.OpenedPopups.ObserveRemove()
                .Subscribe(p=> _uiContainer.ClosePopup(p.Value)));
            
        }

        private void OnDestroy()
        {
            _subscriptions.Dispose();
        }
    }
}