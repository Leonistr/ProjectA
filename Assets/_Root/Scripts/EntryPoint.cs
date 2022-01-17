using System;
using System.Collections;
using System.Collections.Generic;
using _Root.Scripts.Controllers;
using _Root.Scripts.Models;
using _Root.Scripts.Views;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private PlayerInformationObject _playerInformationObject;
    private ExecutableObjects _executableObjects;

    private void Awake()
    {
        _executableObjects = new ExecutableObjects();
        var contactPoller = new ContactPoller(_playerView.Collider);
        var playerModel = new PlayerModel(_playerInformationObject.PlayerInformation.Speed, _playerInformationObject.PlayerInformation.JumpSpeed,
            _playerInformationObject.PlayerInformation.HealthPoint, _playerInformationObject.PlayerInformation.DashPower);
        var playerInputController =
            new PlayerInputController(playerModel, _playerView.Rigidbody2D, contactPoller, _playerView);
        var playerController = new PlayerController(_playerView, playerModel, playerInputController, _executableObjects);
    }

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        _executableObjects.Execute(deltaTime);
    }
}
