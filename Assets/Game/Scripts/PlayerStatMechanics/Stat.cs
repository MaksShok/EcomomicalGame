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
            set
            {
                _value = value;
                if (_value > MaxValue) _value = MaxValue;
                else if (_value < MinValue) _value = MinValue;
                
                ValueChanged?.Invoke(_value);
            }
        }

        public PlayerStat StatType { get; }
        public int TargetValue { get; }
        public int MinValue { get; }
        public int MaxValue { get; }
        public float DefaultValue { get; }

        private float _value;

        public Stat(int startValue, PlayerStat statType, int targetValue, int minValue, int maxValue)
        {
            _value = startValue;
            StatType = statType;
            TargetValue = targetValue;
            MinValue = minValue;
            MaxValue = maxValue;
            DefaultValue = startValue;
        }
    }
}