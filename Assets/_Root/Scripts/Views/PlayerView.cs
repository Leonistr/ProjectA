﻿using System;
using UnityEngine;

namespace _Root.Scripts.Views
{
    public class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public Renderer PlayerSprite { get; private set; }
        [field: SerializeField] public Collider2D Collider { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public SpriteRenderer Renderer { get; private set; }
        public event Action<float> OnObstacleCollide = f => {};

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ObstacleView obstacleView))
            {
                OnObstacleCollide.Invoke(obstacleView.Damage);
            }
        }
    }
}