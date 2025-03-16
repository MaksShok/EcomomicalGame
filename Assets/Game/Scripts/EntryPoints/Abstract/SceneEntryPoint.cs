using Game.Scripts.Global;
using UnityEngine;
using Zenject;

namespace Game.Scripts.EntryPoints.Abstract
{
    public abstract class SceneEntryPoint : MonoBehaviour
    {
        [Inject] 
        private SceneProgressService _sceneProgressService;

        private void Awake()
        {
            _sceneProgressService.InitializeEntryPoint(this);
        }

        public abstract void RunScene();

        public abstract void FinishScene();
    }
}