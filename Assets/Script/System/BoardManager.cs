using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
    public int CellSize;

    public int BoardHeight;
    public int BoardWight;

    public int[][] Board;
    
    protected override void Initialize()
    {
        base.Initialize();
        
        Board = new int[BoardWight][];
        for (var i = 0; i < BoardWight; i++)
        {
            Board[i] = new int[BoardHeight];
        }
    }
    
    #region <Properties>

    

    #endregion

    /// <summary>
    /// Change Grid (x,y) to world position
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
        Board[tile.x][tile.y] = (int)tile.color | (int)tile.shape;
    }

}