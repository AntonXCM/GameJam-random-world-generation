public class NoiseForest : GameGenerator
{
    public override Grid Generate(int playerX)
    {
        IGrid<Tile> grid = new Grid(9, 9);
        BucketFill<Tile> bucket = new(new List<Vector2Int>() { new(0, 6) }, new(), new NoiseBrush<Tile>([(Tile.wall, 1), (Tile.empty, 7)]), [new ResultPrintComponent<Tile>()]);
        bucket.Generate(ref grid);
        MakeLinesFromTiles<Tile> makeLines = new(Direction.Right, Tile.wall, Tile.door);
        makeLines.Generate(ref grid);
        new MakeSolidPlatform<Tile>(4, Tile.wall, new SimpleBrush<Tile>(Tile.wall)).Generate(ref grid);
        return (Grid)grid;
    }
}