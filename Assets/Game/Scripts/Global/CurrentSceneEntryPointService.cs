using Game.Scripts.EntryPoints.Abstract;
using UnityEngine;

namespace Game.Scripts.Global
{
    public class CurrentSceneEntryPointService
    {
        private SceneEntryPoint _currentSceneEntryPoint;

        public void InitializeEntryPoint(SceneEntryPoint entryPoint)
        {
            _currentSceneEntryPoint = entryPoint;
        }

        public T GetEntryPoint<T>() where T : SceneEntryPoint
        {
            if (_currentSceneEntryPoint is T TentryPoint)
            {
                return TentryPoint;
            }
            else
            {
                Debug.LogError($"CurrentSceneEntryPoint is not of type {typeof(T)}.");
                return null;
            }
        }

        public void FinishSceneRequest()
        {
            _currentSceneEntryPoint.FinishScene();
        }
    }
}