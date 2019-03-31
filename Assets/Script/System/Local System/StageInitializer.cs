
using UnityEngine;

public class StageInitializer : MonoBehaviour
{
    private void Awake()
    {
        PlayerManager.GetInstance.InitializePosition(5,8);
    }
}