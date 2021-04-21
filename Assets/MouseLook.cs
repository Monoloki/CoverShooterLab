using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    [SerializeField]
    private Transform playerRoot, lookRoot;
    [SerializeField]
    private bool invert;
    [SerializeField]
    private bool canUnlock = true;

    private float _sensivity = 5f;
    private int _smoothSteps = 10;
    private float _smoothWeight = 0.4f;
    private float _roolAngle = 10f;
    private Vector2 _defaultLookLimits = new Vector2(-70f, 80f);
    private Vector2 _lookAngles;
    private Vector2 _currentMouseLook;
    private Vector2 _smoothMove;
    private float _currentRollAngle;
    private int _lastLookFrame;
    private float _roolSpeed = 3f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        LockAndUnlockCursorController();

        if (Cursor.lockState == CursorLockMode.Locked)
        {
           LookAroundController();
        }
        
    }

    private void LockAndUnlockCursorController()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    private void LookAroundController()
    {
        _currentMouseLook = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        _lookAngles.x += _currentMouseLook.x * _sensivity * (invert ? 1f : -1f);
        _lookAngles.y += _currentMouseLook.y * _sensivity;

        _lookAngles.x = Mathf.Clamp(_lookAngles.x, _defaultLookLimits.x, _defaultLookLimits.y);

        _currentRollAngle = Mathf.Lerp(_currentRollAngle, Input.GetAxisRaw("Mouse X") * _currentRollAngle,
            Time.deltaTime * _roolSpeed);
        
        lookRoot.localRotation = Quaternion.Euler(_lookAngles.x, 0f, _currentRollAngle);
        playerRoot.localRotation = Quaternion.Euler(0f,_lookAngles.y,0f);
    }
}
