using System;
using UnityEngine;

namespace _Root.Scripts.Models.Obstacle
{
    [Serializable]
    public struct ObstacleInfo
    {
        [field: SerializeField] public GameObject ObstacleObject { get; set; }
        [field: SerializeField] public float Damage { get; set; }
    }
}