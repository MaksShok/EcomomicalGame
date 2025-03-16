using Game.Scripts.EntryPoints.Abstract;
using Game.Scripts.UI.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.EntryPoints
{
    public class MenuSceneEntryPoint : SceneEntryPoint
    {
        private MenuUIController _uiController;

        [Inject]
        private void Constructor(MenuUIController uiController)
        {
            _uiController = uiController;
        }

        public void OpenStartMenu()
        {
            _uiController.OpenStartMenu();
        }

        public override void RunScene()
        {
            _uiController.OpenLevelMenu();
        }

        public override void FinishScene()
        {
            
        }
    }
}