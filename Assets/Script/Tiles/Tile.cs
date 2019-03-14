
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Tile : MonoBehaviour
{
    [FormerlySerializedAs("Color")] public BoardManager.TileColor color;
    [FormerlySerializedAs("Shape")] public BoardManager.TileShape shape;

    public int x;
    public int y;

    public void Initialize()
    {
        BoardManager.GetInstance.InsertTile(this);
    }
}