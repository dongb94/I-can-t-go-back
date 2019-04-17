
// 현재 선택중인 타일, 현재 포커싱하고있는 셀 저장.
namespace Script.System.MapEditor
{
    public class TilePointer : Singleton<TilePointer>
    {
        public int x, y;
        public Tile.TileShape currentTile;
        public Tile.TileColor currentColor;
    }
}