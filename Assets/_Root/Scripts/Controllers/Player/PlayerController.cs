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
        #region Fields

        private IPlayerModel _playerModel;
        private PlayerView _playerView;
        private PlayerInputController _playerInputController;
        private ExecutableObjects _executableObjects;
        private bool _blockControllers;
        private const float DASH_TIMER = 0.25f;
        private const float BLOCK_TIMER = 1f;
        private float _currentDashTimer = 0.25f;
        private float _currentBlockTime = 1f;

        #endregion

        
        #region Constructor

        public PlayerController(PlayerView playerView, IPlayerModel playerModel,
            PlayerInputController playerInputController, ExecutableObjects executableObjects)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _playerInputController = playerInputController;
            _executableObjects = executableObjects;
            _playerView.StartCoroutine(MinusOxygen());
            _playerModel.Health.OnHPEnded += Dispose;
            _playerModel.Health.OnHPChange += ThrowAway;
        }

        #endregion

        
        #region Methods

        public void Execute(float deltaTime)
        {
            if (!Input.GetButton("Dash") && _currentDashTimer != DASH_TIMER)
            {
                _currentDashTimer = DASH_TIMER;
                Debug.Log("Ready to dash");
            }
            if (_currentDashTimer < 0)
            {
                _currentDashTimer = DASH_TIMER;
                _blockControllers = true;
            }
            Dash(deltaTime);
            _playerInputController.Move(deltaTime);
        }

        private void ThrowAway()
        {
            _playerView.Rigidbody2D.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
        private void Dash(float deltaTime)
        {
            if (Input.GetButton("Dash"))
            {
                if (_blockControllers)
                {
                    Debug.Log("Can't dash");
                    _currentBlockTime -= deltaTime;
                    if (_currentBlockTime < 0)
                    {
                        _currentBlockTime = BLOCK_TIMER;
                        _blockControllers = false;
                    }
                    return;
                }
                _currentDashTimer -= deltaTime;
                Debug.Log("Ready to dash");
                if (_playerView.Renderer.flipX)
                {
                    _playerInputController.Dash(-_playerModel.DashPower);
                }
                else
                {
                    _playerInputController.Dash(_playerModel.DashPower);
                }
            }
        }
        
        private IEnumerator MinusOxygen()
        {
            while (_playerModel.Oxygen.HasOxygen)
            {
                yield return new WaitForSeconds(1f);
                _playerModel.Oxygen.RemoveOxygen(1f);
            }
            _playerView.StopCoroutine(MinusOxygen());
        }
        public void Dispose()
        {
            _executableObjects.RemoveExecutable(this);
            _playerInputController.Dispose();
            Object.Destroy(_playerView.gameObject);
        }

        #endregion
    }
}