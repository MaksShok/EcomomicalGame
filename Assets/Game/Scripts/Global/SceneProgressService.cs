using Game.Scripts.EntryPoints.Abstract;

namespace Game.Scripts.Global
{
    public class SceneProgressService
    {
        public SceneEntryPoint CurrentSceneEntryPoint
        {
            get { return _currentSceneEntryPoint; }
            private set { }
        }
        
        private SceneEntryPoint _currentSceneEntryPoint;

        public void InitializeEntryPoint(SceneEntryPoint entryPoint)
        {
            _currentSceneEntryPoint = entryPoint;
        }
    }
}