public class NoiseForest : GameGenerator
{
    public override Grid Generate(int playerX)
    {
        IGrid<Tile> grid = new Grid(9, 9);
        BucketFill<Tile> bucket = new(new List<Vector2Int>() { new(0, 6) }, new(), new NoiseBrush<Tile>([(Tile.wall, 1), (Tile.empty, 7)]));
        bucket.Generate(ref grid);
        MakeLinesFromTiles<Tile> makeLines = new(Direction.Up, Direction.Up, Tile.wall, Tile.debug, Tile.debug);
        makeLines.Generate(ref grid);
        return (Grid)grid;
    }
}