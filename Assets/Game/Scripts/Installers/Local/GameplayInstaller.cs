using Game.Scripts.DialogMechanics;
using Game.Scripts.EntryPoints;
using Game.Scripts.UI.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers.Local
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameplayEntryPoint _entryPoint;
        
        public override void InstallBindings()
        {
            Container.Bind<LevelUIController>().AsSingle();
            Container.Bind<TextAssetsManager>().AsSingle();
            Container.Bind<EndingStoryManager>().AsSingle();
            
            InstantiateEntryPoint();
        }

        private void InstantiateEntryPoint()
        {
            GameplayEntryPoint entryPoint = Container
                .InstantiatePrefabForComponent<GameplayEntryPoint>(_entryPoint);

            Container.Bind<GameplayEntryPoint>().FromInstance(entryPoint).AsSingle();
        }
    }
}