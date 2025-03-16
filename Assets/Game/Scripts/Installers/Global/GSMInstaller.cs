using Game.Scripts.GameStates;
using Game.Scripts.Global;
using Zenject;

namespace Game.Scripts.Installers.Global
{
    public class GSMInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle().NonLazy();

            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<ShowStartMenuState>().AsSingle();
            Container.Bind<LevelSelectState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
        }
    }
}