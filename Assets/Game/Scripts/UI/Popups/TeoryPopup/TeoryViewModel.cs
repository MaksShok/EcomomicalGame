using Game.Scripts.UI.MVVM;

namespace Game.Scripts.UI.Popups.TeoryPopup
{
    public class TeoryViewModel : ViewModel
    {
        public override string PrefabName => "TeoryPopap";
        
        public string TitleText { get; protected set; }
        public  string MainText { get; protected set; }
    }
}