using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Singleton<PlayerMove>
{

    private bool _isHandle;
    private float _speed;

    private int x, y;

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
        x = -99;
        y = -99;
    }
    private void Update()
    {
        if (_isHandle) return;
        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (horizontal != 0) transform.position += Vector3.right * horizontal;
        if (vertical != 0) transform.position += Vector3.up * vertical;
    }

    public void InitializePosition(int x, int y)
    {
        transform.position = BoardManager.GetInstance.ChangeGridToPosition(x, y);
    }

    #region <Properties>

    public int X => x;
    public int Y => y;
    
    #endregion

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
