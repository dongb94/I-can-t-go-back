
using System;
using System.Collections;
using UnityEngine;

public class CustomCoroutine : MonoBehaviour
{
    private bool _isOnCoroutine;
    
    private float _operatingTime;
    private float _elapsedTime;
    private float _delayTime;
    private float _afterLastUpdateTime;

    private Action _coroutineAction;
    private Action _startAction;
    private Action _exitAction;

    private void Update()
    {
        if (!_isOnCoroutine) return;

        _afterLastUpdateTime += Time.fixedDeltaTime;
        _elapsedTime += Time.fixedDeltaTime;
        _elapsedTime = Math.Min(_elapsedTime, _operatingTime);

        if (_afterLastUpdateTime >= _delayTime)
        {
            _coroutineAction?.Invoke();
            _afterLastUpdateTime = 0;
        }

        if (_operatingTime <= _elapsedTime)
        {
            _exitAction?.Invoke();
            _isOnCoroutine = false;
            CoroutineFactory.GetInstance.PoolCoroutine(this);
            _coroutineAction = null;
        }
    }

    public void OnPooling()
    {
        _operatingTime = 0;
        _elapsedTime = 0;
        _delayTime = 0;
        _afterLastUpdateTime = 0;
        _coroutineAction = null;
        _startAction = null;
        _exitAction = null;
    }

    public void SetCoroutine(Action action, float operatingTime, float delayTime)
    {
        _operatingTime = operatingTime;
        _delayTime = delayTime;
        _coroutineAction = action;
    }

    public void SetTrigger()
    {
        _isOnCoroutine = true;
        _startAction?.Invoke();
    }

    public void SetAction(Action action)
    {
        _coroutineAction = action;
    }
    
    public void SetStartAction(Action action)
    {
        _startAction = action;
    }
    
    public void SetExitAction(Action action)
    {
        _exitAction = action;
    }

    public float Change(float start, float end)
    {
        return start + (end - start) * (_elapsedTime / _operatingTime);
    }
    
    public int Change(int start, int end)
    {
        return start + (int)((end - start) * (_elapsedTime / _operatingTime));
    }
    
    public Vector3 Change(Vector3 start, Vector3 end)
    {
        return start + (end - start) * _elapsedTime / _operatingTime;
    }
}

/*  Legacy
    /// <summary>
    /// 
    /// </summary>
    /// <param name="variable">변화를 줄 변수(ex. vector, int)</param>
    /// <param name="start">변수의 시작 값</param>
    /// <param name="end">변수의 끝 값</param>
    /// <param name="frame">코루틴이 몇번에 거쳐서 실행될 것인지</param>
    /// <param name="coroutineRunTime">코루틴이 처리되는 시간(Speed) > 0</param>
    /// <typeparam name="T"></typeparam>
    public static void RunCoroutine<T>(ref T variable, T start, T end, int frame, float coroutineRunTime) where T : IComparable 
    {
        if (coroutineRunTime <= 0) throw new UnityException("Coroutine Time Under 0 : " + coroutineRunTime.ToString());
        if (frame <= 0) throw new UnityException("Coroutine Frame Under 0 : " + frame.ToString());
        var delayOfEvent = coroutineRunTime/frame;

        MakeCoroutine(out variable, start, end, frame, delayOfEvent);
    }

    private static IEnumerator MakeCoroutine<T>(out T variable, T start, T end, int frame, float delayOfEvent) where T : IComparable 
    {
//        switch (variable.GetType())
//        {
//            default:
//                throw new UnityException("Undefined Type : " + variable.GetType());
//        }
        if (variable is int
            || variable is float
            || variable is double
            || variable is short
        )
        {
            var s = (int)(object) start;
            for (var i = 0; i < frame; i++)
            {
                variable = (T)(object)(s / frame);
            }

        }

        yield return null;
    }
    */