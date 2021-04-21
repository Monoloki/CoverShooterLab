using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _moveDirection; 
    private float _gravity = 20f;
    private float _jumpForce = 10f;
    private float _speed = 5f;
    private float _verticalVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovementController();
    }

    private void PlayerMovementController()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection *= _speed * Time.deltaTime;
        GravityController();
        _characterController.Move(_moveDirection);
    }

    private void GravityController()
    {
        FlyController();
        _verticalVelocity -= _gravity * Time.deltaTime;
        _moveDirection.y = _verticalVelocity * Time.deltaTime;
    }

    private void FlyController()
    {
        if ( Input.GetKey(KeyCode.Space))
        {
            _verticalVelocity = _jumpForce;
        }
    }
}
