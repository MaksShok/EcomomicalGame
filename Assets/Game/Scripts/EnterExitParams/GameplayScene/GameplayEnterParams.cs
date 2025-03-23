using Game.Scripts.DialogData;

namespace Game.Scripts.EnterExitParams.GameplayScene
{
    public class GameplayEnterParams
    {
        public readonly DialogDataObject DialogDataObject;

        public GameplayEnterParams(DialogDataObject dialogData)
        {
            DialogDataObject = dialogData;
        }
    }
}