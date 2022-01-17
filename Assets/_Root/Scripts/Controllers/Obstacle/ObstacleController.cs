using _Root.Scripts.Models;
using _Root.Scripts.Models.Obstacle;
using _Root.Scripts.Views;

namespace _Root.Scripts.Controllers.Obstacle
{
    public class ObstacleController
    {
        private IObstacleModel _obstacleModel;
        private ObstacleView _obstacleView;

        public ObstacleController(IObstacleModel obstacleModel, ObstacleView obstacleView)
        {
            _obstacleModel = obstacleModel;
            _obstacleView = obstacleView;
        }
    }
}