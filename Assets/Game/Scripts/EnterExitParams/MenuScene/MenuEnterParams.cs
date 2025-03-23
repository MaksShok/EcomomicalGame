namespace Game.Scripts.EnterExitParams.MenuScene
{
    public class MenuEnterParams
    {
        public readonly bool LevelIsCompleted;

        public MenuEnterParams(bool levelIsCompleted)
        {
            LevelIsCompleted = levelIsCompleted;
        }
    }
}