using Game.Scripts.GameStates;
using Game.Scripts.Global;
using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.MVVM;

namespace Game.Scripts.UI.Windows.StartMenuWindow
{
    public class StartMenuViewModel : ViewModel
    {
        public override string PrefabName => "StartMenu";

        private readonly GameStateMachine _stateMachine;

        public StartMenuViewModel(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void OpenLevelMenuRequest()
        {
            _stateMachine.Enter<LevelSelectState>();
        }
    }
}