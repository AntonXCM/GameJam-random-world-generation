public class PerlinNoiseLevel :GameGenerator
{
    public override Grid Generate(int playerX)
    {
        IGrid<Tile> grid = new Grid(50, 50);
        new BucketFill<Tile>([Vector2Int.Zero], [], new PerlinNoiseBrush<Tile>(new(50, 50,1), new(7,7), f =>
        {
            f = Math.Abs(f);
            if(f < .25f) return Tile.empty;
            else if(f >= .25f && f < .5) return Tile.debug;
            else if(f >= .5f && f < .75) return Tile.door;
            return Tile.wall;
        })).Generate(ref grid);
        return grid as Grid;
    }
}