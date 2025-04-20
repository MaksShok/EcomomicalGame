using Game.Scripts.EntryPoints;
using Game.Scripts.UI.MVVM;

namespace Game.Scripts.UI.Popups.DialogFinishPopup
{
    public abstract class LevelFinishViewModelAbstract : ViewModel
    {
        public override string PrefabName => "LevelFinishView";

        public abstract string TitleText { get; }
        public abstract string MainText { get; }

        protected readonly GameplayEntryPoint GameplayEntryPoint;

        public LevelFinishViewModelAbstract(GameplayEntryPoint gameplayEntryPoint)
        {
            GameplayEntryPoint = gameplayEntryPoint;
        }

        public abstract void GoToLevelMenuRequest();
    }
}