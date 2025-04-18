namespace Game.Scripts.PlayerStatMechanics
{
    public class Stat
    {
        public Stat(int startValue, PlayerStat statType)
        {
            Value = startValue;
            StatType = statType;
        }
        
        public int Value;
        public PlayerStat StatType;
    }
}