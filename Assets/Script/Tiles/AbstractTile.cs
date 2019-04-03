
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
        None,    //Original Color
        Red,
        Blue,
        Green
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

    public void SetColor(TileColor color)
    {
        this.color = color;
        tileSprite.
    }
    
    public abstract void TileEffect(Axis axis);
}