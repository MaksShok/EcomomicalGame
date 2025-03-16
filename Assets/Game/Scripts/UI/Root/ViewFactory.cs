using Game.Scripts.UI.MVVM;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI.Root
{
    public class ViewFactory
    {
        private readonly DiContainer _diContainer;

        public ViewFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public IView InstantiateWindow(ViewModel viewModel, Transform root)
        {
            GameObject prefab = Resources.Load<GameObject>(GetWindowPrefabPath(viewModel));
            return Instantiate(prefab, root);
        }
        
        public IView InstantiatePopup(ViewModel viewModel, Transform root)
        {
            GameObject prefab = Resources.Load<GameObject>(GetPopupPrefabPath(viewModel));
            return Instantiate(prefab, root);
        }

        private IView Instantiate(GameObject prefab, Transform root)
        {
            IView view = _diContainer.InstantiatePrefabForComponent<IView>(prefab, root);
            return view;
        }
        
        private string GetWindowPrefabPath(ViewModel viewModel)
        {
            return $"Prefabs/Windows/{viewModel.PrefabName}";
        }
        
        private string GetPopupPrefabPath(ViewModel viewModel)
        {
            return $"Prefabs/Popups/{viewModel.PrefabName}";
        }
    }
}