using Game.Scripts.EntryPoints.Abstract;
using UnityEngine;
using Zenject;

namespace Game.Scripts.EntryPoints
{
    public class BootEntryPoint : SceneEntryPoint
    {
        [Inject]
        private void Contructor()
        {
            
        }

        public override void RunScene()
        {
            
        }

        public override void FinishScene()
        {
            Destroy(gameObject);
        }
    }
}