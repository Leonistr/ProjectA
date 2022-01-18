using System;
using System.Collections;
using UnityEngine;

namespace _Root.Scripts.Views
{
    public class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public Renderer PlayerSprite { get; private set; }
        [field: SerializeField] public Collider2D Collider { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public SpriteRenderer Renderer { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
        }
    }
}