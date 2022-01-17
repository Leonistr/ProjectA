namespace _Root.Scripts.Models
{
    public class PlayerModel : IPlayerModel
    {
        public float Speed { get; set; }
        public float JumpSpeed { get; set; }
        public float HealthPoint { get; set; }
        public float DashPower { get; set; }

        public PlayerModel(float speed, float jumpSpeed, float healthPoint, float dashPower)
        {
            Speed = speed;
            JumpSpeed = jumpSpeed;
            HealthPoint = healthPoint;
            DashPower = dashPower;
        }
    }
}