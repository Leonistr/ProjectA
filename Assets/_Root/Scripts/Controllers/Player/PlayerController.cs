using System;
using _Root.Scripts.Controllers.Interfaces;
using _Root.Scripts.Models;
using _Root.Scripts.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Root.Scripts.Controllers
{
    public class PlayerController : IExecutable, IDisposable
    {
        private PlayerView _playerView;
        private IPlayerModel _playerModel;
        private PlayerInputController _playerInputController;
        private float _jumpSpeed;
        private ExecutableObjects _executableObjects;

        public PlayerController(PlayerView playerView, IPlayerModel playerModel, PlayerInputController playerInputController, ExecutableObjects executableObjects)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _playerInputController = playerInputController;
            _jumpSpeed = _playerModel.JumpSpeed;
            _playerView.OnObstacleCollide += ApplyEffect;
            _executableObjects = executableObjects;
            _executableObjects.AddExecutable(this);
        }

        private void ApplyEffect(float obj)
        {
            _playerModel.HealthPoint -= obj;
            if (_playerModel.HealthPoint <= 0)
            {
                Dispose();
            }
        }

        public void Execute(float deltaTime)
        {
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
               _playerInputController.Dash(_playerModel.DashPower);
            }
            _playerInputController.Move(deltaTime);
        }
        
        
        public void Dispose()
        {
            _executableObjects.RemoveExecutable(this);
            _playerInputController.Dispose();
            Object.Destroy(_playerView.gameObject);
        }
    }
}