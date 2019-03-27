
using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class CommonEventArgs : EventArgs
{
    public Object object1;
    public Object object2;
    public int intFactor1;
    public int intFactor2;
    public float floatFactor1;
    public float floatFactor2;
    public Vector3 vector1;
    public Vector3 vector2;
}