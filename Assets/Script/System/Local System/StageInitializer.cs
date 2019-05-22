
using System;
using Script.Common;
using UnityEngine;
/// <summary>
/// TODO 카메라 사이즈(맵 크기에 따라), 맵 사이즈 설정, 
/// </summary>
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