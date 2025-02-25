using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Global
{
    public class EventManager
    {
        private Dictionary<string, List<object>> _actions = new();

        public void Subscribe<T>(Action<T> action, int order = default)
        {
            string key = typeof(T).Name;

            if (!_actions.ContainsKey(key))
            {
                List<object> list = new List<object>();
                _actions.Add(key, list);
            }
            
            _actions[key].Add(action);
        }

        public void UnSubscribe<T>(Action<T> action)
        {
            string key = typeof(T).Name;
            
            if (!_actions.ContainsKey(key))
            {
                Debug.LogError($"Key - {key} Not found!!! ~ UnSubscribe");
                return;
            }

            List<object> list = _actions[key];
            if (list.Contains(action))
            {
                list.Remove(action);
            }
        }

        public void Invoke<T>(T eventObject)
        {
            string key = typeof(T).Name;

            if (_actions.TryGetValue(key, out List<object> list))
            {
                foreach(object obj in list)
                {
                    Action<T> action = obj as Action<T>;
                    action?.Invoke(eventObject);
                }
            }
            else
            {
                Debug.LogError($"Key - {key} Not found!!! ~ Invoke");
                return;
            }
        }
    }
}