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

    private bool IsRightEmpty => PlayerMove.GetInstance.X + 1 != BoardWight && Board[PlayerMove.GetInstance.X+1][PlayerMove.GetInstance.Y]==null;

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
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="direction">0 = East , 1 = South , 2 = West , 3= North</param>
    public void CallEvent(int x, int y, int direction)
    {
        //
    }
}