using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{

    private bool _isHandle;
    private float _speed; //  tile/s

    private int x, y;
    
    
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
        UpdatePosition(x, y);
    }

    #region <Properties>

    public int X => x;
    public int Y => y;
    
    #endregion

    private void UpdatePosition(int x, int y)
    {
        transform.position = BoardManager.GetInstance.ChangeGridToPosition(x, y);
        this.x = x;
        this.y = y;
    }
    
    private void Move(Axis axis)
    {
        _isHandle = true;

        var moveX = 0;
        var moveY = 0;
        
        switch (axis)
        {
            case Axis.Right:
                moveX = 1;
                break;
            case Axis.Left:
                moveX = -1;
                break;
            case Axis.Top:
                moveY = 1;
                break;
            case Axis.Bottom:
                moveY = -1;
                break;
            default:
                throw new ArgumentOutOfRangeException("axis", axis, null);
        }

        if (!BoardManager.GetInstance.CheckIsEmptyDirection(axis))
        {
            BoardManager.GetInstance.CallEvent(X+moveX, Y+moveY, axis);
            _isHandle = false;
            return;
        }

        var currentPosition = transform.position;
        
        var moveCoroutine = CoroutineFactory.GetInstance.CreateCoroutine(1 / _speed);
        moveCoroutine.SetAction(() =>
            {
                var destination = BoardManager.GetInstance.ChangeGridToPosition(X + moveX, Y + moveY);
                PlayerManager.GetInstance.transform.position = moveCoroutine.Change(currentPosition, destination);
            })
            .SetExitAction(() =>
            {
                UpdatePosition(X+moveX, Y+moveY);
            })
            .SetTrigger();

    }
}
