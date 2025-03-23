using Game.Scripts.EnterExitParams.GameplayScene;
using Game.Scripts.EnterExitParams.MenuScene;
using Game.Scripts.EntryPoints;

namespace Game.Scripts.UI.Popups.DialogFinishPopup
{
    public class NegativeEndingViewModel : LevelFinishViewModelAbstract
    {
        public override string TitleText => negativeTitleText;
        public override string MainText => negativeMainText;

        private string negativeTitleText = "Перечитай теорию и попробуй еще раз. У тебя получится!";

        private string negativeMainText = "На практике все сложнее!";

        public NegativeEndingViewModel(GameplayEntryPoint gameplayEntryPoint) : base(gameplayEntryPoint)
        {
        }

        public override void GoToLevelMenuRequest()
        {
            MenuEnterParams menuEnterParams = new MenuEnterParams(false);
            GameplayExitParams gameplayExitParams = new GameplayExitParams(menuEnterParams);
            
            GameplayEntryPoint.ExitSceneRequest(gameplayExitParams);
        }
    }
}