using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.PlayerStatMechanics
{
    public class PlayerStatsManager
    {
        private Dictionary<PlayerStat, Stat> _stats;

        public Stat FriendRelationship { get; } = new(0, PlayerStat.FriendsRelationship);
        public Stat BlackDayMoney { get; } = new(0, PlayerStat.BlackDayMoney);
        public Stat MoodCoefficient { get; } = new Stat(0, PlayerStat.Mood);
        public Stat PresentMoney { get; } = new(0, PlayerStat.PresentMoney);
        public Stat Health { get; } = new(100, PlayerStat.Health);
        public Stat Money{ get; } = new(500, PlayerStat.Money);


        public PlayerStatsManager()
        {
            _stats = new()
            {
                { PlayerStat.Health, Health},
                { PlayerStat.Money, Money},
                { PlayerStat.FriendsRelationship, FriendRelationship},
                { PlayerStat.PresentMoney, PresentMoney},
                { PlayerStat.BlackDayMoney, BlackDayMoney},
                { PlayerStat.Mood, MoodCoefficient}
            };
        }
        
        public void ChangeStat(PlayerStat statType, int changedValue)
        {
            Stat stat = _stats[statType];
            stat.Value += changedValue;

            if (stat.Value == 0)
            {
                if (stat.StatType == PlayerStat.Health)
                {
                    
                }
                else if (stat.StatType == PlayerStat.FriendsRelationship)
                {
                    
                }
            }
        }

        public bool CheckStat(PlayerStat statType, int minValue, int maxValue = Int32.MaxValue)
        {
            Stat stat = _stats[statType];
            if (minValue <= stat.Value && stat.Value <= maxValue)
                return true;
            else
                return false;
        }

        public void DistributeMoney(PlayerStat from, PlayerStat to, int value)
        {
            ChangeStat(from, value * -1);
            ChangeStat(to, value);
        }

        public void ResetStats()
        {
            FriendRelationship.Value = 0;
            BlackDayMoney.Value = 0;
            MoodCoefficient.Value = 0;
            PresentMoney.Value = 0;
            Health.Value = 100;
            Money.Value = 500;
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