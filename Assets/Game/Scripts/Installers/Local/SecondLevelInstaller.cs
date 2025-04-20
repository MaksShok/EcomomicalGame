using Game.Scripts.DialogMechanics;
using Game.Scripts.DialogMechanics.EndManagers;
using Game.Scripts.EntryPoints;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers.Local
{
    public class SecondLevelInstaller : MonoInstaller
    {
        [SerializeField] private SecondLevelEntryPoint _entryPoint;
        
        public override void InstallBindings()
        {
            Container.Bind<SecondLevelUIController>().AsSingle();
            Container.Bind<TextAssetsManager>().AsSingle();
            Container.Bind<DialogManager>().AsSingle();
            Container.Bind<EndingManager>().To<SecondLevelEndingManager>().AsSingle();
            Container.Bind<PlayerStatsManager>().AsSingle();
            
            InstantiateEntryPoint();
        }

        private void InstantiateEntryPoint()
        {
            SecondLevelEntryPoint entryPoint = Container
                .InstantiatePrefabForComponent<SecondLevelEntryPoint>(_entryPoint);

            Container.Bind<SecondLevelEntryPoint>().FromInstance(entryPoint).AsSingle();
        }
    }
}