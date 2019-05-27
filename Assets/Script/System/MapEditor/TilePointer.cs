
// 현재 선택중인 타일, 현재 포커싱하고있는 셀 저장.

using UnityEngine;

namespace Script.System.MapEditor
{
    public class TilePointer : Singleton<TilePointer>
    {
        public int x, y;
        public Tile.TileShape currentTile;
        public Tile.TileColor currentColor;

        public SpriteRenderer SampleSprite;

        protected override void Awake()
        {
            SampleSprite = GetComponent<SpriteRenderer>();
        }

        public void SetSampleTile(Tile.TileShape shape, Tile.TileColor color)
        {
            currentTile = shape;
            currentColor = color;

            SampleSprite.color = Tile.GetColor(color);
            // TODO texture 바꿔줘잉
            // SampleSprite.sprite.texture = 
        }
    }
}