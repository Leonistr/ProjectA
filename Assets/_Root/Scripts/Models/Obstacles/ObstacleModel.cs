namespace _Root.Scripts.Models.Obstacles
{
    public class ObstacleModel : IObstacleModel
    {
        #region Propetries

        public float Damage { get; }

        #endregion


        #region Constructor

        public ObstacleModel(float damage)
        {
            Damage = damage;
        }

        #endregion
    }
}