
using UnityEngine;

public class CameraMover : Singleton<CameraMover>
{
    private Camera mainCamera;
    protected override void Initialize()
    {
        mainCamera = GameObject.FindObjectOfType<Camera>();
        mainCamera.transform.position += Vector3.right * 5;
    }
}