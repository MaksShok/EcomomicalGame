using UnityEngine;

namespace Game.Scripts.MVVM
{
    public abstract class View<TViewModel> : MonoBehaviour, IView 
        where TViewModel : ViewModel
    {
        protected TViewModel ViewModel;

        public void Bind(ViewModel viewModel)
        {
            Unbind();
            ViewModel = (TViewModel) viewModel;
            OnBindViewModel();
        }

        public void Unbind()
        {
            if (ViewModel != null)
            {
                OnUnBindViewModel();
                ViewModel = null;
            }
        }

        protected virtual void OnBindViewModel() { }

        protected virtual void OnUnBindViewModel() { }
    }
}