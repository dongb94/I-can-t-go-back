
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
    
    
}