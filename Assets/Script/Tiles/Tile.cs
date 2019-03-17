
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Tile : MonoBehaviour
{
    [FormerlySerializedAs("TileSprite")] public Sprite tileSprite;
    
    [FormerlySerializedAs("Color")] public TileColor color;
    [FormerlySerializedAs("Shape")] public TileShape shape;

    private int x;
    private int y;

    public enum TileColor
    {
        None = 1 << 10,
        Red = 1 << 11,
        Blue = 1 << 12,
        Green = 1 << 13
    }

    public enum TileShape
    {
        Square, 
        
        UpperRightTriangle, // ┐
        UpperLeftTriangle, // ┌
        LowerRightTriangle, // ┘
        LowerLeftTriangle, // └
        
        HollowSquare,
        
        HollowUpperRightTriangle,
        HollowUpperLeftTriangle,
        HollowLowerRightTriangle,
        HollowLowerLeftTriangle,
        
        Hole,
        Laser,
        
        Goal,
    }
    public void OnPooled()
    {
        transform.position = Vector3.forward * 20; 
    }

    public void Initialize()
    {
        BoardManager.GetInstance.InsertTile(this);
    }

    public abstract void TileEffect(int direction);
}