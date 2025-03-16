using Game.Scripts.EntryPoints;
using Game.Scripts.UI.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers.Local
{
    public class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private MenuSceneEntryPoint _entryPointPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<MenuUIController>().AsSingle();
            
            InstantiateEntryPoint();
        }

        private void InstantiateEntryPoint()
        {
            MenuSceneEntryPoint entryPoint =
                Container.InstantiatePrefabForComponent<MenuSceneEntryPoint>(_entryPointPrefab);
        }
    }
}