using Game.Scripts.DialogData;
using Game.Scripts.EnterExitParams.GameplayScene;
using Game.Scripts.EnterExitParams.MenuScene;
using Game.Scripts.EntryPoints;
using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Windows.LevelMenuWindow
{
    public class LevelMenuViewModel : ViewModel
    {
        public override string PrefabName => "LevelMenu";

        private readonly MenuUIController _uiController;
        private readonly MenuEntryPoint _entryPoint;

        public LevelMenuViewModel(MenuUIController uiController, MenuEntryPoint entryPoint)
        {
            _uiController = uiController;
            _entryPoint = entryPoint;
        }

        public void StartMoneySaveLevelRequest()
        {
            DialogDataObject dialogDataObject = Resources.Load<DialogDataObject>("DialogObjects/SaveMoneyDialogData");
            GameplayEnterParams gameplayEnterParams = new GameplayEnterParams(dialogDataObject);
            MenuExitParams menuExitParams = new MenuExitParams(gameplayEnterParams);
            
            _entryPoint.ExitSceneRequest(menuExitParams);
        }
        
        public void ShowSaveMoneyLevelTeoryRequest()
        {
            _uiController.OpenTeoryPopup();
        }

        public void ExitToStartMenuRequest()
        {
            _uiController.OpenStartMenu();
        }
    }
}