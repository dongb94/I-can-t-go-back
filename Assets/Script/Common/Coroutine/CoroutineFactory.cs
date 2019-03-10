using System;
using UnityEngine;
using System.Collections.Generic;

public class CoroutineFactory : Singleton<CoroutineFactory>
{
    [SerializeField] private CustomCoroutine _makeCoroutine; 
    private Queue<CustomCoroutine> _waitingCoroutineGroup;
    protected override void Initialize()
    {
        base.Initialize();
        _waitingCoroutineGroup = new Queue<CustomCoroutine>();
    }

    public CustomCoroutine CreateCoroutine(float operatingTime, float delayTime = 0.1f, Action action = null) // 코루틴 설정 인자값 추가
    {
        var pooledCoroutine = _waitingCoroutineGroup.Count > 0? _waitingCoroutineGroup.Dequeue() : Instantiate(_makeCoroutine);
        pooledCoroutine.transform.parent = transform;
        
        pooledCoroutine.OnPooling();
        
        pooledCoroutine.SetCoroutine(action, operatingTime, delayTime);

        return pooledCoroutine;
    }

    public void PoolCoroutine(CustomCoroutine endCoroutine)
    {
        _waitingCoroutineGroup.Enqueue(endCoroutine);
    }
}