using Game.Scripts.GameStates;
using Game.Scripts.Global;
using Game.Scripts.UI.MVVM;

namespace Game.Scripts.UI.Popups.DialogFinishPopup
{
    public abstract class LevelFinishViewModelAbstract : ViewModel
    {
        public override string PrefabName => "LevelFinishView";

        public abstract string TitleText { get; }
        public abstract string MainText { get; }

        protected readonly GameStateMachine _stateMachine;

        public LevelFinishViewModelAbstract(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void GoToLevelMenuRequest()
        {
            _stateMachine.Enter<LevelSelectState>();
        }
    }
}