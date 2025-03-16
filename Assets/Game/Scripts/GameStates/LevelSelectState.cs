using Game.Scripts.Global;
using Game.Scripts.Interfaces;

namespace Game.Scripts.GameStates
{
    public class LevelSelectState : IState
    {
        private readonly SceneProgressService _sceneProgressService;
        private readonly SceneLoader _sceneLoader;

        public LevelSelectState(SceneProgressService sceneProgressService, SceneLoader sceneLoader)
        {
            _sceneProgressService = sceneProgressService;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _sceneLoader.LoadMenuScene(() => 
                {_sceneProgressService.CurrentSceneEntryPoint.RunScene();});
        }

        public void Exit()
        {
            _sceneProgressService.CurrentSceneEntryPoint.FinishScene();
        }
    }
}