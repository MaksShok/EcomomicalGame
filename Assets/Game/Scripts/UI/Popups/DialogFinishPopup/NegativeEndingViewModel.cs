using Game.Scripts.Global;

namespace Game.Scripts.UI.Popups.DialogFinishPopup
{
    public class NegativeEndingViewModel : LevelFinishViewModelAbstract
    {
        public override string TitleText => negativeTitleText;
        public override string MainText => negativeMainText;
        
        private string negativeTitleText = "Перечитай теорию и попробуй еще раз. У тебя получится!";
        private string negativeMainText = "На практике все сложнее!";

        public NegativeEndingViewModel(GameStateMachine stateMachine) : base(stateMachine)
        {
            
        }
    }
}