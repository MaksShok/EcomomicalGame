using Game.Scripts.EnterExitParams.GameplayScene;
using Game.Scripts.EnterExitParams.MenuScene;
using Game.Scripts.EntryPoints;

namespace Game.Scripts.UI.Popups.DialogFinishPopup
{
    public class PositiveEndingViewModel : LevelFinishViewModelAbstract
    {
        public override string TitleText => positiveTitleText;
        public override string MainText => positiveMainText;

        private string positiveTitleText = "Ты отлично усвоил урок!";

        private string positiveMainText = "Можешь переходить к следующим уровням. И не забывай читать теорию!";

        public PositiveEndingViewModel(GameplayEntryPoint entryPoint) : base(entryPoint) 
        {
        }

        public override void GoToLevelMenuRequest()
        {
            MenuEnterParams menuEnterParams = new MenuEnterParams(true);
            GameplayExitParams gameplayExitParams = new GameplayExitParams(menuEnterParams);
            
            GameplayEntryPoint.ExitSceneRequest(gameplayExitParams);
        }
    }
}