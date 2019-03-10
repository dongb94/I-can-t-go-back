using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    
    private static T _instance;

    public static T GetInstance => _instance ? _instance : GetInstanceObject();

    protected virtual void Awake()
    {
        _instance = GetInstanceObject();
    }

    protected virtual void Initialize(){}

    private static T GetInstanceObject()
    {
        if (_instance != null) return _instance;
        
        _instance = FindObjectOfType<T>();
        _instance?.Initialize();

        return _instance;
    }
        
}