using Game.Scripts.Global;
using Game.Scripts.UI.Root;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private UIRootBinder _uiRootPrefab;

        public override void InstallBindings()
        {
            Container.Bind<ViewFactory>().AsSingle();
            Container.Bind<UIRootViewModel>().AsSingle();
            Container.Bind<EventManager>().AsSingle();
            
            CreateUIRoot();
        }

        private void CreateUIRoot()
        {
            UIRootBinder uiRoot = Container.InstantiatePrefabForComponent<UIRootBinder>(_uiRootPrefab);
            Container.Bind<UIRootBinder>().FromInstance(uiRoot).AsCached();
        }
    }
}