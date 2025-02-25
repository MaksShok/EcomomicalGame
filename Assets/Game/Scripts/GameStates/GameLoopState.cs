using Game.Scripts.UI.Controllers;
using Game.Scripts.UI.Root;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.GameStates
{
    public class GameLoopState
    {
        private readonly MenuUIController _uiController;

        public GameLoopState(MenuUIController uiController)
        {
            _uiController = uiController;
        }
        
        public void Enter()
        {
            _uiController.OpenStartMenu();
        }

        public void Exit()
        {
            
        }
    }
}