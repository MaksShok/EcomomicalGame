using Game.Scripts.EntryPoints.Abstract;
using Game.Scripts.Global;
using Game.Scripts.UI.Root;
using UnityEngine;
using Zenject;

namespace Game.Scripts.EntryPoints
{
    public class BootEntryPoint : SceneEntryPoint
    {
        private UIRootViewModel _rootViewModel;
        private UIRootBinder _uiRootBinder;
        private SceneLoader _sceneLoader;
        
        [Inject]
        private void Contructor(UIRootBinder uiRootBinder, UIRootViewModel rootViewModel
        , SceneLoader sceneLoader)
        {
            _rootViewModel = rootViewModel;
            _uiRootBinder = uiRootBinder;
            _sceneLoader = sceneLoader;
        }

        private void Start()
        {
            RunScene();
        }

        public void RunScene()
        {
            _uiRootBinder.Bind(_rootViewModel);
            _sceneLoader.LoadMenuSceneFromBoot();
        }

        public override void FinishScene()
        {
            
        }
    }
}