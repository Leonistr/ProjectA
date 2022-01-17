using System;
using _Root.Scripts.Controllers.Interfaces;
using _Root.Scripts.Models;
using _Root.Scripts.Views;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class PlayerHorizontalInput : IInput, IExecutable
    {
        private Rigidbody2D _rigidbody;
        private IPlayerModel _playerModel;
        public event Action<float> OnAxisChange = f => { };

        public PlayerHorizontalInput(Rigidbody2D rigidbody2D, IPlayerModel playerModel)
        {
            _rigidbody = rigidbody2D;
            _playerModel = playerModel;
        }
        public void Execute(float deltaTime)
        {
            OnAxisChange.Invoke(Input.GetAxis("Horizontal"));
        }

        
    }
}