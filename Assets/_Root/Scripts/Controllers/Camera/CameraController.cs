using _Root.Scripts.Controllers.Interfaces;
using _Root.Scripts.Views;
using UnityEngine;

namespace _Root.Scripts.Controllers.Camera
{
    public class CameraController : IExecutable
    {
        private Transform _targetTransform;
        private float _minXPosition;
        private float _maxXPosition;
        private float _minYPosition;  
        private float _maxYPosition;  
        private CameraView _cameraView;
        private const int _cameraOffset = -10;

        public CameraController(CameraView cameraView, ExecutableObjects executableObjects)
        {
            _cameraView = cameraView;
            _targetTransform = _cameraView.TargetPosition;
            _minXPosition = _cameraView.MinXPosition;
            _maxXPosition = _cameraView.MaxXPosition;
            _minYPosition = _cameraView.MinYPosition;
            _maxYPosition = _cameraView.MaxYPosition;
        }

        public void Execute(float deltaTime)
        {
            var pos = _cameraView.transform.position;
            pos.x = Mathf.Clamp(_targetTransform.position.x, _minXPosition, _maxXPosition);
            pos.y = Mathf.Clamp(_targetTransform.position.y, _minYPosition, _maxYPosition);
            _cameraView.transform.position = pos;
        }
    }
}