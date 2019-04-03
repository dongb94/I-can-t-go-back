
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    public Tile[] TileSet;

    private const int InitializedPoolSize = 10;

    private List<Queue<Tile>> _tilePool;
    
    
    protected override void Initialize()
    {
        base.Initialize();

        for (var i = 0; i < TileSet.Length; i++)
        {
            _tilePool.Add(new Queue<Tile>());            
        }
    }

    public int InitializePool()
    {
        for (var i = 0; i < InitializedPoolSize; i++)
        {
            for (var j = 0; j < TileSet.Length; j++)
            {
                var tile = GameObject.Instantiate(TileSet[j], BoardManager.GetInstance.transform, true);
                tile.OnPooled();
                _tilePool[j].Enqueue(tile);
            }
        }

        return InitializedPoolSize;
    }

    public Tile GetTile(int x, int y, Tile.TileShape shape, Tile.TileColor color = Tile.TileColor.None)
    {
        if (BoardManager.GetInstance.BoardWight <= x || x < 0) return null;
        if (BoardManager.GetInstance.BoardHeight <= y || y < 0) return null;
        
        var pool = _tilePool[(int) shape];
        Tile tile;
        if (pool.Count != 0)
        {
            tile = pool.Dequeue();
        }
        else
        {
            tile = GameObject.Instantiate(TileSet[(int)shape], BoardManager.GetInstance.transform, true);
        }

        tile.x = x;
        tile.y = y;

        tile.SetColor(color);
        
        BoardManager.GetInstance.InsertTile(tile);

        return tile;
    }

    public void PoolTile(Tile tile)
    {
        tile.OnPooled();
        _tilePool[(int)tile.shape].Enqueue(tile);
    }
}