using Game.Scripts.GameStates;
using Game.Scripts.Global;
using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.MVVM;

namespace Game.Scripts.UI.Windows.LevelMenuWindow
{
    public class LevelMenuViewModel : ViewModel
    {
        public override string PrefabName => "LevelMenu";

        private readonly MenuUIController _uiController;
        private readonly GameStateMachine _stateMachine;

        public LevelMenuViewModel(MenuUIController uiController, GameStateMachine stateMachine)
        {
            _uiController = uiController;
            _stateMachine = stateMachine;
        }

        public void StartMoneySaveLevelRequest()
        {
            // Тут по идеи должна быть передача параметра - ScriptableObject который ))))
            _stateMachine.Enter<GameLoopState>();
        }

        public void ExitToStartMenuRequest()
        {
            _stateMachine.Enter<ShowStartMenuState>();
        }
    }
}