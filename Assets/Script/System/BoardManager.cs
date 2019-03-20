
using System;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
    public int CellSize;

    public int BoardHeight;
    public int BoardWight;

    public Tile[][] Board;
    
    protected override void Initialize()
    {
        base.Initialize();
        
        Board = new Tile[BoardWight][];
        for (var i = 0; i < BoardWight; i++)
        {
            Board[i] = new Tile[BoardHeight];
        }
    }
    
    #region <Properties>

    public bool IsRightEmpty => PlayerManager.GetInstance.X + 1 < BoardWight && Board[PlayerManager.GetInstance.X+1][PlayerManager.GetInstance.Y]==null;
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
        var xP = CellSize * (x - BoardWight / 2f) + CellSize / 2f;
        var yP = CellSize * (y - BoardHeight/2) + CellSize / 2f;
        
        return new Vector3(xP,yP,0);
    }

    public void InsertTile(Tile tile)
    {
        if(Board[tile.x][tile.y] != null)
            TileManager.GetInstance.PoolTile(Board[tile.x][tile.y]);
        Board[tile.x][tile.y] = tile;
        tile.transform.position = ChangeGridToPosition(tile.x, tile.y);
    }

    /// <summary>
    /// Call collided Tile Event. 
    /// if (x,y) out of board, there are no effect
    /// </summary>
    /// <param name="x">tile X</param>
    /// <param name="y">tile Y</param>
    /// <param name="axis">player position by tile</param>
    public void CallEvent(int x, int y, Axis axis)
    {
        //
    }
}