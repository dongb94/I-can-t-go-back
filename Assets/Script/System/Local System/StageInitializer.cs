
using System;
using Script.Common;
using UnityEngine;

public class StageInitializer : MonoBehaviour
{
    public Location2D playerPosition;
    public Stage stage;

    public enum Stage
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Stage5,
    }
    
    private void Awake()
    {
        PlayerManager.GetInstance.InitializePosition(playerPosition.x,playerPosition.y);
        MapFileReader.GetInstance.ReadMapFile("Stages/"+stage.ToString());
    }
}