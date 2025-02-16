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
        
        public IView InstantiateView(ViewModel viewModel, Transform root)
        {
            GameObject prefab = Resources.Load<GameObject>(GetPrefabPath(viewModel));
            IView view = _diContainer.InstantiatePrefabForComponent<IView>(prefab, root);
            return view;
        }
        
        private string GetPrefabPath(ViewModel viewModel)
        {
            return $"Prefabs/Windows/{viewModel.PrefabName}";
        }
    }
}