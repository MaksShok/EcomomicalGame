using System;
using System.Collections;
using Game.Scripts.Global;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Scripts.EntryPoints
{
    public class BootEntryPoint : MonoBehaviour
    {
        [Inject]
        private void Contructor()
        {
            
        }
        
        private void Start()
        {
            StartCoroutine(LoadMenuScene());
        }

        private IEnumerator LoadMenuScene()
        {
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync("MenuScene");
            
            while (!sceneLoading.isDone)
            {
                yield return null;
            }
            
            OnSceneLoaded();
        }

        private void OnSceneLoaded()
        {
            
        }
    }
}