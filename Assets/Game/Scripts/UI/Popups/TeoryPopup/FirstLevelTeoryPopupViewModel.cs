using Game.Scripts.UI.MVVM;
using UnityEngine;

namespace Game.Scripts.UI.Popups.TeoryPopup
{
    public class FirstLevelTeoryPopupViewModel : TeoryViewModel
    {
        public const string Path = "TeoryData/FirstLevelTeory";

        public FirstLevelTeoryPopupViewModel()
        {
            TitleText = "Накопления и сбережения средств";
            TextAsset textAsset = Resources.Load<TextAsset>(Path);
            MainText = textAsset.text;
        }
    }
}