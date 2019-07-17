using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Script.System.MapEditor
{
    public class MapSaver : MonoBehaviour
    {
        private BoardManager board;
        private StringBuilder mapFile;
        private string path;

        private void Awake()
        {
            path = Application.persistentDataPath + "/MapData/";
            board = BoardManager.GetInstance;
            mapFile = new StringBuilder();
        }

        public void SaveMap(string fileName)
        {
            mapFile.Clear();
            
            var width = board.BoardWidth;
            var height = board.BoardHeight;

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var tile = board.Board[i][j];
                    TileToString(tile);
                    mapFile.Append("|");
                }
            }
            
            var writer = File.CreateText(path+fileName+".txt");
            writer.Write(mapFile.ToString());
            writer.Flush();
            writer.Close();
        }

        private void TileToString(Tile tile)
        {
            if ((int) tile.shape < 10) mapFile.Append("0");
            mapFile.Append((int)tile.shape);
            
            if ((int) tile.color < 10) mapFile.Append("0");
            mapFile.Append((int)tile.color);
            
            if ((int) tile.x < 10) mapFile.Append("0");
            mapFile.Append((int)tile.x);
            
            if ((int) tile.y < 10) mapFile.Append("0");
            mapFile.Append((int)tile.y);
        }
    }
}