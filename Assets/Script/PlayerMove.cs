﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private bool _isHandle;
    private float _speed;

    private enum Axis
    {
        Right,
        Left,
        Up,
        Down
    }
    
    private void Awake()
    {
        _isHandle = false;
        _speed = 0.5f;
    }

    private void Update()
    {
        if (_isHandle) return;
        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (horizontal != 0) transform.position += Vector3.right * horizontal;
        if (vertical != 0) transform.position += Vector3.up * vertical;
    }

    private void Move(Axis axis)
    {
        _isHandle = true;
        switch (axis)
        {
            case Axis.Right:
                transform.position += Vector3.right * _speed;
                break;
            case Axis.Left:
                break;
            case Axis.Up:
                break;
            case Axis.Down:
                break;
            default:
                throw new ArgumentOutOfRangeException("axis", axis, null);
        }
    }
}
