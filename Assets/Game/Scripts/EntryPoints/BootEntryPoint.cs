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
            Debug.Log("Boot сцена стратовала");
        }

        public override void FinishScene()
        {
            Debug.Log("Boot сцена Завершилась");
            Destroy(gameObject);
        }
    }
}