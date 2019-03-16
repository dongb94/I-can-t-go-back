
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
        Square = 1 << 1, 
        
        UpperRightTriangle = 1 << 2, // ┐
        UpperLeftTriangle = 1 << 3, // ┌
        LowerRightTriangle = 1 << 4, // ┘
        LowerLeftTriangle = 1 << 5, // └
        
        Hole = 1 << 6,
        Laser = 1 << 7,
        
        Goal = 1 << 8,
        
        IsHollow = 1 << 9,
        
        HollowSquare = Square | IsHollow,
        
        HollowUpperRightTriangle = UpperRightTriangle | IsHollow,
        HollowUpperLeftTriangle = UpperLeftTriangle | IsHollow,
        HollowLowerRightTriangle = LowerRightTriangle | IsHollow,
        HollowLowerLeftTriangle = LowerLeftTriangle | IsHollow,
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