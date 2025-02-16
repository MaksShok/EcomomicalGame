using System.Collections.Generic;
using Game.Scripts.UI.MVVM;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI.Root
{
    public class UIContainer : MonoBehaviour
    {
        [Inject] 
        private ViewFactory _viewFactory;

        private Dictionary<ViewModel, IView> _openedViews = new();

        public void OpenView(ViewModel viewModel)
        {
            IView view = _viewFactory.InstantiateView(viewModel, transform);
            view.Bind(viewModel);
            
            _openedViews.Add(viewModel, view);
        }
        
        public void CloseView(ViewModel viewModel)
        {
            IView view = _openedViews[viewModel];
            
            view.Unbind();
            viewModel.CloseRequest();
            
            _openedViews.Remove(viewModel);
        }
    }
}