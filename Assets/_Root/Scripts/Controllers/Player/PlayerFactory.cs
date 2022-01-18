using _Root.Configs;
using _Root.Scripts.Controllers.Camera;
using _Root.Scripts.Models;

namespace _Root.Scripts.Controllers
{
    public class PlayerFactory
    {
        private LevelObjects _levelObjects;
        private ExecutableObjects _executableObjects;

        public PlayerFactory(LevelObjects levelObjects, ExecutableObjects executableObjects)
        {
            _levelObjects = levelObjects;
            _executableObjects = executableObjects;
        }
        public PlayerController CreatePlayer()
        {
            var oxygen = new Oxygen(_levelObjects.PlayerInformationObject.PlayerInformation.OxygenPoint);
            var health = new Health(_levelObjects.PlayerInformationObject.PlayerInformation.HealthPoint);
            var contactPoller = new ContactPoller(_levelObjects.PlayerView.Collider);
            var playerModel = new PlayerModel(_levelObjects.PlayerInformationObject.PlayerInformation.Speed, 
                _levelObjects.PlayerInformationObject.PlayerInformation.JumpSpeed, health
                , oxygen,
                _levelObjects.PlayerInformationObject.PlayerInformation.DashPower);
            var playerInputController =
                new PlayerInputController(playerModel, _levelObjects.PlayerView.Rigidbody2D, contactPoller, 
                    _levelObjects.PlayerView);
            var playerController = new PlayerController(_levelObjects.PlayerView, playerModel, 
                playerInputController, _executableObjects);
            return playerController;
        }
    }
}