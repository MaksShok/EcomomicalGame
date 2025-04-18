using Game.Scripts.DialogData;

namespace Game.Scripts.EnterExitParams.GameplayScene
{
    public class GameplayEnterParams
    {
        public readonly string SceneName;
        public readonly DialogDataObject DialogDataObject;

        public GameplayEnterParams(string sceneName, DialogDataObject dialogData)
        {
            SceneName = sceneName;
            DialogDataObject = dialogData;
        }
    }
}