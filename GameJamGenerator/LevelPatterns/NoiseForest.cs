public class NoiseForest : GameGenerator
{
    public override Grid Generate(int playerX)
    {
        IGrid<Tile> grid = new Grid(8, 9);
        BucketFill<Tile> bucket = new(new List<Vector2Int>() { new(0, 6) }, new(), new NoiseBrush<Tile>([(Tile.door, 1), (Tile.wall, 1)]));
        //(new DebuggerComponent<Tile>());
        bucket.Generate(ref grid);
        return (Grid)grid;

        static void ShowMiddleResult(IGrid<Tile> grid)
        {
            Console.WriteLine(grid.ToString());
            return;
            Console.ReadKey();
        }
    }
}