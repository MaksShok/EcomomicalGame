using Game.Scripts.EnterExitParams.GameplayScene;

namespace Game.Scripts.EnterExitParams.MenuScene
{
    public class MenuExitParams
    {
        public GameplayEnterParams GameplayEnterParams;

        public MenuExitParams(GameplayEnterParams gameplayEnterParams)
        {
            GameplayEnterParams = gameplayEnterParams;
        }
    }
}