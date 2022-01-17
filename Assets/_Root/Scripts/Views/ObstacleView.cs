using UnityEngine;

namespace _Root.Scripts.Views
{
    public class ObstacleView : MonoBehaviour
    {
        [field: SerializeField] public Collider2D Collider { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
    }
}