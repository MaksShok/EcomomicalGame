using Game.Scripts.Global;

namespace Game.Scripts.UI.Popups.DialogFinishPopup
{
    public class PositiveEndingViewModel : LevelFinishViewModelAbstract
    {
        public override string TitleText => positiveTitleText;
        public override string MainText => positiveMainText;

        private string positiveTitleText = "Ты отлично усвоил урок!";
        private string positiveMainText = "Ты реально молодец";

        public PositiveEndingViewModel(GameStateMachine stateMachine) : base(stateMachine) 
        {
            
        }
    }
}