namespace _Root.Scripts.Models
{
    public class Health
    {
        public float MaxHP { get; private set; }
        public float CurrentHP { get; private set; }

        public Health(float maxHp)
        {
            MaxHP = maxHp;
            CurrentHP = MaxHP;
        }

        public void RemoveHealthPoints(float value)
        {
            CurrentHP -= value;
        }

        public void AddHealthPoints(float value)
        {
            CurrentHP += value;
        }
    }
}