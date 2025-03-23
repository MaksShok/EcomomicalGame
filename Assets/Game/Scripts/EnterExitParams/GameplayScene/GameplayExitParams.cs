using Game.Scripts.EnterExitParams.MenuScene;

namespace Game.Scripts.EnterExitParams.GameplayScene
{
    public class GameplayExitParams
    {
        public MenuEnterParams MenuEnterParams;

        public GameplayExitParams(MenuEnterParams menuEnterParams)
        {
            MenuEnterParams = menuEnterParams;
        }
    }
}