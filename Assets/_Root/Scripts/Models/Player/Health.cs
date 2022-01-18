namespace _Root.Scripts.Models
{
    public class Health
    {
        #region Properties

        public float MaxHP { get; private set; }
        public float CurrentHP { get; private set; }

        #endregion



        #region Constructor

        public Health(float maxHp)
        {
            MaxHP = maxHp;
            CurrentHP = MaxHP;
        }

        #endregion


        #region Methods

        public void RemoveHealthPoints(float value)
        {
            CurrentHP -= value;
        }

        public void AddHealthPoints(float value)
        {
            CurrentHP += value;
        }

        #endregion
    }
}