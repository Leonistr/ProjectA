using System;
using _Root.Scripts.Models;
using _Root.Scripts.Models.Obstacles;
using UnityEngine;

namespace _Root.Scripts.Views
{
    public class ObstacleView : MonoBehaviour
    {
        public ObstacleConfig ObstacleConfig;
        public event Action OnPlayerCollide = () => { };

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnPlayerCollide.Invoke();
        }
    }
}