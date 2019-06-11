
using System;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    public bool IsEditorMode;
    
    private Camera mainCamera;
    protected override void Initialize()
    {
        mainCamera = GameObject.FindObjectOfType<Camera>();
        
        InitializeCameraPosition();
    }

    public void InitializeCameraPosition()
    {
        if(IsEditorMode) mainCamera.transform.position += Vector3.right * 5;

        mainCamera.orthographicSize = 10 + Math.Max(BoardManager.GetInstance.BoardWidth - 20, 0) * 0.5f;
    }
}