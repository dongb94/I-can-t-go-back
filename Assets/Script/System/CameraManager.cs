
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
        mainCamera.orthographicSize = 10 + Math.Max(BoardManager.GetInstance.BoardWidth - 20, 0) * 0.5f;

        if (IsEditorMode)
        {
            var cameraPosition = new Vector3(Screen.width / 2f + 100, Screen.height / 2f, -10);
            mainCamera.transform.position += mainCamera.ScreenToWorldPoint(cameraPosition);
        }

    }
}