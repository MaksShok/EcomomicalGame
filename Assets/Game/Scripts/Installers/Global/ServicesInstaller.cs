using Game.Scripts.Global;
using Game.Scripts.Interfaces;
using Game.Scripts.UI.Root;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers.Global
{
    public class ServicesInstaller : MonoInstaller
    {
        [SerializeField] private UIRootBinder _uiRootPrefab;

        public override void InstallBindings()
        {
            Container.Bind<ViewFactory>().AsSingle();
            Container.Bind<UIRootViewModel>().AsSingle();
            Container.Bind<EventManager>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            Container.Bind<CurrentSceneEntryPointService>().AsSingle();
            
            CreateUIRoot();
        }

        private void CreateUIRoot()
        {
            UIRootBinder uiRoot = Container.InstantiatePrefabForComponent<UIRootBinder>(_uiRootPrefab);
            Container.Bind<UIRootBinder>().FromInstance(uiRoot).AsSingle();
            
            Container.Bind<ICoroutineRunner>().FromInstance(uiRoot).AsSingle();
        }
    }
}