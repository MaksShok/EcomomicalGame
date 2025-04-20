using System;
using R3;
using UnityEngine;
using UnityEngine.Rendering;

namespace Game.Scripts.PlayerStatMechanics
{
    public class Stat
    {
        public event Action<float> ValueChanged;
        
        public float Value {
            get { return _value;}
            set {
                if (CanLessZero) _value += value;
                else _value = Mathf.Max(0, _value + value);
                ValueChanged?.Invoke(_value);
            }
        }

        public PlayerStat StatType { get; }
        public bool CanLessZero { get; }
        public int TargetValue { get; }
        public float DefaultValue { get; }

        private float _value;

        public Stat(int startValue, PlayerStat statType, int targetValue, bool canLessZero = false)
        {
            _value = startValue;
            StatType = statType;
            TargetValue = targetValue;
            DefaultValue = startValue;
            CanLessZero = canLessZero;
        }
    }
}