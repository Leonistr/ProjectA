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
            var playerFactory = new PlayerFactory(levelObjects, executableObjects);
            var playerController = playerFactory.CreatePlayer();
            var cameraContoller = new CameraController(levelObjects.CameraView);
            executableObjects.AddExecutable(playerController);
            executableObjects.AddExecutable(cameraContoller);
        }
    }
}