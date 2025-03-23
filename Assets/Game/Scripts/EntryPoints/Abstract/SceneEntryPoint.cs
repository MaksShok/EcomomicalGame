using Game.Scripts.Global;
using UnityEngine;
using Zenject;

namespace Game.Scripts.EntryPoints.Abstract
{
    public abstract class SceneEntryPoint : MonoBehaviour
    {
        [Inject] 
        protected CurrentSceneEntryPointService _currentSceneEntryPointService;

        private void Awake()
        {
            _currentSceneEntryPointService.InitializeEntryPoint(this);
        }

        public abstract void FinishScene();
    }
}