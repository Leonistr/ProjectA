using _Root.Configs;
using _Root.Scripts.Controllers;
using _Root.Scripts.Controllers.Camera;
using _Root.Scripts.Models;

namespace _Root.Scripts
{
    public class GameInitializer
    {
        public GameInitializer(ExecutableObjects executableObjects, LevelObjects levelObjects)
        {
            var contactPoller = new ContactPoller(levelObjects.PlayerView.Collider);
            var playerModel = new PlayerModel(levelObjects.PlayerInformationObject.PlayerInformation.Speed, 
                levelObjects.PlayerInformationObject.PlayerInformation.JumpSpeed,
                levelObjects.PlayerInformationObject.PlayerInformation.HealthPoint, 
                levelObjects.PlayerInformationObject.PlayerInformation.DashPower);
            var playerInputController =
                new PlayerInputController(playerModel, levelObjects.PlayerView.Rigidbody2D, contactPoller, levelObjects.PlayerView);
            var playerController = new PlayerController(levelObjects.PlayerView, playerModel, playerInputController, executableObjects);
            var cameraContoller = new CameraController(levelObjects.CameraView, executableObjects);
            executableObjects.AddExecutable(playerController);
            executableObjects.AddExecutable(cameraContoller);
        }
    }
}