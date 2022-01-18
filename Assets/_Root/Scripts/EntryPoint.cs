using System;
using System.Collections;
using System.Collections.Generic;
using _Root.Configs;
using _Root.Scripts;
using _Root.Scripts.Controllers;
using _Root.Scripts.Controllers.Camera;
using _Root.Scripts.Models;
using _Root.Scripts.Models.Obstacles;
using _Root.Scripts.Views;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private CameraView _cameraView;
    [SerializeField] private PlayerInformationObject _playerInformationObject;
    [SerializeField] private List<ObstacleView> _obstacleViews;
    private ExecutableObjects _executableObjects;

    private void Awake()
    {
        _executableObjects = new ExecutableObjects();
        var levelObjects = new LevelObjects();
        levelObjects.CameraView = _cameraView;
        levelObjects.PlayerView = _playerView;
        levelObjects.PlayerInformationObject = _playerInformationObject;
        new GameInitializer(_executableObjects, levelObjects, _obstacleViews);
    }

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        _executableObjects.Execute(deltaTime);
    }
}
