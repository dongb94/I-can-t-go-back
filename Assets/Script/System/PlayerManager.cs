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
        _speed = 2f;
        //x = -99;
        //y = -99;
    }
    private void Update()
    {
        if (_isHandle) return;
        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (horizontal > 0) Move(Axis.Right);
        else if (horizontal < 0) Move(Axis.Left);
        if (vertical > 0) Move(Axis.Top);
        else if (vertical < 0) Move(Axis.Bottom);
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
            //Debug.Log("Check");
            BoardManager.GetInstance.CallEvent(X+moveX, Y+moveY, axis);
            _isHandle = false;
            return;
        }

        var currentPosition = transform.position;
        
        var moveCoroutine = CoroutineFactory.GetInstance.CreateCoroutine(1 / _speed);
        moveCoroutine.EventArgs.vector1 = currentPosition;
        moveCoroutine.EventArgs.intFactor1 = moveX;
        moveCoroutine.EventArgs.intFactor2 = moveY;
        moveCoroutine.SetAction((args) =>
            {
                var destination = BoardManager.GetInstance.ChangeGridToPosition(GetInstance.X + args.intFactor1,
                                                                            GetInstance.Y + args.intFactor2);
                var startPosition = args.vector1;
                PlayerManager.GetInstance.transform.position = args.thisCoroutine.Change(startPosition, destination);
            })
            .SetExitAction((args) =>
            {
                GetInstance.UpdatePosition(GetInstance.X+args.intFactor1, GetInstance.Y+args.intFactor2);
                //Debug.Log("X : " + GetInstance.X+args.intFactor1 + ", Y : "+GetInstance.Y+args.intFactor2);
                Move(axis);
            })
            .SetTrigger();

    }
}
