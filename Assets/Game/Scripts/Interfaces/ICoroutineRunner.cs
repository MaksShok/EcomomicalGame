using System.Collections;
using UnityEngine;

namespace Game.Scripts.Interfaces
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator enumerator);
    }
}