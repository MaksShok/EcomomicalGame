using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Game.Scripts.PlayerStatMechanics
{
    public class PlayerStatsManager
    {
        public readonly Dictionary<PlayerStat, Stat> Stats;

        public Stat FriendRelationship { get; } = new(80, PlayerStat.FriendsRelationship, 100);
        public Stat MoodCoefficient { get; } = new(0, PlayerStat.Mood, 0, true);
        public Stat Money { get; } = new(500, PlayerStat.Money, 500, true);
        public Stat BlackDayMoney { get; } = new(0, PlayerStat.BlackDayMoney, 100);
        public Stat PresentMoney { get; } = new(0, PlayerStat.PresentMoney, 150);
        public Stat Health { get; } = new(100, PlayerStat.Health, 100);


        public PlayerStatsManager()
        {
            Stats = new()
            {
                { PlayerStat.Health, Health},
                { PlayerStat.Money, Money},
                { PlayerStat.FriendsRelationship, FriendRelationship},
                { PlayerStat.PresentMoney, PresentMoney},
                { PlayerStat.BlackDayMoney, BlackDayMoney},
                { PlayerStat.Mood, MoodCoefficient}
            };
        }
        
        public void ChangeStat(PlayerStat statType, string changedValueString)
        {
            char operationSymbol = changedValueString[0];
            changedValueString = changedValueString.Substring(1);
            Stat stat = Stats[statType];
            
            if (!int.TryParse(changedValueString, out int changedValue))
            {
                Debug.LogError("String Value Dont Parsed!!!!");
                return;
            }
            
            if (operationSymbol == '+') stat.Value += changedValue;
            else if (operationSymbol == '-') stat.Value -= changedValue;
            else if (operationSymbol == '=') stat.Value = changedValue;
            else if (operationSymbol == '*') stat.Value *= changedValue;
            else if (operationSymbol == '/') stat.Value /= changedValue;
        }

        public bool CheckStat(PlayerStat statType, int minValue, int maxValue = Int32.MaxValue)
        {
            Stat stat = Stats[statType];
            if (minValue <= stat.Value && stat.Value <= maxValue)
                return true;
            else
                return false;
        }

        public void DistributeMoney(PlayerStat from, PlayerStat to, int value)
        {
            Stat fromStat = Stats[from];
            Stat toStat = Stats[to];

            fromStat.Value -= value;
            toStat.Value += value;
        }

        public void ResetStats()
        {
            FriendRelationship.Value = FriendRelationship.DefaultValue;
            BlackDayMoney.Value = BlackDayMoney.DefaultValue;
            MoodCoefficient.Value = MoodCoefficient.DefaultValue;
            PresentMoney.Value = PresentMoney.DefaultValue;
            Health.Value = Health.DefaultValue;
            Money.Value = Money.DefaultValue;
        }
    }

    public enum PlayerStat
    {
        None = 0,
        Money = 1,
        BlackDayMoney = 2,
        PresentMoney = 3,
        FriendsRelationship = 4,
        Health = 5,
        Mood = 6,
    }
}