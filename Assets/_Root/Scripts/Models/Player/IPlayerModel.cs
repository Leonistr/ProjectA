using _Root.Scripts.Controllers;

namespace _Root.Scripts.Models
{
    public interface IPlayerModel
    {
        float Speed { get; set; }
        float JumpSpeed { get; set; }
        Health Health { get; set; }
        Oxygen Oxygen { get; set; }
        float DashPower { get; set; }
    }
}