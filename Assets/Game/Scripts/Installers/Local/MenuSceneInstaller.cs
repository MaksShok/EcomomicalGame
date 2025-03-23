using Game.Scripts.EntryPoints;
using Game.Scripts.UI.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers.Local
{
    public class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private MenuEntryPoint _entryPointPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<MenuUIController>().AsSingle();
            
            InstantiateEntryPoint();
        }

        private void InstantiateEntryPoint()
        {
            MenuEntryPoint entryPoint =
                Container.InstantiatePrefabForComponent<MenuEntryPoint>(_entryPointPrefab);
            
            Container.Bind<MenuEntryPoint>().FromInstance(entryPoint).AsSingle();
        }
    }
}