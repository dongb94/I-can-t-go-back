
using Script.Common;
using UnityEngine;

public class StageInitializer : MonoBehaviour
{
    public Location2D playerPosition;
    
    private void Awake()
    {
        PlayerManager.GetInstance.InitializePosition(playerPosition.x,playerPosition.y);
    }
}