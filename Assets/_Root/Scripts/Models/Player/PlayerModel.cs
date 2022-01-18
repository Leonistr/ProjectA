using _Root.Scripts.Controllers;

namespace _Root.Scripts.Models
{
    public class PlayerModel : IPlayerModel
    {
        public float Speed { get; set; }
        public float JumpSpeed { get; set; }
        public Health Health { get; set; }
        public Oxygen Oxygen { get; set; }
        public float DashPower { get; set; }

        public PlayerModel(float speed, float jumpSpeed, Health health, Oxygen oxygen, float dashPower)
        {
            Speed = speed;
            JumpSpeed = jumpSpeed;
            Health = health;
            Oxygen = oxygen;
            DashPower = dashPower;
        }
    }
}