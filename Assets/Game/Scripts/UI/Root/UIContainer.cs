using System.Collections.Generic;
using Game.Scripts.UI.MVVM;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI.Root
{
    public class UIContainer : MonoBehaviour
    {
        [SerializeField] private Transform _windowContainer;
        [SerializeField] private Transform _popupsContainer;

        [Inject] 
        private ViewFactory _viewFactory;

        private IView _openedWindow;
        private Dictionary<ViewModel, IView> _openedPopups = new();

        public void OpenWindow(ViewModel viewModel)
        {
            if (viewModel == null)
                return;
            
            _openedWindow?.Unbind();

            IView view = _viewFactory.InstantiateWindow(viewModel, _windowContainer);
            view.Bind(viewModel);

            _openedWindow = view;
        }

        private void CloseWindow()
        {
            if (_openedWindow == null)
                return;
            
            _openedWindow.Unbind();
            _openedWindow = null;
        }

        public void OpenPopup(ViewModel viewModel)
        {
            IView view = _viewFactory.InstantiatePopup(viewModel, _popupsContainer);
            view.Bind(viewModel);
            
            _openedPopups.Add(viewModel, view);
        }

        public void ClosePopup(ViewModel viewModel)
        {
            IView view = _openedPopups[viewModel];
            
            view.Unbind();
            //viewModel.CloseRequest();
            
            _openedPopups.Remove(viewModel);
        }
    }
}