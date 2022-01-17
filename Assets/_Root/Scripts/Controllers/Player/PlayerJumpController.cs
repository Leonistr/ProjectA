using System;
using _Root.Scripts.Controllers.Interfaces;
using _Root.Scripts.Models;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class PlayerJumpController : IInput, IExecutable
    {
        private Rigidbody2D _rigidbody;
        public event Action<float> OnAxisChange = f => { };
        private IPlayerModel _playerModel;

        public PlayerJumpController(Rigidbody2D rigidbody, IPlayerModel playerModel)
        {
            _rigidbody = rigidbody;
            _playerModel = playerModel;
        }


        public void Execute(float deltaTime)
        {
            if (Input.GetButton("Jump"))
            {
                OnAxisChange.Invoke(1);
            }
            else
            {
                OnAxisChange.Invoke(0);
            }
        }

        
    }
}