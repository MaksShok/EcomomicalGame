using Game.Scripts.EntryPoints;
using Game.Scripts.GameStates;
using Game.Scripts.UI.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private MenuSceneEntryPoint _entryPointPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<MenuUIController>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
            
            RunScene();
        }

        private void RunScene()
        {
            MenuSceneEntryPoint entryPoint =
                Container.InstantiatePrefabForComponent<MenuSceneEntryPoint>(_entryPointPrefab);

            Container.Bind<MenuSceneEntryPoint>().FromInstance(entryPoint);
        }
    }
}