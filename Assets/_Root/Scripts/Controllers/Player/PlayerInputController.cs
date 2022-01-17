using System;
using _Root.Scripts.Controllers.Interfaces;
using _Root.Scripts.Models;
using _Root.Scripts.Views;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class PlayerInputController : IDisposable
    {
        private PlayerHorizontalInput _horizontalInput;
        private PlayerJumpController _jumpController;
        private float _horizontalMove;
        private float _jumpAxis;
        private Rigidbody2D _rigidbody;
        private IPlayerModel _playerModel;
        private bool _jumpControl;
        private int _jumpIterations = 0;
        private int _jumpValueIterations = 60;
        private ContactPoller _contactPoller;
        private int _jumpCount = 0;
        private const int _jumpWallCoef = 5;
        private PlayerView _playerView;
        private int _jumpHash;
        private int _runHash;

        public PlayerInputController(IPlayerModel playerModel, Rigidbody2D rigidbody, 
            ContactPoller contactPoller, PlayerView playerView)
        {
            _playerModel = playerModel;
            _rigidbody = rigidbody;
            _contactPoller = contactPoller;
            _playerView = playerView;
            _jumpHash = Animator.StringToHash("IsJumping");
            _runHash = Animator.StringToHash("Speed");
            _horizontalInput = new PlayerHorizontalInput(rigidbody, playerModel);
            _jumpController = new PlayerJumpController(rigidbody, playerModel);
            _horizontalInput.OnAxisChange += HorizontalInputOnOnAxisChange;
            _jumpController.OnAxisChange += JumpControllerOnOnAxisChange;
            _horizontalMove = 0;
        }

        private void JumpControllerOnOnAxisChange(float obj)
        {
            _jumpAxis = obj;
        }

        private void HorizontalInputOnOnAxisChange(float obj)
        {
            _horizontalMove = obj;
        }


        public void Dash(float dashPower)
        {
            _rigidbody.AddForce(Vector2.right * dashPower);
        }
        
        public void Move(float deltaTime)
        {
            _contactPoller.UpdateContacts();
            _horizontalInput.Execute(deltaTime);
            _jumpController.Execute(deltaTime);
            Vector3 vectorMove = new Vector3(_horizontalMove * _playerModel.Speed, _rigidbody.velocity.y);
            _rigidbody.velocity = vectorMove; 
            Reflect();
            Jump();
            JumpFromWall();
            PlayAnimation();
        }

        private void PlayAnimation()
        {
            _playerView.Animator.SetBool(_jumpHash, !_contactPoller.IsGrounded);
            if (_horizontalMove > 0.1 || _horizontalMove < -0.1)
            {
                _playerView.Animator.SetFloat(_runHash, 1);
            }
            else
            {
                _playerView.Animator.SetFloat(_runHash, 0);
            }
        }
        
        private void Jump()
        {
            if (_jumpAxis > 0.1f)
            {
                if (_contactPoller.IsGrounded)
                {
                    _jumpControl = true;
                }
            }
            else
            {
                _jumpControl = false;
            }

            if (_jumpControl)
            {
                if (_jumpIterations++ < _jumpValueIterations)
                {
                    _rigidbody.AddForce(Vector2.up * _playerModel.JumpSpeed / _jumpIterations);
                }
            }
            else
            {
                _jumpIterations = 0;
            }

        }

        private void JumpFromWall()
        {
            if ((_contactPoller.HasLeftContact || _contactPoller.HasRightContact) && !_contactPoller.IsGrounded)
            {
                if (_horizontalMove == 0)
                {
                    _rigidbody.gravityScale = 0;
                    _rigidbody.velocity = Vector2.zero;
                }
                if (Input.GetButtonDown("Jump"))
                {
                    _rigidbody.AddForce(Vector2.up * _playerModel.JumpSpeed * _jumpWallCoef);
                }
            }
            else
            {
                _rigidbody.gravityScale = 1;
            }
        }

        private void Reflect()
        {
            if (_horizontalMove > 0)
            {
                _playerView.Renderer.flipX = false;
            }
            else if (_horizontalMove < 0)
            {
                _playerView.Renderer.flipX = true;
            }
        }
        
        public void Dispose()
        {
            _horizontalInput.OnAxisChange -= HorizontalInputOnOnAxisChange;
            _jumpController.OnAxisChange -= JumpControllerOnOnAxisChange;
        }
    }
}