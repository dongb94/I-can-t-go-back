
using System;
using UnityEngine;

public class MapFileReader
{
    public void ReadMapFile(string filePath)
    {
        var file = Resources.Load<TextAsset>(filePath);
        
        
    }

    /// <summary>
    /// 00 00 00 00
    /// Sh Co X  Y
    /// </summary>
    /// <param name="mapFile"></param>
    private void Parser(string mapFile)
    {
        var length = mapFile.Length;

        var mapInfo = mapFile.Split('|');

        foreach (var element in mapInfo)
        {
            var shape = int.Parse(element.Substring(0, 2));
            var color = int.Parse(element.Substring(2, 4));
            var x = int.Parse(element.Substring(4, 6));
            var y = int.Parse(element.Substring(6));

            var tileShape = (Tile.TileShape) shape;
            var tileColor = (Tile.TileColor) color;

            TileManager.GetInstance.GetTile(x, y, tileShape, tileColor);
        }
    }
    
}