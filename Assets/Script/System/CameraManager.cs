
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

        mainCamera.orthographicSize = BoardManager.GetInstance.BoardWight;
    }
}