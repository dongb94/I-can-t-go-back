
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Tile : MonoBehaviour
{
    [FormerlySerializedAs("TileSprite")] public Sprite tileSprite;
    
    [FormerlySerializedAs("Color")] public TileColor color;
    [FormerlySerializedAs("Shape")] public TileShape shape;

    public int x;
    public int y;

    private static readonly Vector3 PooledPosition = new Vector3(0,0,-20);
    
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
        transform.position = PooledPosition;
    }

    public void OnPooling()
    {
        
    }

    public abstract void TileEffect(int direction);
}