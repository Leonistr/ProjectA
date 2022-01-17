namespace _Root.Scripts.Models
{
    public interface IPlayerModel
    {
        float Speed { get; set; }
        float JumpSpeed { get; set; }
        float HealthPoint { get; set; }
        float DashPower { get; set; }
    }
}