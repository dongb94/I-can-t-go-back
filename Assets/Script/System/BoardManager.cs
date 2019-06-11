
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BoardManager : Singleton<BoardManager>
{
    private const int CellSize = 1;

    public int BoardHeight;
    public int BoardWidth;

    public Tile[][] Board;

    public LineRenderer BoardLine;
    
    protected override void Initialize()
    {
        base.Initialize();
        
        Board = new Tile[BoardWidth][];
        for (var i = 0; i < BoardWidth; i++)
        {
            Board[i] = new Tile[BoardHeight];
        }

        BoardLine = GetComponent<LineRenderer>();
        
        DrawLine();
    }
    
    #region <Properties>

    public bool IsRightEmpty => PlayerManager.GetInstance.X + 1 < BoardWidth && Board[PlayerManager.GetInstance.X+1][PlayerManager.GetInstance.Y]==null;
    public bool IsLeftEmpty => PlayerManager.GetInstance.X > 0 && Board[PlayerManager.GetInstance.X-1][PlayerManager.GetInstance.Y]==null;
    public bool IsTopEmpty => PlayerManager.GetInstance.Y + 1 < BoardHeight && Board[PlayerManager.GetInstance.X][PlayerManager.GetInstance.Y+1]==null;
    public bool IsBottomEmpty => PlayerManager.GetInstance.Y > 0 && Board[PlayerManager.GetInstance.X][PlayerManager.GetInstance.Y-1]==null;

    #endregion

    /// <summary>
    /// Change Grid (x,y) to world position,
    /// (0,0) is bottom left
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Vector3 ChangeGridToPosition(int x, int y)
    {
        var xP = CellSize * (x - BoardWidth / 2f) + CellSize / 2f;
        var yP = CellSize * (y - BoardHeight / 2f) + CellSize / 2f;
        
        return new Vector3(xP,yP,0);
    }
    
    public Vector3 ChangeGridToPosition(Grid2D grid)
    {
        var xP = CellSize * (grid.x - BoardWidth / 2f) + CellSize / 2f;
        var yP = CellSize * (grid.y - BoardHeight / 2f) + CellSize / 2f;
        
        return new Vector3(xP,yP,0);
    }
    
    public Vector3 ChangeGridToCrossPosition(int x, int y)
    {
        var xP = CellSize * (x - BoardWidth / 2f);
        var yP = CellSize * (y - BoardHeight / 2f);
        
        return new Vector3(xP,yP,0);
    }

    // TODO 확인 해야됨
    public Grid2D ChangePositionToGrid(Vector3 position)
    {
        var grid = new Grid2D();

        var px = position.x + (BoardWidth % 2) * 0.5f;
        var py = position.y + (BoardHeight % 2) * 0.5f;;
        
        var x = position.x<0?(int)(px-1):(int)px;
        var y = position.y<0?(int)(py-1):(int)py;

        x /= CellSize;
        y /= CellSize;
        
        if (!(x >= (BoardWidth + 1) / 2) && !(x < -BoardWidth / 2) && !(y >= (BoardHeight + 1)/ 2) &&
            !(y < -BoardHeight / 2))
        {
            grid.x = x + BoardWidth / 2;
            grid.y = y + BoardHeight / 2;
            
            return grid;
        }
        
        grid.x = -1;
        grid.y = -1;

        return grid; // out of board
    }

    public void InsertTile(Tile tile)
    {
        if(Board[tile.x][tile.y] != null)
            TileManager.GetInstance.PoolTile(Board[tile.x][tile.y]);
        Board[tile.x][tile.y] = tile;
        tile.transform.position = ChangeGridToPosition(tile.x, tile.y);
    }

    public bool CheckIsEmptyDirection(Axis axis)
    {
        switch (axis)
        {
            case Axis.Right:
                return IsRightEmpty;
            case Axis.Left:
                return IsLeftEmpty;
            case Axis.Top:
                return IsTopEmpty;
            case Axis.Bottom:
                return IsBottomEmpty;
            default:
                throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
        }
    }

    /// <summary>
    /// Call collided Tile Event. 
    /// if (x,y) out of board, there are no effect
    /// </summary>
    /// <param name="x">tile X</param>
    /// <param name="y">tile Y</param>
    /// <param name="axis">tile position by player</param>
    public void CallEvent(int x, int y, Axis axis)
    {
        if (IsOutOfBoard(x, y)) return;
        Board[x][y].TileEffect(axis);
    }

    public bool IsOutOfBoard(int x, int y)
    {
        return (x >= BoardWidth
                 || x < 0
                 || y >= BoardHeight
                 || y < 0);
    }

    public void DrawLine()
    {
        var index = 0;
        BoardLine.startWidth = 0.002f * BoardWidth;
        BoardLine.endWidth = 0.002f * BoardWidth;
        BoardLine.positionCount = (BoardWidth + BoardWidth + 2) * 2;
        for (var i = 0; i <= BoardWidth; i++)
        {
            if (i % 2 == 0)
            {
                BoardLine.SetPosition(index++, ChangeGridToCrossPosition(i,0));
                BoardLine.SetPosition(index++, ChangeGridToCrossPosition(i,BoardHeight));   
            }
            else
            {
                BoardLine.SetPosition(index++, ChangeGridToCrossPosition(i,BoardHeight));
                BoardLine.SetPosition(index++, ChangeGridToCrossPosition(i,0));
            }
        }
        for (var i = 0; i <= BoardHeight; i++)
        {
            if (i % 2 == 0)
            {
                BoardLine.SetPosition(index++, ChangeGridToCrossPosition(BoardWidth, i));
                BoardLine.SetPosition(index++, ChangeGridToCrossPosition(0,i));   
            }
            else
            {   
                BoardLine.SetPosition(index++, ChangeGridToCrossPosition(0,i));
                BoardLine.SetPosition(index++, ChangeGridToCrossPosition(BoardWidth,i));
            }
        }
    }


    #region <Debug>

    void BoardSizeDebuger()
    {
        Debug.Log("X : "+BoardWidth);
        Debug.Log("Y : "+BoardHeight);
        Debug.Log("x leng : "+Board.Length);
        Debug.Log("y leng : "+Board[0].Length);
        Debug.Log("player X : "+PlayerManager.GetInstance.X);
        Debug.Log("player Y : "+PlayerManager.GetInstance.Y);
    }

    #endregion
}

//TODO Grid 위치 생각해볼것
public struct Grid2D
{
    public int x;
    public int y;
}