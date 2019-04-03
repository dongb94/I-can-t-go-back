
public class HollowSquareTile : Tile
{
    public override void TileEffect(Axis axis)
    {
        Destroy(this);
    }
}