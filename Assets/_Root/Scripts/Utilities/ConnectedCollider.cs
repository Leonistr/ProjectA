using System;
using UnityEngine;

namespace _Root.Scripts.Utilities
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ConnectedCollider : MonoBehaviour
    {
        [field: SerializeField] public Collider2D Collider { get; private set; }
        public event Action OnTriggerCollide = () => { };


        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerCollide.Invoke();
        }
    }
}