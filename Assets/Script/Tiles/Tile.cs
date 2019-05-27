
using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Tile : MonoBehaviour
{
    [FormerlySerializedAs("TileSprite")] public SpriteRenderer tileSprite;
    
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
        
        switch (color)
        {
            case TileColor.None:
                tileSprite.color = Color.white;
                break;
            case TileColor.Red:
                tileSprite.color = Color.red;
                break;
            case TileColor.Blue:
                tileSprite.color = Color.blue;
                break;
            case TileColor.Green:
                tileSprite.color = Color.green;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(color), color, null);
        }
    }

    public static Color GetColor(TileColor color)
    {
        switch (color)
        {
            case TileColor.None:
                return Color.white;
                break;
            case TileColor.Red:
                return Color.red;
                break;
            case TileColor.Blue:
                return Color.blue;
                break;
            case TileColor.Green:
                return Color.green;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(color), color, null);
        }
    }
    
    public abstract void TileEffect(Axis axis);
}