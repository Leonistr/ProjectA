namespace _Root.Scripts.Models.Obstacle
{
    public class ObstacleModel : IObstacleModel
    {
        public float Damage { get; private set; }

        public ObstacleModel(float damage)
        {
            Damage = damage;
        }
    }
}