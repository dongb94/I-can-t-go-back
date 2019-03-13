using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
    public int CellSize;

    public int BoardHeight;
    public int BoardWight;

    public int[][] Board;
    
    public enum TileColor
    {
        Red = 1 << 10,
        Blue = 1 << 11,
        Green = 1 << 12
    }

    public enum TileShape
    {
        Square = 1 << 1, 
        
        UpperRightTriangle = 1 << 2, // ┐
        UpperLeftTriangle = 1 << 3, // ┌
        LowerRightTriangle = 1 << 4, // ┘
        LowerLeftTriangle = 1 << 5, // └
        
    }
    protected override void Initialize()
    {
        base.Initialize();
        
        Board = new int[BoardHeight][];
        for (var i = 0; i < BoardHeight; i++)
        {
            Board[i] = new int[BoardWight];
        }
    }

    public Vector3 ChangeGridToPosition(int x, int y)
    {
        var xP = CellSize * x - CellSize / 2f;
        var yP = CellSize * y - CellSize / 2f;
        return new Vector3(xP,yP,0);
    }
}