using Game.Scripts.Global;
using UnityEngine;
using Zenject;

namespace Game.Scripts.EntryPoints.Abstract
{
    public abstract class SceneEntryPoint : MonoBehaviour
    {
        public static DiContainer DiContainer { get; private set; }

        [Inject] 
        private DiContainer _diContainer;

        [Inject] 
        protected CurrentSceneEntryPointService _currentSceneEntryPointService;
        
        private void Awake()
        {
            DiContainer = _diContainer;
            _currentSceneEntryPointService.InitializeEntryPoint(this);
        }

        public abstract void FinishScene();
    }
}