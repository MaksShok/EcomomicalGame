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

            foreach (ViewModel viewModel in _rootViewModel.ActiveViewModels)
            {
                _uiContainer.OpenView(viewModel);
            }

            _subscriptions.Add(_rootViewModel.ActiveViewModels.ObserveAdd()
                .Subscribe(e => _uiContainer.OpenView(e.Value)));

            _subscriptions.Add(_rootViewModel.ActiveViewModels.ObserveRemove()
                .Subscribe(e=> _uiContainer.CloseView(e.Value)));
            
        }

        private void OnDestroy()
        {
            _subscriptions.Dispose();
        }
    }
}