using Game.Scripts.EntryPoints;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class BootInstaller : MonoInstaller
    {
        [SerializeField] private BootEntryPoint _bootEntryPointPrefab;
        
        public override void InstallBindings()
        {
            StartGame();
        }

        private void StartGame()
        {
            BootEntryPoint bootEntryPoint =
                Container.InstantiatePrefabForComponent<BootEntryPoint>(_bootEntryPointPrefab);
        }
    }
}