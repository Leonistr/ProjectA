using UnityEngine;

namespace _Root.Scripts.Models.Obstacle
{
    [CreateAssetMenu(fileName = nameof(ObstacleInformationObject), menuName = "Models/"+nameof(ObstacleInformationObject), order = 0)]
    public class ObstacleInformationObject : ScriptableObject
    {
        public ObstacleInfo ObstacleInfo;
    }
}