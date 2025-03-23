using Game.Scripts.EnterExitParams.MenuScene;
using Game.Scripts.EntryPoints.Abstract;
using Game.Scripts.Global;
using Game.Scripts.UI.Controllers;
using R3;
using UnityEngine;
using Zenject;

namespace Game.Scripts.EntryPoints
{
    public class MenuEntryPoint : SceneEntryPoint
    {
        private Subject<MenuExitParams> _exitSceneSignalSubj;
        
        private MenuUIController _uiController;

        [Inject]
        private void Constructor(MenuUIController uiController)
        {
            _uiController = uiController;
        }

        public Observable<MenuExitParams> RunScene(MenuEnterParams menuEnterParams)
        {
            if (menuEnterParams == null)
                _uiController.OpenStartMenu();
            else
                _uiController.OpenLevelMenu();

            _exitSceneSignalSubj = new Subject<MenuExitParams>();
            return _exitSceneSignalSubj;
        }

        public override void FinishScene()
        {
            
        }

        public void ExitSceneRequest(MenuExitParams exitParams)
        {
            _exitSceneSignalSubj.OnNext(exitParams);
        }
    }
}