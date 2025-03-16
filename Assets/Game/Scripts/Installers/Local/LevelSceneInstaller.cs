using Game.Scripts.EntryPoints;
using Game.Scripts.UI.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers.Local
{
    public class LevelSceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelSceneEntryPoint _entryPoint;
        
        public override void InstallBindings()
        {
            Container.Bind<LevelUIController>().AsSingle();
            
            InstantiateEntryPoint();
        }

        private void InstantiateEntryPoint()
        {
            LevelSceneEntryPoint entryPoint = Container
                .InstantiatePrefabForComponent<LevelSceneEntryPoint>(_entryPoint);
        }
    }
}