using Game.Scripts.UI.MVVM;
using UnityEngine;

namespace Game.Scripts.UI.Popups.TeoryPopup
{
    public class SecondLevelTeoryPopupViewModel : TeoryViewModel
    {
        public const string Path = "TeoryData/SecondLevelTeory";

        public SecondLevelTeoryPopupViewModel()
        {
            TitleText = "Финансовая грамотность";
            TextAsset textAsset = Resources.Load<TextAsset>(Path);
            MainText = textAsset.text;
        }
    }
}