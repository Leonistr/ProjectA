using System;
using System.Collections;
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
        private ExecutableObjects _executableObjects;
        private float _dashTimer = 0.25f;
        private float _currentDashTimer = 0.25f;
        private bool _blockControllers;
        private float _blockTimer = 1f;
        private float _currentBlockTime = 1f;

        public PlayerController(PlayerView playerView, IPlayerModel playerModel,
            PlayerInputController playerInputController, ExecutableObjects executableObjects)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _playerInputController = playerInputController;
            _executableObjects = executableObjects;
            _playerView.StartCoroutine(MinusOxygen());
        }

        public void Execute(float deltaTime)
        {
            if (!Input.GetButton("Dash") && _currentDashTimer != _dashTimer)
            {
                _currentDashTimer = _dashTimer;
            }
            if (_currentDashTimer < 0)
            {
                _currentDashTimer = _dashTimer;
                _blockControllers = true;
            }
            if (Input.GetButton("Dash"))
            {
                if (_blockControllers)
                {
                    _currentBlockTime -= deltaTime;
                    if (_currentBlockTime < 0)
                    {
                        _currentBlockTime = _blockTimer;
                        _blockControllers = false;
                    }
                    return;
                }
                _currentDashTimer -= deltaTime;
                
                if (_playerView.Renderer.flipX)
                {
                    _playerInputController.Dash(-_playerModel.DashPower);
                }
                else
                {
                    _playerInputController.Dash(_playerModel.DashPower);
                }
            }
            _playerInputController.Move(deltaTime);
        }

        private IEnumerator MinusOxygen()
        {
            while (_playerModel.Oxygen.HasOxygen)
            {
                yield return new WaitForSeconds(1f);
                _playerModel.Oxygen.RemoveOxygen(1f);
                Debug.Log($"{_playerModel.Oxygen.CurrentOxygen}");
            }
            _playerView.StopCoroutine(MinusOxygen());
        }
        public void Dispose()
        {
            _executableObjects.RemoveExecutable(this);
            _playerInputController.Dispose();
            Object.Destroy(_playerView.gameObject);
        }
    }
}